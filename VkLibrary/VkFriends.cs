using System.Collections.Generic;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models.API;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Информация о друзьях пользователя.
    /// </summary>
    public class VkFriends
    {
        #region Fields

        private int id;
        private Friends api;

        #endregion

        #region Properties

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id
        {
            get {
                return id;
            }
            set {
                if (value < 1)
                {
                    throw new VkLibraryException("Значение Id должно быть положительным.");
                }
                id = value;
            }
        }

        /// <summary>
        /// Короткое имя страницы пользователя.
        /// </summary>
        public string PageName { get; private set; }

        /// <summary>
        /// Информация о друзьх пользователя, полученная с использованием API.
        /// </summary>
        public Friends Api
        {
            get {
                if (string.IsNullOrEmpty(VkApiSettings.AccessToken)
                    && string.IsNullOrEmpty(VkApiSettings.ServiceToken))
                {
                    throw new VkLibraryException("Необходим ключ доступа.");
                }
                return api;
            }
            private set {
                api = value;
            }
        }

        #endregion

        private VkFriends() { }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkFriends> CreateAsync(int id)
        {
            var friends = new VkFriends
            {
                Id = id
            };

            return friends.InitializeAsync(id);
        }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="pageName">короткое имя страницы пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkFriends> CreateAsync(string pageName)
        {
            var friends = new VkFriends
            {
                PageName = pageName
            };

            return friends.InitializeAsync(pageName);
        }

        private async Task<VkFriends> InitializeAsync(int id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                Api = await RunFriendsAsync(id);
            }

            return this;
        }

        private async Task<VkFriends> InitializeAsync(string id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                var person = await VkPerson.CreateAsync(id);
                Id = person.Id;
                Api = await RunFriendsAsync(Id);
            }

            return this;
        }

        private async Task<Friends> RunFriendsAsync<T>(T id)
        {
            Friends friends = await API.CreateAsync<Friends>("friends.get", new Dictionary<string, string>
            {
                { "access_token", $"{VkApiSettings.AccessToken ?? VkApiSettings.ServiceToken}" },
                { "user_id", $"{id}" },
                { "fields", "nickname,domain,sex,bdate,city,country,timezone,photo_50,photo_100," +
                            "photo_200_orig,has_mobile,contacts,education,online,relation,last_seen," +
                            "status,can_write_private_message,can_see_all_posts,can_post,universities" },
                { "lang", $"{VkApiSettings.Language}" },
                { "v", $"{VkApiSettings.Version}" }
            });
            return friends;
        }
    }
}
