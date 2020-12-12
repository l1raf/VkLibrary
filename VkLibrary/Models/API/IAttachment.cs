using VkLibrary.Enums;

namespace VkLibrary.Models.API
{
    /// <summary>
    /// Медиавложения в записях на стене
    /// </summary>
    public interface IAttachment
    {
        /// <summary>
        /// Тип вложения.
        /// </summary>
        AttachmentType Type { get; }
    }
}
