using System;

namespace VkLibrary.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при авторизации.
    /// </summary>
    [Serializable]
    public class AuthorizationException : Exception
    {
        /// <summary>
        /// Исключение, возникающее при авторизации.
        /// </summary>
        public AuthorizationException() { }

        /// <summary>
        /// Исключение, возникающее при авторизации.
        /// </summary>
        public AuthorizationException(string message) : base(message) { }

        /// <summary>
        /// Исключение, возникающее при авторизации.
        /// </summary>
        public AuthorizationException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Исключение, возникающее при авторизации.
        /// </summary>
        protected AuthorizationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
