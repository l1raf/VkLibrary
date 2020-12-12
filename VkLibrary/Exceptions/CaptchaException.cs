using System;

namespace VkLibrary.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при появлении капчи.
    /// </summary>
    [Serializable]
    public class CaptchaException : Exception
    {
        /// <summary>
        /// Исключение, возникающее при появлении капчи.
        /// </summary>
        public CaptchaException() { }

        /// <summary>
        /// Исключение, возникающее при появлении капчи.
        /// </summary>
        public CaptchaException(string message) : base(message) { }

        /// <summary>
        /// Исключение, возникающее при появлении капчи.
        /// </summary>
        public CaptchaException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Исключение, возникающее при появлении капчи.
        /// </summary>
        protected CaptchaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
