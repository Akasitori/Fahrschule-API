using System.Runtime.Serialization;

namespace Fahrschule.Contracts.Termine.CommonResources
{
    public enum UebungsTypResource
    {
        [EnumMember(Value = "Uebungsfahrt")]
        Uebungsfahrt,

        [EnumMember(Value = "Ueberlandstrasse")]
        Ueberlandstrasse,

        [EnumMember(Value = "Autobahn")]
        Autobahn,

        [EnumMember(Value = "Nachtfahrt")]
        Nachtfahrt,

        [EnumMember(Value = "Theoriepruefung")]
        Theoriepruefung,

        [EnumMember(Value = "Fahrpruefung")]
        Fahrpruefung
    }
}