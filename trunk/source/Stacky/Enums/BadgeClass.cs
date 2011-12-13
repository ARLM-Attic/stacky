using System.Runtime.Serialization;
namespace Stacky
{
    /// <summary>
    /// Specifies the badge type.
    /// </summary>
    public enum BadgeClass
    {
        /// <summary>
        /// Gold badge.
        /// </summary>
        Gold,
        /// <summary>
        /// Silver badge.
        /// </summary>
        Silver,
        /// <summary>
        /// Bronze badge.
        /// </summary>
        Bronze
    }

    public enum BadgeType
    {
        Named,
		[EnumMember(Value = "tag_based")]
        TagBased
    }
}