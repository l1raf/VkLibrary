using System.Net;
using System.Net.Http;
using System.Text;

namespace VkLibrary.Sth
{
    internal class Client
    {
        private static HttpClient instance;
        private static CookieContainer cookieContainer = new CookieContainer();

        public static HttpClient Instance
        {
            get {
                if (instance != null)
                {
                    return instance;
                }

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer,
                    UseCookies = true,
                };

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                return instance = new HttpClient(handler);
            }
        }

        public static CookieContainer CookieContainer
        {
            get {
                return cookieContainer;
            }
            set {
                cookieContainer = value;
            }
        }

        private Client() { }
    }
}
