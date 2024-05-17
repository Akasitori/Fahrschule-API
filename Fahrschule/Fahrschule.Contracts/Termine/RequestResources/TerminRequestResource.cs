using Fahrschule.Contracts.Termine.CommonResources;

namespace Fahrschule.Contracts.Termine.RequestResources
{
    public record TerminRequestResource
    (
        Guid Id,
        DateTime Beginn,
        DateTime Ende,
        Guid SchuelerId,
        Guid LehrerId,
        UebungsTypResource UebungsTyp,
        TerminStatusResource TerminStatus
        );
}
