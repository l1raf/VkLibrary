using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models;
using VkLibrary.Models.InternalModels;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Class for scraping user's data without API.
    /// </summary>
    public class Scraper
    {
        private int photosCount = 0;
        private int subscribersCount = 0;
        private const string baseUrl = "https://vk.com";
        private const string loginUrl = "https://login.vk.com/?act=login";
        private const string followingUrl = "https://vk.com/al_fans.php";
        private const string photosUrl = "https://vk.com/al_photos.php";
        private const string friendsUrl = "https://vk.com/al_friends.php";
        private HtmlDocument document;

        /// <summary>
        /// A method for two-factor auth.
        /// </summary>
        public static Func<string> Confirmation { get; set; }

        /// <summary>
        /// A method for solving captcha.
        /// </summary>
        public static Func<string, string> SolveCaptcha { get; set; }

        /// <summary>
        /// If you can see profiles as an authorized user.
        /// </summary>
        public bool IsAuthorized { get; private set; }

        /// <summary>
        /// Creates an instance of a Scraper.
        /// </summary>
        public Scraper()
        {
            foreach (Cookie cookie in Client.CookieContainer.GetCookies(new Uri(baseUrl)))
            {
                cookie.Expired = true;
            }
        }

        private async Task<string> GetSource<T>(T id)
        {
            Client.Instance.DefaultRequestHeaders.Accept.Clear();
            Client.Instance.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla / 5.0 (Windows NT 6.3; WOW64; rv: 31.0) Gecko / 20100101 Firefox / 31.0");

            try
            {
                HttpResponseMessage response = (typeof(T) == typeof(int))
                    ? await Client.Instance.GetAsync(baseUrl + $"/id{id}")
                    : await Client.Instance.GetAsync(baseUrl + $"/{id}");

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new VkLibraryException(ex.Message);
            }
        }

        private async Task<HtmlDocument> GetDocument<T>(T id)
        {
            var source = await GetSource(id);
            document = new HtmlDocument();
            document.LoadHtml(source);
            return document;
        }

        /// <summary>
        /// Authorizes a user without API.
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>
        public async Task Authorize(string login, string password)
        {
            Client.Instance.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla / 5.0 (Windows NT 6.3; WOW64; rv: 31.0) Gecko / 20100101 Firefox / 31.0");

            try
            {
                var response = await Client.Instance.GetAsync(baseUrl);
                response.EnsureSuccessStatusCode();
                var source = await response.Content.ReadAsStringAsync();

                var inputs = Sth.Authorization.GetParams(source);

                inputs["email"] = login;
                inputs["pass"] = password;

                response = await Client.Instance.PostAsync(loginUrl, new FormUrlEncodedContent(inputs));

                var cookies = Client.CookieContainer.GetCookies(response.RequestMessage.RequestUri);

                SaveCookies(response);

                var url = response.RequestMessage.RequestUri;

                response = await Client.Instance.GetAsync(baseUrl + "/login?act=authcheck");
                source = await response.Content.ReadAsStringAsync();

                if (response.RequestMessage.RequestUri.ToString().Contains("feed"))
                {
                    IsAuthorized = true;
                    return;
                }

                var hash = Regex.Match(source, @"window.Authcheck.init\('(.*?)'").Groups[1].Value;

                inputs = new Dictionary<string, string>
                {
                    ["al"] = "1",
                    ["code"] = Confirmation.Invoke(),
                    ["hash"] = hash,
                    ["remember"] = "1"
                };

                response = await Client.Instance.PostAsync(baseUrl + "/al_login.php?act=a_authcheck_code", new FormUrlEncodedContent(inputs));

                SaveCookies(response);

                response = await Client.Instance.GetAsync(url);
                source = await response.Content.ReadAsStringAsync();

                SaveCookies(response);

                IsAuthorized = true;
            }
            catch
            {
                IsAuthorized = false;
                throw new AuthorizationException("Something went wrong.");
            }
        }

        private void SaveCookies(HttpResponseMessage response)
        {
            var cookies = Client.CookieContainer.GetCookies(response.RequestMessage.RequestUri);

            foreach (Cookie cookie in cookies)
            {
                Client.CookieContainer.Add(response.RequestMessage.RequestUri, cookie);
            }
        }

        /// <summary>
        /// Authorizes a user using API.
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>
        public async Task AuthorizeUsingApi(string login, string password)
        {
            VkApiSettings.Login = login;
            VkApiSettings.Password = password;
            VkApiSettings.Confirmation = Confirmation;
            VkApiSettings.SolveCaptcha = SolveCaptcha;

            await Sth.Authorization.Authorize();
            IsAuthorized = true;

            VkApiSettings.Login = null;
            VkApiSettings.Password = null;
            VkApiSettings.AccessToken = null;
        }

        /// <summary>
        /// Gets general user's data.
        /// </summary>
        /// <returns>An object with filled properties.</returns>
        /// <param name="id">User id</param>
        public async Task<User> GetGeneralData(int id)
        {
            document = await GetDocument(id);
            return GetData();
        }

        /// <summary>
        /// Gets general user's data.
        /// </summary>
        /// <returns>An object with filled properties.</returns>
        /// <param name="pageName">Page name</param>
        public async Task<User> GetGeneralData(string pageName)
        {
            document = await GetDocument(pageName);
            return GetData();
        }

        private User GetData()
        {
            User user = new User();

            var aside = document?.DocumentNode?.SelectSingleNode(".//div[@class='narrow_column']");

            user.AvatarImg = aside?.SelectSingleNode(".//div[@id='page_avatar']")
                ?.SelectSingleNode(".//img[@class='page_avatar_img']")?.Attributes["src"].Value;

            var giftsCount = aside?.SelectSingleNode(".//span[@id='gifts_module_count']")?.InnerText?.Replace(" ", "");
            var following = aside?.SelectSingleNode(".//div[@id='profile_idols']")
                ?.SelectSingleNode(".//span[@class='header_count fl_l']")?.InnerText;
            var albumsCount = aside?.SelectSingleNode(".//div[@id='profile_albums']")
                ?.SelectSingleNode(".//span[@class='header_count fl_l']")?.InnerText;

            var wideColumn = document?.DocumentNode?.SelectSingleNode(".//div[@class='wide_column']");
            var pageBlock = wideColumn?.SelectSingleNode(".//div[@class='page_block']");

            var pageTop = pageBlock?.SelectSingleNode(".//div[@class='page_top']");
            user.Name = pageTop?.SelectSingleNode(".//h1[@class='page_name']")?.InnerText;
            user.Status = pageTop?.SelectSingleNode(".//span[@class='current_text']")?.InnerText;

            var profileInfo = pageBlock?.SelectSingleNode(".//div[@id='page_info_wrap']");

            user.Birthday = profileInfo?.SelectSingleNode(".//a[contains(@href, '[bday]')]")?.InnerText;
            user.CurrentCity = profileInfo?.SelectSingleNode(".//a[contains(@href, '[city]')]")?.InnerText;
            user.Universities = profileInfo?.SelectNodes(".//a[contains(@href, '[university]')]")?.Select(x => x.InnerText);
            user.Schools = profileInfo?.SelectNodes(".//a[contains(@href, '[school]')]")?.Select(x => x.InnerText);
            user.Hometown = profileInfo?.SelectSingleNode(".//a[contains(@href, '[hometown]')]")?.InnerText;
            user.Station = profileInfo?.SelectSingleNode(".//a[contains(@href, '[addr_station]')]")?.InnerText;
            user.District = profileInfo?.SelectSingleNode(".//a[contains(@href, '[addr_district]')]")?.InnerText;
            user.Companies = profileInfo?.SelectNodes(".//a[contains(@href, '[company]')]")?.Select(x => x.InnerText);
            user.Languages = profileInfo?.SelectNodes(".//a[contains(@href, '[lang]')]")?.Select(x => x.InnerText);
            user.PersonalPriority = profileInfo?.SelectSingleNode(".//a[contains(@href, '[personal_priority]')]")?.InnerText;
            user.ImportantInOthers = profileInfo?.SelectSingleNode(".//a[contains(@href, '[people_priority]')]")?.InnerText;
            user.ViewsOnAlcohol = profileInfo?.SelectSingleNode(".//a[contains(@href, '[alcohol]')]")?.InnerText;
            user.ViewsOnSmoking = profileInfo?.SelectSingleNode(".//a[contains(@href, '[smoking]')]")?.InnerText;
            user.Religion = profileInfo?.SelectSingleNode(".//a[contains(@href, '[religion]')]")?.InnerText;

            var skype = profileInfo?.SelectSingleNode(".//a[contains(@href, 'skype')]");
            user.Skype = skype?.InnerText;
            user.SkypeUrl = skype?.Attributes["href"]?.Value;

            var inst = profileInfo?.SelectSingleNode(".//a[contains(@href, 'instagram')]");
            user.Instagram = inst?.InnerText;
            user.InstagramUrl = inst?.Attributes["href"]?.Value;

            var facebook = profileInfo?.SelectSingleNode(".//a[contains(@href, 'facebook')]");
            user.Facebook = facebook?.InnerText;
            user.FacebookUrl = facebook?.Attributes["href"]?.Value;

            var twitter = profileInfo?.SelectSingleNode(".//a[contains(@href, 'twitter')]");
            user.Twitter = twitter?.InnerText;
            user.TwitterUrl = twitter?.Attributes["href"]?.Value;

            var siblings = profileInfo?.SelectNodes(".//a[@class='mem_link']");
            user.Siblings = GetSiblings(siblings);

            user.GiftsCount = Convert(giftsCount);
            user.FollowingCount = Convert(following);
            user.AlbumsCount = Convert(albumsCount);

            if (IsAuthorized)
            {
                var commonFriends = document.DocumentNode?.SelectSingleNode(".//div[@id='profile_common_friends']");
                var commonFriendsCount = commonFriends?.SelectSingleNode(".//span[@class='header_count fl_l']")?.InnerText;
                user.CommonFriendsCount = Convert(commonFriendsCount);
            }

            return user;
        }

        /// <summary>
        /// Gets list of user's subscriptions.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>List of subscriptions.</returns>
        public async Task<IEnumerable<Following>> GetSubscriptions(int id)
        {
            List<Following> list = new List<Following>();

            Dictionary<string, string> pairs = new Dictionary<string, string>
            {
                ["oid"] = $"{id}",
                ["act"] = "load_idols",
                ["al"] = "1"
            };

            try
            {
                var response = await Client.Instance.PostAsync(followingUrl, new FormUrlEncodedContent(pairs));
                var source = await response.Content.ReadAsStringAsync();
                var json = source.Replace("<!--", "");

                JObject jObj = JObject.Parse(json);
                var insaneJson = jObj.ToObject<FollowingJson>();

                foreach (var arr in insaneJson.Payload[1].Objects[0])
                {
                    list.Add(new Following
                    {
                        Id = arr[0].Integer,
                        Name = arr[2].String
                    });
                }
            }
            catch
            {
                return list;
            }

            return list;
        }

        /// <summary>
        /// Gets user's photos.
        /// </summary>
        /// <remarks> 
        /// To get all photos call the mothod until LoadMore is false.
        /// </remarks>
        /// <param name="id">User id</param>
        /// <returns>
        /// LoadMore - if there are any photos to load, Urls - list of urls.
        /// </returns>
        public async Task<(bool LoadMore, IEnumerable<string> Urls)> GetPhotos(int id)
        {
            List<string> urls = new List<string>();

            if (!IsAuthorized)
            {
                foreach (Cookie cookie in Client.CookieContainer.GetCookies(new Uri(baseUrl)))
                {
                    cookie.Expired = true;
                }
            }

            Dictionary<string, string> pairs = new Dictionary<string, string>
            {
                ["owner"] = $"{id}",
                ["act"] = "show_albums",
                ["al"] = "1",
            };

            if (photosCount != 0)
            {
                pairs["offset"] = $"{photosCount}";
                pairs["part"] = "1";
                pairs["only_photos"] = "1";
            }

            try
            {
                var response = await Client.Instance.PostAsync(photosUrl, new FormUrlEncodedContent(pairs));
                var source = await response.Content.ReadAsStringAsync();
                source = Regex.Unescape(source);
                source = source.Substring(source.IndexOf("<div") - 4);

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(source);

                foreach (var photo in document?.DocumentNode?.SelectNodes("//a[contains(@href, 'photo')]"))
                {
                    urls.Add(baseUrl + photo?.Attributes["href"]?.Value);
                }

                if (urls.Count > 88)
                {
                    urls.RemoveAt(88);
                }
            }
            catch
            {
                return (false, urls);
            }

            if (urls.Count() > 80)
            {
                photosCount += 88;
                return (true, urls);
            }
            else
            {
                photosCount = 0;
                return (false, urls);
            }
        }

        /// <summary>
        /// Gets the list of user's friends.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>List of friends.</returns>
        /// <remarks>Use only after authorization.</remarks>
        public async Task<IEnumerable<Person>> GetFriends(int id)
        {
            List<Person> friends = new List<Person>();

            if (!IsAuthorized)
            {
                return (friends);
            }

            Dictionary<string, string> pairs = new Dictionary<string, string>
            {
                ["id"] = $"{id}",
                ["act"] = "load_friends_silent",
                ["al"] = "1",
                ["gid"] = "0"
            };

            try
            {
                var response = await Client.Instance.PostAsync(friendsUrl, new FormUrlEncodedContent(pairs));
                var source = await response.Content.ReadAsStringAsync();

                var json = source.Substring(source.IndexOf("all") - 3);
                json = json.Substring(0, json.IndexOf("]]}") + 3);
                json = Regex.Unescape(json);

                JObject jObj = JObject.Parse(json);
                var usersFriends = jObj.ToObject<FriendsAndSubscribers>();

                foreach (var user in usersFriends.All)
                {
                    friends.Add(new Person
                    {
                        Id = Convert(user[0].String),
                        ProfileUrl = user[1].String,
                        PageName = user[2].String,
                        Name = user[5].String
                    });
                }
            }
            catch
            {
                return friends;
            }

            return friends;
        }

        /// <summary>
        /// Gets list of subscribers.
        /// To get all subscribers call the method until LoadMore is false.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>
        /// LoadMore - if there are any subscribers to load, Subscribers - list of subscribers.
        /// </returns>
        /// <remarks>
        /// Use only after authorization.
        /// </remarks>
        public async Task<(bool LoadMore, IEnumerable<Person> Subscribers)> GetSubscribers(int id)
        {
            List<Person> subscribers = new List<Person>();

            if (!IsAuthorized)
            {
                foreach (Cookie cookie in Client.CookieContainer.GetCookies(new Uri(baseUrl)))
                {
                    cookie.Expired = true;
                }

                return (false, subscribers); 
            }

            Dictionary<string, string> pairs = new Dictionary<string, string>
            {
                ["id"] = $"{id}",
                ["act"] = "load_friends_silent",
                ["al"] = "1",
                ["gid"] = "0"
            };

            try
            {
                HttpResponseMessage response = null;
                string json = null;

                if (subscribersCount == 15)
                {
                    response = await Client.Instance.PostAsync(friendsUrl, new FormUrlEncodedContent(pairs));
                    var source = await response.Content.ReadAsStringAsync();
                    json = source.Substring(source.IndexOf("all") - 3);
                    json = json.Substring(0, json.IndexOf("]]}") + 3);
                }
                else
                {
                    pairs["act"] = "get_section_friends";
                    pairs["offset"] = $"{subscribersCount}";
                    pairs["section"] = "subscribers";

                    response = await Client.Instance.PostAsync(baseUrl + "/friends", new FormUrlEncodedContent(pairs));
                    var source = await response.Content.ReadAsStringAsync();
                    json = source.Substring(source.IndexOf("subscribers") - 3);
                    json = json.Substring(0, json.IndexOf("]]}") + 3);
                }

                json = Regex.Unescape(json);

                JObject jObj = JObject.Parse(json);
                var usersFriends = jObj.ToObject<FriendsAndSubscribers>();

                foreach (var user in usersFriends.Subscribers)
                {
                    var person = new Person
                    {
                        Id = Convert(user[0].String),
                        ProfileUrl = user[1].String,
                        PageName = user[2].String,
                        Name = user[5].String
                    };
                    subscribers.Add(person);
                }
            }
            catch
            {
                return (false, subscribers);
            }

            if (subscribers.Count() < 40 && subscribersCount != 15)
            {
                subscribersCount = 15;
                return (false, subscribers);
            }
            else
            {
                subscribersCount += 40;
                return (true, subscribers);
            }
        }

        private int? Convert(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return null;
            }
        }

        private Dictionary<string, string> GetSiblings(HtmlNodeCollection siblings)
        {
            if (siblings == null)
            {
                return null;
            }

            var pairs = new Dictionary<string, string>();

            foreach (var sibling in siblings)
            {
                pairs.Add(sibling.InnerText, sibling.Attributes["href"]?.Value);
            }

            return pairs;
        }
    }
}
