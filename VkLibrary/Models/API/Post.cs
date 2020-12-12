using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VkLibrary.Sth;
using VkLibrary.Sth.Converters;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Основная информация о посте со стены пользователя или сообщества.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор поста.
        /// </summary>
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор автора поста.
        /// </summary>
        [DataMember]
        [JsonProperty("from_id")]
        public int FromId { get; set; }

        /// <summary>
        /// Идентификатор владельца стены, на которой размещена запись.
        /// </summary>
        [DataMember]
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Время публикации поста.
        /// </summary>
        [DataMember]
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Был ли пост создан с опцией «Только для друзей».
        /// </summary>
        [DataMember]
        [JsonProperty("friends_only")]
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// Тип записи.
        /// Может принимать следующие значения: post, copy, reply, postpone, suggest.
        /// </summary>
        [DataMember]
        [JsonProperty("post_type")]
        public string PostType { get; set; }

        /// <summary>
        /// Текст записи.
        /// </summary>
        [DataMember]
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Список, содержащий историю репостов для записи. 
        /// Возвращается только в том случае, если запись является репостом.
        /// </summary>
        [DataMember]
        [JsonProperty("copy_history")]
        public List<Post> CopyHistory { get; set; }

        /// <summary>
        /// Информация о комментариях к посту.
        /// </summary>
        [DataMember]
        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        /// <summary>
        /// Информация о лайках к посту.
        /// </summary>
        [DataMember]
        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        /// <summary>
        /// Информация о репостах к посту.
        /// </summary>
        [DataMember]
        [JsonProperty("reposts")]
        public Reposts Reposts { get; set; }

        /// <summary>
        /// Информация о просмотрах поста.
        /// </summary>
        [DataMember]
        [JsonProperty("views")]
        public Views Views { get; set; }

        /// <summary>
        /// Идентификатор владельца поста, в ответ на который был оставлен текущий.
        /// </summary>
        [DataMember]
        [JsonProperty("reply_owner_id")]
        public int ReplyOwnerId { get; set; }

        /// <summary>
        /// Идентификатор поста, в ответ на который был оставлен текущий.
        /// </summary>
        [DataMember]
        [JsonProperty("reply_post_id")]
        public int ReplyPostId { get; set; }

        /// <summary>
        /// Информация о вложениях записи (фотографии ссылки и т.п.).
        /// </summary>
        [DataMember]
        [JsonProperty("attachments")]
        [JsonConverter(typeof(AttachmentJsonConverter))]
        public List<IAttachment> Attachments { get; set; }

        /// <summary>
        /// Закреплен ли пост.
        /// </summary>
        [DataMember]
        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        /// <summary>
        /// Идентификатор автора, если пост был опубликован от имени сообщества и подписан пользователем.
        /// </summary>
        [DataMember]
        [JsonProperty("signer_id")]
        public int SignerId { get; set; }
	}
}
