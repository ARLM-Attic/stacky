using System.Runtime.Serialization;
namespace Stacky
{
    /// <summary>
    /// Specifies the user type.
    /// </summary>
    public enum UserType
    {
        Unregistered,
        Registered,
        Moderator,
        [EnumMember(Value = "does_not_exist")]
        DoesNotExist
    }
}