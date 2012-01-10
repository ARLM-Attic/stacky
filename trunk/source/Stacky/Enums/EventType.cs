namespace Stacky
{
    using System.Runtime.Serialization;

    public enum EventType
    {
        [EnumMember(Value = "question_posted")]
        QuestionPosted,
        [EnumMember(Value = "answer_posted")]
        AnswerPosted,
        [EnumMember(Value = "comment_posted")]
        CommentPosted,
        [EnumMember(Value = "post_edited")]
        PostEdited,
        [EnumMember(Value = "user_created")]
        UserCreated
    }
}