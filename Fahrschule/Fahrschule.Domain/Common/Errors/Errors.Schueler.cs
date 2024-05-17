using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Schueler
        {
            public static Error ResourceNotFound => Error.NotFound(
                code: "Schueler.ResourceNotFound",
                description: "Could not find a resource with the corresponding id");
        }
    }
}
