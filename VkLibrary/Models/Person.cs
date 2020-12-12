namespace VkLibrary.Models
{
    /// <summary>
    /// Информация о пользователе.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Короткое имя страницы.
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на фото профиля.
        /// </summary>
        public string ProfileUrl { get; set; }
    }
}
