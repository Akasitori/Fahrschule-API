using Fahrschule.Domain.Common;
using Fahrschule.Domain.TerminAggregate.ValueObjects;

namespace Fahrschule.Domain.TerminAggregate
{
    public class Termin : IDomainEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public int TerminDauerInMinuten => BerechneTerminDauerInMinuten(Beginn, Ende);
        public Guid SchuelerId { get; set; }
        public Guid LehrerId { get; set; }
        public UebungsTyp UebungsTyp { get; set; }
        public TerminStatus TerminStatus { get; set; }

        //Delete and check if mapper uses param ctor when its public
        public Termin()
        {
            
        }

        private Termin(
            DateTime beginn,
            DateTime ende,
            Guid schuelerId,
            Guid lehrerId,
            UebungsTyp uebungsTyp,
            TerminStatus terminStatus
            ) 
        {
            Id = Guid.NewGuid();
            Beginn = beginn;
            Ende = ende;
            SchuelerId = schuelerId;
            LehrerId = lehrerId;
            UebungsTyp = uebungsTyp;
            TerminStatus = terminStatus;
        }

        public static Termin CreateNew(
            DateTime beginn,
            DateTime ende,
            Guid schuelerId,
            Guid lehrerId,
            UebungsTyp uebungsTyp,
            TerminStatus terminStatus)
        {
            return new Termin(
                beginn,
                ende,
                schuelerId,
                lehrerId,
                uebungsTyp,
                terminStatus
                );
        }

        public static UebungsTyp CreateUebungsTyp(string uebungsTyp)
        {
            UebungsTyp uebungsTypParseResult;
            if (Enum.TryParse(uebungsTyp, out uebungsTypParseResult))
            {
                return uebungsTypParseResult;
            }
            throw new Exception("Invalid Enum Value for UebungsTyp detected");
        }

        public static TerminStatus CreateTerminStatus(string terminStatus)
        {
            TerminStatus terminStatusParseResult;
            if (Enum.TryParse(terminStatus, out terminStatusParseResult))
            {
                return terminStatusParseResult;
            }
            throw new Exception("Invalid Enum Value for TerminStatus detected");
        }

        private int BerechneTerminDauerInMinuten(DateTime beginn, DateTime ende) 
        {
            if (beginn < ende)
            {
                var terminDauerTimeSpan = (ende.Subtract(beginn));

                //TODO: double check calculation and int rounding
                var dauerInMinuten = (int)terminDauerTimeSpan.TotalMinutes;
                return dauerInMinuten;
            }
            return 0;
        }
    }
}
