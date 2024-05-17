using ErrorOr;

namespace Fahrschule.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Termin
        {
            public static Error ResourceNotFound => Error.NotFound(
                code: "Termin.ResourceNotFound",
                description: "Could not find a resource with the corresponding id");
        }
    }
}
