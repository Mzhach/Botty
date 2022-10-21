namespace Botty.Telegram.Abstractions.Enums
{
    /// <summary>
    /// Type of update
    /// </summary>
    public enum UpdateType
    {
        Message,
        EditedMessage,
        ChannelPost,
        EditedChannelPost,
        InlineQuery,
        ChosenInlineResult,
        CallbackQuery,
        ShippingQuery,
        PreCheckoutQuery,
        Poll,
        PollAnswer,
        MyChatMember,
        ChatMember,
        ChatJoinRequest
    }
}
