using System;

namespace VkLibrary.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при двухфакторной аутентификации.
    /// </summary>
    [Serializable]
    public class TwoFactorAuthException : Exception
    {
        /// <summary>
        /// Исключение, возникающее при двухфакторной аутентификации.
        /// </summary>
        public TwoFactorAuthException() { }

        /// <summary>
        /// Исключение, возникающее при двухфакторной аутентификации.
        /// </summary>
        public TwoFactorAuthException(string message) : base(message) { }

        /// <summary>
        /// Исключение, возникающее при двухфакторной аутентификации.
        /// </summary>
        public TwoFactorAuthException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Исключение, возникающее при двухфакторной аутентификации.
        /// </summary>
        protected TwoFactorAuthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
