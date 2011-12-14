namespace Stacky
{
    using System.Runtime.Serialization;

    public enum TimelineType
    {
        Question,
        Answer,
        Comment,
        [EnumMember(Value = "unaccepted_answer")]
        UnacceptedAnswer,
        [EnumMember(Value = "accepted_answer")]
        AcceptedAnswer,
        [EnumMember(Value = "vote_aggregate")]
        VoteAggregate,
        Revision,
        [EnumMember(Value = "post_state_changed")]
        PostStateChanged
    }
}