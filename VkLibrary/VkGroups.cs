using System.Collections.Generic;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models.API;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Информация о группах пользователя.
    /// </summary>
    public class VkGroups
    {
        #region Fields

        private Groups api;
        private int id;

        #endregion

        #region Properties

        /// <summary>
        /// Короткий адрес страницы пользователя.
        /// </summary>
        public string PageName { get; private set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id
        {
            get {
                return id;
            }
            private set {
                if (value < 1)
                {
                    throw new VkLibraryException("Значение Id должно быть положительным.");
                }
                id = value;
            }
        }

        /// <summary>
        /// Информация о сообществах пользователя.
        /// </summary>
        public Groups Api
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

        private VkGroups() { }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkGroups> CreateAsync(int id)
        {
            var groups = new VkGroups
            {
                Id = id
            };

            return groups.InitializeAsync(id);
        }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="pageName">короткое имя страницы пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkGroups> CreateAsync(string pageName)
        {
            var groups = new VkGroups
            {
                PageName = pageName
            };

            return groups.InitializeAsync(pageName);
        }

        private async Task<VkGroups> InitializeAsync(int id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                Api = await RunGroupsAsync(id);
            }

            return this;
        }

        private async Task<VkGroups> InitializeAsync(string id)
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
                Api = await RunGroupsAsync(Id);
            }

            return this;
        }

        private async Task<Groups> RunGroupsAsync<T>(T id)
        {
            Groups groups = await API.CreateAsync<Groups>("groups.get", new Dictionary<string, string>
            {
                { "access_token", $"{VkApiSettings.ServiceToken ?? VkApiSettings.AccessToken}" },
                { "user_id", $"{id}" },
                { "fields", "city,country,place,description,wiki_page,members_count,counters,start_date,finish_date,can_post," +
                            "can_see_all_posts,activity,status,contacts,links,fixed_post,verified,site,can_create_topic" },
                { "count", "1000" },
                { "extended", "1" },
                { "lang", $"{VkApiSettings.Language}" },
                { "v", $"{VkApiSettings.Version}" }
            });
            return groups;
        }
    }
}
