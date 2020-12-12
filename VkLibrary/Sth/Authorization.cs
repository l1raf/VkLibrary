using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VkLibrary.Exceptions;

namespace VkLibrary.Sth
{
    class Authorization
    {
        #region Fields

        const string baseAuthorizeUrl = "https://oauth.vk.com/authorize?";
        const string loginUrl = "https://login.vk.com/?act=login&soft=1";
        static readonly Uri redirectUri = new Uri("https://oauth.vk.com/blank.html");

        #endregion

        internal static async Task Authorize()
        {
            foreach (Cookie cookie in Client.CookieContainer.GetCookies(new Uri("https://vk.com")))
            {
                cookie.Expired = true;
            }

            Client.Instance.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla / 5.0 (Windows NT 6.3; WOW64; rv: 31.0) Gecko / 20100101 Firefox / 31.0");

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken))
            {
                return;
            }

            var authUrl = CreateUrl();

            (HttpResponseMessage response, string source) = await OpenForm(authUrl);
            var inputs = GetParams(source);

            inputs["email"] = VkApiSettings.Login;
            inputs["pass"] = VkApiSettings.Password;

            var authResponse = await FillForm(loginUrl, response, inputs);

            if (authResponse.RequestMessage.RequestUri.ToString().Contains("authorize"))
            {
                throw new AuthorizationException("Неверный логин или пароль.");
            }
            else if (authResponse.RequestMessage.RequestUri.ToString().Contains("authcheck"))
            {
                authResponse = await TwoFactorAuth(authResponse);
            }

            SetAccessToken(authResponse.RequestMessage.RequestUri.ToString());
        }

        private static async Task<HttpResponseMessage> SolveCaptcha(HttpResponseMessage response)
        {
            if (VkApiSettings.SolveCaptcha == null)
            {
                throw new CaptchaException("Необходимо установить ссылку на метод для распознавания текста капчи.");
            }

            var source = await response.Content.ReadAsStringAsync();
            var @params = GetParams(source);

            var document = new HtmlDocument();
            document.LoadHtml(source);

            var actionUrl = "https://m.vk.com" +
                document.DocumentNode?.SelectSingleNode("//form")?.Attributes["action"]?.Value.ToString();

            var captchaImgUrl = "https://m.vk.com" +
                document.DocumentNode?.SelectSingleNode("//img")?.Attributes["src"]?.Value.ToString();

            var code = VkApiSettings.SolveCaptcha?.Invoke(captchaImgUrl);
            @params.Add("captcha_key", code);

            response = await FillForm(actionUrl, response, @params);

            if (response.RequestMessage.RequestUri.ToString().Contains("authcheck_code"))
            {
                throw new CaptchaException("Неверное значение капчи.");
            }

            return response;
        }

        private static void SetAccessToken(string accessToken)
        {
            VkApiSettings.AccessToken =
                Regex.Match(accessToken, @"access_token=(.*?)&").Groups[1].Value;
        }

        private static async Task<HttpResponseMessage> TwoFactorAuth(HttpResponseMessage response)
        {
            if (VkApiSettings.Confirmation == null)
            {
                throw new TwoFactorAuthException("Необходимо установить ссылку на метод для двухфакторной аутентификации.");
            }

            var source = await response.Content.ReadAsStringAsync();
            (string actionUrl, var @params) = GetTwoFactorAuthParams(source);

            response = await FillForm(actionUrl, response, @params);

            if (response.RequestMessage.RequestUri.ToString().Contains("authcheck_code"))
            {
                response = await SolveCaptcha(response);
            }
            else if (response.RequestMessage.RequestUri.ToString().Contains("authcheck"))
            {
                throw new TwoFactorAuthException("Неверный код.");
            }

            return response;
        }

        private static (string, Dictionary<string, string>) GetTwoFactorAuthParams(string source)
        {
            var @params = GetParams(source);
            var document = new HtmlDocument();

            document.LoadHtml(source);
            var form = document.DocumentNode?.SelectSingleNode("//form");

            var url = "https://m.vk.com" + form.Attributes["action"]?.Value.ToString();

            @params.Add("code", VkApiSettings.Confirmation?.Invoke());

            return (url, @params);
        }

        private static async Task<(HttpResponseMessage, string)> OpenForm(Uri authUrl)
        {
            try
            {
                var response = await Client.Instance.GetAsync(authUrl);
                response.EnsureSuccessStatusCode();
                var source = await response.Content.ReadAsStringAsync();

                return (response, source);
            }
            catch (Exception e)
            {
                throw new VkLibraryException(e.Message);
            }
        }

        private static async Task<HttpResponseMessage> FillForm(string actionUrl,
            HttpResponseMessage response, Dictionary<string, string> inputs)
        {
            try
            {
                var cookies = Client.CookieContainer.GetCookies(response.RequestMessage.RequestUri);

                foreach (Cookie cookie in cookies)
                {
                    Client.CookieContainer.Add(response.RequestMessage.RequestUri, cookie);
                }

                response = await Client.Instance.PostAsync(actionUrl, new FormUrlEncodedContent(inputs));
                return response;
            }
            catch (Exception e)
            {
                throw new VkLibraryException(e.Message);
            }
        }

        internal static Dictionary<string, string> GetParams(string source)
        {
            var inputs = new Dictionary<string, string>();
            var document = new HtmlDocument();

            document.LoadHtml(source);
            var form = document.DocumentNode?.SelectSingleNode("//form");

            foreach (var node in form?.SelectNodes("//input"))
            {
                if (node.Attributes["type"] == null
                    || node.Attributes["type"].Value != "hidden")
                {
                    continue;
                }

                string name = node.Attributes["name"]?.Value;
                string value = node.Attributes["value"]?.Value;

                if (!string.IsNullOrEmpty(name) && !inputs.ContainsKey(name))
                {
                    inputs.Add(name, value);
                }
            }

            return inputs;
        }

        private static Uri CreateUrl()
        {
            var url = new StringBuilder(baseAuthorizeUrl);
            url.Append($"client_id={VkApiSettings.ApplicationId}&");
            url.Append($"redirect_uri={redirectUri}&");
            url.Append($"display=page&");
            url.Append($"response_type=token&");
            url.Append($"v={VkApiSettings.Version}&");
            return new Uri(url.ToString());
        }
    }
}
