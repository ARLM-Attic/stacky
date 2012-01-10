namespace Stacky
{
    using System.Runtime.Serialization;

    public enum InboxItemType
    {
        Comment,
        [EnumMember(Value = "chat_message")]
        ChatMessage,
        [EnumMember(Value = "new_answer")]
        NewAnswer,
        [EnumMember(Value = "careers_message")]
        CareersMessage,
        [EnumMember(Value = "careers_invitations")]
        CareersInvitation,
        [EnumMember(Value = "meta_question")]
        MetaQuestion
    }
}