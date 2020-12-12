using System;

namespace VkLibrary
{
    /// <summary>
    /// Настройки, которые необходимо установить перед созданием объекта.
    /// </summary>
    public static class VkApiSettings
    {
        /// <summary>
        /// Язык, по умолчанию - русский.
        /// Возможные значения:
        /// ru — русский,
        /// uk — украинский,
        /// be — белорусский,
        /// en — английский,
        /// es — испанский,
        /// fi — финский,
        /// de — немецкий,
        /// it — итальянский.
        /// </summary>
        public static string Language { get; set; } = "ru";

        /// <summary>
        /// Ключ доступа пользователя.
        /// </summary>
        public static string AccessToken { get; set; }

        /// <summary>
        /// Логин для авторизации.
        /// </summary>
        public static string Login { get; set; }

        /// <summary>
        /// Пароль для авторизации.
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// Сервисный ключ доступа.
        /// </summary>
        public static string ServiceToken { get; set; }

        /// <summary>
        /// Идентификатор приложения.
        /// </summary>
        public static long ApplicationId { internal get; set; } = 7197838;

        /// <summary>
        /// Метод для двухфакторной аутентификации.
        /// </summary>
        public static Func<string> Confirmation { get; set; }

        /// <summary>
        /// Метод для распознавания текста капчи.
        /// </summary>
        public static Func<string, string> SolveCaptcha { get; set; }

        /// <summary>
        /// Версия API.
        /// </summary>
        public static string Version { get; } = "5.103";
    }
}
