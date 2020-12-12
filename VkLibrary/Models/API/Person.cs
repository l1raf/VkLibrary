using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о пользователе.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Скрыт ли профиль пользователя настройками приватности.
        /// </summary>
        [DataMember]
        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Может ли текущий пользователь видеть профиль. 
        /// </summary>
        [DataMember]
        [JsonProperty("can_access_closed")]
        public bool CanAccessClosed { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("sex")]
        public Sex Sex { get; set; }

        /// <summary>
        /// Никнейм (отчество) пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Короткий адрес страницы.
        /// </summary>
        [DataMember]
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Короткое имя страницы.
        /// </summary>
        [DataMember]
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("bdate")]
        public string Bdate { get; set; }

        /// <summary>
        /// Информация о городе, указанном на странице пользователя в разделе «Контакты». 
        /// </summary>
        [DataMember]
        [JsonProperty("city")]
        public City City { get; set; }

        /// <summary>
        /// Информация о стране, указанной на странице пользователя в разделе «Контакты». 
        /// </summary>
        [DataMember]
        [JsonProperty("country")]
        public Country Country { get; set; }

        /// <summary>
        /// Строковый идентификатор главной фотографии профиля пользователя в формате {user_id}_{photo_id}.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_id")]
        public string PhotoId { get; set; }

        /// <summary>
        /// Установил ли пользователь фотографию для профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("has_photo")]
        public bool? HasPhoto { get; set; }

        /// <summary>
        /// Известен ли номер мобильного телефона пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("has_mobile")]
        public bool? HasMobile { get; set; }

        /// <summary>
        /// Является ли пользователь другом текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("is_friend")]
        public bool? IsFriend { get; set; }

        /// <summary>
        /// Информация о том, находится ли пользователь сейчас на сайте.
        /// </summary>
        [DataMember]
        [JsonProperty("online")]
        public bool? Online { get; set; }

        /// <summary>
        /// Никнейм пользователя в Facebook.
        /// </summary>
        [DataMember]
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        /// <summary>
        /// Мобильный телефон пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Домашний телефон пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("home_phone")]
        public string HomePhone { get; set; }

        /// <summary>
        /// Никнейм пользователя в Skype.
        /// </summary>
        [DataMember]
        [JsonProperty("skype")]
        public string Skype { get; set; }

        /// <summary>
        /// Имя пользователя в Facebook.
        /// </summary>
        [DataMember]
        [JsonProperty("facebook_name")]
        public string FacebookName { get; set; }

        /// <summary>
        /// Никнейм пользователя в Twitter.
        /// </summary>
        [DataMember]
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Никнейм пользователя в Instagram.
        /// </summary>
        [DataMember]
        [JsonProperty("instagram")]
        public string Instagram { get; set; }

        /// <summary>
        /// Адрес сайта, указанный в профиле.
        /// </summary>
        [DataMember]
        [JsonProperty("site")]
        public string Site { get; set; }

        /// <summary>
        /// Статус пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Время последнего посещения. 
        /// </summary>
        [DataMember]
        [JsonProperty("last_seen")]
        public LastSeen LastSeen { get; set; }

        /// <summary>
        /// Данные о точках, по которым вырезаны профильная и
        /// миниатюрная фотографии пользователя, при наличии.
        /// </summary>
        [DataMember]
        [JsonProperty("crop_photo")]
        public CropPhoto CropPhoto { get; set; }

        /// <summary>
        /// Верифицирована ли страница пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("verified")]
        public bool? Verified { get; set; }

        /// <summary>
        /// Количество подписчиков пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// Скрыт ли пользователь из ленты новостей текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("is_hidden_from_feed")]
        public bool? IsHiddenFromFeed { get; set; }

        /// <summary>
        /// Информация о текущем роде занятия пользователя. 
        /// </summary>
        [DataMember]
        [JsonProperty("occupation")]
        public Occupation Occupation { get; set; }

        /// <summary>
        /// Информация о карьере пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("career")]
        public List<Career> Career { get; set; }

        /// <summary>
        /// Информация о военной службе пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("military")]
        public List<Military> Military { get; set; }

        /// <summary>
        /// Идентификатор ВУЗа, в котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("university")]
        public int University { get; set; }

        /// <summary>
        /// Название ВУЗа, в котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("university_name")]
        public string UniversityName { get; set; }

        /// <summary>
        /// Идентификатор факультета, на котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty")]
        public int Faculty { get; set; }

        /// <summary>
        /// Название факультета, на котором учится пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("faculty_name")]
        public string FacultyName { get; set; }

        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        [DataMember]
        [JsonProperty("graduation")]
        public int Graduation { get; set; }

        /// <summary>
        /// Название родного города пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("home_town")]
        public string HomeTown { get; set; }

        /// <summary>
        /// Информация о полях из раздела «Жизненная позиция».
        /// </summary>
        [DataMember]
        [JsonProperty("personal")]
        public Personal Personal { get; set; }

        /// <summary>
        /// Содержимое поля «Интересы» из профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("interests")]
        public string Interests { get; set; }

        /// <summary>
        /// Содержимое поля «Любимая музыка» из профиля пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("music")]
        public string Music { get; set; }

        /// <summary>
        /// Содержимое поля «Деятельность» из профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("activities")]
        public string Activities { get; set; }

        /// <summary>
        /// Содержимое поля «Любимые фильмы» из профиля пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("movies")]
        public string Movies { get; set; }

        /// <summary>
        /// Содержимое поля «Любимые телешоу» из профиля пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("tv")]
        public string Tv { get; set; }

        /// <summary>
        /// Содержимое поля «Любимые книги» из профиля пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("books")]
        public string Books { get; set; }

        /// <summary>
        /// Содержимое поля «Любимые игры» из профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("games")]
        public string Games { get; set; }

        /// <summary>
        /// Список ВУЗов, в которых учился пользователь. 
        /// </summary>
        [DataMember]
        [JsonProperty("universities")]
        public List<University> Universities { get; set; }

        /// <summary>
        /// Список школ, в которых учился пользователь. 
        /// </summary>
        [DataMember]
        [JsonProperty("schools")]
        public List<School> Schools { get; set; }

        /// <summary>
        /// Содержимое поля «О себе» из профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("about")]
        public string About { get; set; }

        /// <summary>
        /// Содержимое поля «Любимые цитаты» из профиля.
        /// </summary>
        [DataMember]
        [JsonProperty("quotes")]
        public string Quotes { get; set; }

        /// <summary>
        /// Находится ли текущий пользователь в черном списке у запрашиваемого пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("blacklisted")]
        public bool? Blacklisted { get; set; }

        /// <summary>
        /// Находится ли запрашиваемый пользователь в черном списке у текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("blacklisted_by_me")]
        public bool? BlacklistedByMe { get; set; }

        /// <summary>
        /// Может ли оставлять записи на стене у пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("can_post")]
        public bool? CanPost { get; set; }

        /// <summary>
        /// Может ли текущий пользователь видеть чужие записи на стене.
        /// </summary>
        [DataMember]
        [JsonProperty("can_see_all_posts")]
        public bool? CanSeeAllPosts { get; set; }

        /// <summary>
        /// Может ли текущий пользователь видеть аудиозаписи.
        /// </summary>
        [DataMember]
        [JsonProperty("can_see_audio")]
        public bool? CanSeeAudio { get; set; }

        /// <summary>
        /// Будет ли отправлено уведомление пользователю о заявке в друзья.
        /// </summary>
        [DataMember]
        [JsonProperty("can_send_friend_request")]
        public bool? CanSendFriendRequest { get; set; }

        /// <summary>
        /// Может ли текущий пользователь отправить личное сообщение.
        /// </summary>
        [DataMember]
        [JsonProperty("can_write_private_message")]
        public bool? CanWritePrivateMessage { get; set; }

        /// <summary>
        /// Количество общих друзей с текущим пользователем.
        /// </summary>
        [DataMember]
        [JsonProperty("common_count")]
        public int? CommonCount { get; set; }

        /// <summary>
        /// Данные о подключенных сервисах пользователя, таких как: skype, facebook,
        /// twitter, instagram.
        /// </summary>
        /// <remarks>
        /// Есть, судя по всему, только в документации.
        /// </remarks>        
        [DataMember]
        [JsonProperty("connections")]
        public Connections Connections { get; set; }

        /// <summary>
        /// Информация о телефонных номерах пользователя.
        /// </summary>
        /// <remarks>
        /// Есть, судя по всему, только в документации.
        /// </remarks>
        [DataMember]
        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        /// <summary>
        /// Количество различных объектов у пользователя. 
        /// </summary>
        [DataMember]
        [JsonProperty("counters")]
        public Counters Counters { get; set; }

        /// <summary>
        /// Информация о высшем учебном заведении пользователя.
        /// </summary>
        /// <remarks>
        /// Есть, судя по всему, только в документации.
        /// </remarks>
        [DataMember]
        [JsonProperty("education")]
        public Education Education { get; set; }

        /// <summary>
        /// Внешние сервисы, в которые настроен экспорт из ВК.
        /// </summary>
        [DataMember]
        [JsonProperty("exports")]
        public Exports Exports { get; set; }

        /// <summary>
        /// Состояние дружбы с пользователями.
        /// </summary>
        [DataMember]
        [JsonProperty("friend_status")]
        public FriendStatus FriendStatus { get; set; }

        /// <summary>
        /// Находится ли пользователь в закладках у текущего
        /// пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("is_favorite")]
        public bool? IsFavorite { get; set; }

        /// <summary>
        /// Идентификаторы списков друзей, в которых состоит пользователь.
        /// </summary>
        [DataMember]
        [JsonProperty("lists")]
        public List<int> FriendLists { get; set; }

        /// <summary>
        /// Девичья фамилия пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("maiden_name")]
        public string MaidenName { get; set; }

        /// <summary>
        /// url квадратной фотографии пользователя, имеющей ширину 50 пикселей.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_50")]
        public Uri Photo50 { get; set; }

        /// <summary>
        /// url квадратной фотографии пользователя, имеющей ширину 100 пикселей.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_100")]
        public Uri Photo100 { get; set; }

        /// <summary>
        /// url фотографии пользователя, имеющей ширину 200 пикселей.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200_orig")]
        public Uri Photo200Orig { get; set; }

        /// <summary>
        /// url квадратной фотографии пользователя, имеющей ширину 200 пикселей.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_200")]
        public Uri Photo200 { get; set; }

        /// <summary>
        /// url фотографии пользователя, имеющей ширину 400 пикселей.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_400_orig")]
        public Uri Photo400Orig { get; set; }

        /// <summary>
        /// url квадратной фотографии пользователя с максимальной шириной.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_max")]
        public Uri PhotoMax { get; set; }

        /// <summary>
        /// url фотографии пользователя максимального размера.
        /// </summary>
        [DataMember]
        [JsonProperty("photo_max_orig")]
        public Uri PhotoMaxOrig { get; set; }

        /// <summary>
        /// Родственники пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("relatives")]
        public List<Relative> Relatives { get; set; }

        /// <summary>
        /// Семейное положение.
        /// </summary>
        [DataMember]
        [JsonProperty("relation")]
        public Relation Relation { get; set; }

        /// <summary>
        /// Часовой пояс пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        /// <summary>
        /// Находится лм запрашиваемый пользователь в черном списке у текущего пользователя.
        /// </summary>
        [DataMember]
        [JsonProperty("trending")]
        public bool? Trending { get; set; }

        /// <summary>
        /// Доступно ли комментирование стены.
        /// </summary>
        [DataMember]
        [JsonProperty("wall_default")]
        public bool? WallComments { get; set; }
    }
}
