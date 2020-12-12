namespace VkLibrary.Models
{
    /// <summary>
    /// Информация о подписках.
    /// </summary>
    public class Following
    {
        /// <summary>
        /// Идентификатор сообщества.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Название сообщества.
        /// </summary>
        public string Name { get; set; }
    }
}
