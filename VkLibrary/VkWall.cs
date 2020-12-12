using System.Collections.Generic;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models.API;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Информация о записях со стены пользователя или сообщества.
    /// </summary>
    public class VkWall
    {
        #region Fields

        private Wall api;

        #endregion

        #region Properties

        /// <summary>
        /// Идентификатор пользователя или сообщества.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Короткий адрес пользователя или сообщества.
        /// </summary>
        public string PageName { get; private set; }

        /// <summary>
        /// Информация о записях со стены пользователя или сообщества.
        /// </summary>
        public Wall Api
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

        private VkWall() { }

        /// <summary>
        /// Создает соответствующий объект 
        /// </summary>
        /// <param name="id">идентификатор пользователя или сообщества</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkWall> CreateAsync(int id)
        {
            var wall = new VkWall
            {
                Id = id
            };

            return wall.InitializeAsync(id);
        }

        /// <summary>
        /// Создает соответствующий объект
        /// </summary>
        /// <param name="pageName">короткое имя страницы пользователя или сообщества</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkWall> CreateAsync(string pageName)
        {
            var wall = new VkWall
            {
                PageName = pageName
            };

            return wall.InitializeAsync(pageName);
        }

        private async Task<VkWall> InitializeAsync<T>(T id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                Api = await RunWallAsync(id);
            }

            return this;
        }

        private async Task<Wall> RunWallAsync<T>(T id)
        {
            if (string.IsNullOrEmpty(VkApiSettings.AccessToken))
            {
                Wall wall = await API.CreateAsync<Wall>("wall.get", new Dictionary<string, string>
                {
                    { "access_token", $"{VkApiSettings.ServiceToken}" },
                    { $"{((typeof(T) == typeof(int)) ? "owner_id" : "domain")}", $"{id}" },
                    { "fields", "photo_id,verified,sex,bdate,city,country,home_town,has_photo,photo_50," +
                                "photo_100,photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online," +
                                "domain,has_mobile,contacts,site,education,universities,schools,status,last_seen," +
                                "followers_count,occupation,nickname,relatives,relation,personal,connections,exports," +
                                "activities,interests,music,movies,tv,books,games,about,quotes,is_hidden_from_feed,timezone," +
                                "screen_name,maiden_name,crop_photo,is_friend,friend_status,career,military" },
                    { "count", "100" },
                    { "extended", "1" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "v", $"{VkApiSettings.Version}" }
                });
                return wall;
            }
            else
            {
                Wall wall = await API.CreateAsync<Wall>("wall.get", new Dictionary<string, string>
                {
                    { "access_token", $"{VkApiSettings.AccessToken}" },
                    { $"{((typeof(T) == typeof(int)) ? "owner_id" : "domain")}", $"{id}" },
                    { "fields", "photo_id,verified,sex,bdate,city,country,home_town,has_photo,photo_50,photo_100," +
                                "photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online,domain,has_mobile," +
                                "contacts,site,education,universities,schools,status,last_seen,followers_count,common_count," +
                                "occupation,nickname,relatives,relation,personal,connections,exports,activities,interests," +
                                "music,movies,tv,books,games,about,quotes,can_post,can_see_all_posts,can_see_audio," +
                                "can_write_private_message,can_send_friend_request,is_favorite,is_hidden_from_feed,timezone," +
                                "screen_name,maiden_name,crop_photo,is_friend,friend_status,career,military,blacklisted," +
                                "blacklisted_by_me,can_be_invited_group" },
                    { "count", "100" },
                    { "extended", "1" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "v", $"{VkApiSettings.Version}" }
                });
                return wall;
            }
        }
    }
}
