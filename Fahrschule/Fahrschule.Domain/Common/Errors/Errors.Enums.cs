using ErrorOr;
namespace Fahrschule.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Enums
        {
            public static Error InvalidEnumValue => Error.Validation(
                code: "Enums.InvalidEnumValue",
                description: "Invalid enum value detected");
        }
    }
}
