using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrschule.Application.Schuelers.Common.Records
{
    public record Adresse(
        string Strasse,
        string HausNr,
        string Stadt,
        string Plz
        );
}
