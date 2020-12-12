using System.Collections.Generic;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models.API;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Информация о пользователе.
    /// </summary>
    public class VkPerson
    {
        #region Fields

        private int id;
        private Person api;

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
            private set {
                if (value < 1)
                {
                    throw new VkLibraryException("Значение Id должно быть положительным.");
                }
                id = value;
            }
        }

        /// <summary>
        /// Имя страницы пользователя.
        /// </summary>
        public string PageName { get; private set; }

        /// <summary>
        /// Информация о пользователе, полученная с использованием API.
        /// </summary>
        public Person Api
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

        private VkPerson() { }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkPerson> CreateAsync(int id)
        {
            var person = new VkPerson
            {
                Id = id
            };

            return person.InitializeAsync(id);
        }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="pageName">короткое имя страницы пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkPerson> CreateAsync(string pageName)
        {
            var person = new VkPerson
            {
                PageName = pageName
            };

            return person.InitializeAsync(pageName);
        }

        private async Task<VkPerson> InitializeAsync<T>(T id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                Api = await RunPersonAsync(id);
                Id = Api.Id;
            }

            return this;
        }

        private async Task<Person> RunPersonAsync<T>(T id)
        {
            List<Person> person;
            if (string.IsNullOrWhiteSpace(VkApiSettings.AccessToken))
            {
                person = await API.CreateAsync<List<Person>>("users.get", new Dictionary<string, string>
                {
                    { "user_ids", $"{id}" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "fields", "photo_id,verified,sex,bdate,city,counters,country,home_town,has_photo,photo_50," +
                                "photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online," +
                                "domain,has_mobile,contacts,site,education,universities,schools,status,last_seen," +
                                "followers_count,occupation,nickname,relatives,relation,personal,connections,exports," +
                                "activities,interests,music,movies,tv,books,games,about,quotes,is_hidden_from_feed,timezone," +
                                "screen_name,maiden_name,crop_photo,is_friend,friend_status,career,military" },
                    { "access_token", $"{VkApiSettings.ServiceToken}" },
                    { "v", $"{VkApiSettings.Version}" }
                });
            }
            else
            {
                person = await API.CreateAsync<List<Person>>("users.get", new Dictionary<string, string>
                {
                    { "user_ids", $"{id}" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "fields", "photo_id,verified,sex,bdate,city,country,counters,home_town,has_photo,photo_50,photo_100," +
                                "photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online,domain,has_mobile," +
                                "contacts,site,education,universities,schools,status,last_seen,followers_count,common_count," +
                                "occupation,nickname,relatives,relation,personal,connections,exports,activities,interests," +
                                "music,movies,tv,books,games,about,quotes,can_post,can_see_all_posts,can_see_audio," +
                                "can_write_private_message,can_send_friend_request,is_favorite,is_hidden_from_feed,timezone," +
                                "screen_name,maiden_name,crop_photo, is_friend,friend_status,career,military,blacklisted," +
                                "blacklisted_by_me,can_be_invited_group" },
                    { "access_token", $"{VkApiSettings.AccessToken}" },
                    { "v", $"{VkApiSettings.Version}" }
                });
            }
            return person[0];
        }
    }
}
