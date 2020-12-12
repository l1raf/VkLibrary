using System.Collections.Generic;
using System.Threading.Tasks;
using VkLibrary.Exceptions;
using VkLibrary.Models.API;
using VkLibrary.Sth;

namespace VkLibrary
{
    /// <summary>
    /// Информация о подписчиках пользователя.
    /// </summary>
    public class VkFollowers
    {
        #region Fields

        private int id;
        private Followers api;

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
        /// Короткое имя страницы пользователя.
        /// </summary>
        public string PageName { get; private set; }

        /// <summary>
        /// Информация о подписчиках пользователя, полученная с использованием API.
        /// </summary>
        public Followers Api
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

        private VkFollowers() { }

        /// <summary>
        /// Создает объект VkFollowers
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkFollowers> CreateAsync(int id)
        {
            var followers = new VkFollowers
            {
                Id = id
            };

            return followers.InitializeAsync(id);
        }

        /// <summary>
        /// Создает объект VkFriends
        /// </summary>
        /// <param name="pageName">короткое имя страницы пользователя</param>
        /// <returns>объект с заполненными свойствами</returns>
        public static Task<VkFollowers> CreateAsync(string pageName)
        {
            var followers = new VkFollowers
            {
                PageName = pageName
            };

            return followers.InitializeAsync(pageName);
        }

        private async Task<VkFollowers> InitializeAsync(int id)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                Api = await RunFollowersAsync(id);
            }

            return this;
        }

        private async Task<VkFollowers> InitializeAsync(string pageName)
        {
            if (!string.IsNullOrEmpty(VkApiSettings.Login)
                && !string.IsNullOrEmpty(VkApiSettings.Password))
            {
                await Authorization.Authorize();
            }

            if (!string.IsNullOrEmpty(VkApiSettings.AccessToken)
                || !string.IsNullOrEmpty(VkApiSettings.ServiceToken))
            {
                var person = await VkPerson.CreateAsync(pageName);
                Id = person.Id;
                Api = await RunFollowersAsync(Id);
            }

            return this;
        }

        private async Task<Followers> RunFollowersAsync<T>(T id)
        {
            if (string.IsNullOrWhiteSpace(VkApiSettings.AccessToken))
            {
                Followers followers = await API.CreateAsync<Followers>("users.getFollowers", new Dictionary<string, string>
                {
                    { "access_token", $"{VkApiSettings.ServiceToken}" },
                    { "user_id", $"{id}" },
                    { "fields", "photo_id,verified,sex,bdate,city,country,home_town,has_photo,photo_50,photo_100," +
                                "photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online,lists," +
                                "domain,has_mobile,contacts,site,education,universities,schools,status,last_seen," +
                                "followers_count,occupation,nickname,relatives,relation,personal,connections," +
                                "exports,wall_comments,activities,interests,music,movies,tv,books,games,about,quotes," +
                                "can_post,can_see_all_posts,can_see_audio,can_write_private_message,can_send_friend_request," +
                                "is_favorite,is_hidden_from_feed,timezone,screen_name,maiden_name,crop_photo,is_friend," +
                                "friend_status,career,military,blacklisted" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "count", "1000" },
                    { "v", $"{VkApiSettings.Version}" }
                });
                return followers;
            }
            else
            {
                Followers followers = await API.CreateAsync<Followers>("users.getFollowers", new Dictionary<string, string>
                {
                    { "access_token", $"{VkApiSettings.AccessToken}" },
                    { "user_id", $"{id}" },
                    { "fields", "photo_id,verified,sex,bdate,city,country,home_town,has_photo,photo_50,photo_100," +
                                "photo_200_orig,photo_200,photo_400_orig,photo_max,photo_max_orig,online,lists," +
                                "domain,has_mobile,contacts,site,education,universities,schools,status,last_seen," +
                                "followers_count,common_count,occupation,nickname,relatives,relation,personal,connections," +
                                "exports,wall_comments,activities,interests,music,movies,tv,books,games,about,quotes," +
                                "can_post,can_see_all_posts,can_see_audio,can_write_private_message,can_send_friend_request," +
                                "is_favorite,is_hidden_from_feed,timezone,screen_name,maiden_name,crop_photo,is_friend," +
                                "friend_status,career,military,blacklisted,blacklisted_by_me" },
                    { "lang", $"{VkApiSettings.Language}" },
                    { "count", "1000" },
                    { "v", $"{VkApiSettings.Version}" }
                });
                return followers;
            }
        }
    }
}
