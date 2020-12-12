using System;

namespace VkLibrary.Exceptions
{
    /// <summary>
    /// Общее исключение.
    /// </summary>
    [Serializable]
    public class VkLibraryException : Exception
    {
        /// <summary>
        /// Общее исключение.
        /// </summary>
        public VkLibraryException() { }

        /// <summary>
        /// Общее исключение.
        /// </summary>
        public VkLibraryException(string message) : base(message) { }

        /// <summary>
        /// Общее исключение.
        /// </summary>
        public VkLibraryException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Общее исключение.
        /// </summary>
        protected VkLibraryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
