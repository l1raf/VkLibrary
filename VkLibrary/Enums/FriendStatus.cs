namespace VkLibrary.Enums
{
    /// <summary>
    /// Статус дружбы с пользователеми.
    /// </summary>
    public enum FriendStatus
    {
        /// <summary>
        /// Не является другом
        /// </summary>
        NotFriend,

        /// <summary>
        /// Отправлена заявка/подписка пользователю.
        /// </summary>
        RequestSent,

        /// <summary>
        /// Имеется входящая заявка/подписка от пользователя.
        /// </summary>
        IncomingRequest,

        /// <summary>
        /// Является другом.
        /// </summary>
        Friend
    }
}
