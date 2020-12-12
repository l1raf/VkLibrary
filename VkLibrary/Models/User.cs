using System.Collections.Generic;

namespace VkLibrary.Models
{
    /// <summary>
    /// Базовая информация о пользователе.
    /// </summary>
    public class User
    {
        /// <summary>
        /// url аватарки.
        /// </summary>
        public string AvatarImg { get; set; }

        /// <summary>
        /// Количество подписок.
        /// </summary>
        public int? Following { get; set; }

        /// <summary>
        /// Имя и фамилия пользователя, разделённые пробелом.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус пользователя.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// День рождениия пользователя.
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Количество альбомов пользователя.
        /// </summary>
        public int? AlbumsCount { get; set; }

        /// <summary>
        /// Город, в котором проживает пользователь в настоящее время.
        /// </summary>
        public string CurrentCity { get; set; }

        /// <summary>
        /// Родной город пользователя.
        /// </summary>
        public string Hometown { get; set; }

        /// <summary>
        /// Университет пользователя.
        /// </summary>
        public IEnumerable<string> Universities { get; set; }

        /// <summary>
        /// Количество подарков.
        /// </summary>
        public int? GiftsCount { get; set; }

        /// <summary>
        /// Количество подписок.
        /// </summary>
        public int? FollowingCount { get; set; }

        /// <summary>
        /// Братья и сестры.
        /// Первый параметр - имя, второй - ссылка на страницу.
        /// </summary>
        public Dictionary<string, string> Siblings { get; set; }

        /// <summary>
        /// Школа пользователя.
        /// </summary>
        public IEnumerable<string> Schools { get; set; }

        /// <summary>
        /// Никнейм пользователя в Skype.
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Ссылка на Skype пользователя.
        /// </summary>
        public string SkypeUrl { get; set; }

        /// <summary>
        /// Никнейм пользователя в Facebook.
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// Ссылка на Facebook пользователя.
        /// </summary>
        public string FacebookUrl { get; set; }

        /// <summary>
        /// Никнейм пользователя в Instagram.
        /// </summary>
        public string Instagram { get; set; }

        /// <summary>
        /// Ссылка на Instagram пользователя.
        /// </summary>
        public string InstagramUrl { get; set; }

        /// <summary>
        /// Никнейм пользователя в Twitter.
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// Ссылка на Twitter пользователя.
        /// </summary>
        public string TwitterUrl { get; set; }

        /// <summary>
        /// Станция метро.
        /// </summary>
        public string Station { get; set; }

        /// <summary>
        /// Район, на котором проживает пользователь.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Места работы пользователя.
        /// </summary>
        public IEnumerable<string> Companies { get; set; }

        /// <summary>
        /// Языки.
        /// </summary>
        public IEnumerable<string> Languages { get; set; }

        /// <summary>
        /// Религия пользователя.
        /// </summary>
        public string Religion { get; set; }

        /// <summary>
        /// Главное в жизни.
        /// </summary>
        public string PersonalPriority { get; set; }

        /// <summary>
        /// Главное в людях.
        /// </summary>
        public string ImportantInOthers { get; set; }

        /// <summary>
        /// Отношение пользователя к курению.
        /// </summary>
        public string ViewsOnSmoking { get; set; }

        /// <summary>
        /// Отношение пользователя к алкоголю.
        /// </summary>
        public string ViewsOnAlcohol { get; set; }

        /// <summary>
        /// Короткое имя страницы пользователя.
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// Количество общих друзей.
        /// </summary>
        public int? CommonFriendsCount { get; set; }
    }
}
