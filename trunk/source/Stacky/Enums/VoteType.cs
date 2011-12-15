namespace Stacky
{
    using System.Runtime.Serialization;

    public enum VoteType
    {
        Accepts,
        [EnumMember(Value = "up_votes")]
        UpVotes,
        [EnumMember(Value = "down_votes")]
        DownVotes,
        [EnumMember(Value = "bounties_offered")]
        BountiesOffered,
        [EnumMember(Value = "bounties_won")]
        BountiesWon,
        Spam,
        [EnumMember(Value = "suggested_edits")]
        SuggestedEdits
    }
}