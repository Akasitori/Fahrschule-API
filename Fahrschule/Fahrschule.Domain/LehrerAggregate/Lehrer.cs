using Fahrschule.Domain.Common;
using Fahrschule.Domain.Common.ValueObjects;
using Fahrschule.Domain.LehrerAggregate.ValueObjects;

namespace Fahrschule.Domain.LehrerAggregate
{
    public sealed class Lehrer : IDomainEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Geschlecht Geschlecht { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Adresse Adresse { get; set; }
        public Kontaktdaten Kontaktdaten { get; set; } 
        public List<FuehrerscheinKlasse>? FuehrerscheinKlasse { get; set; }
        public bool ZertifizierterFahrlehrer { get; set; }

        /* Konstroktur */
        public Lehrer() {}
        
        private Lehrer(
            Guid id,
            string vorname,
            string nachname,
            Geschlecht geschlecht,
            DateTime geburtsdatum,
            Adresse adresse,
            Kontaktdaten kontaktdaten,
            List<FuehrerscheinKlasse>? fuehrescheinklasse,
            bool zertifizierterFahrlehrer
        )
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Geburtsdatum = geburtsdatum;
            Adresse = adresse;
            Kontaktdaten = kontaktdaten;
            FuehrerscheinKlasse = fuehrescheinklasse;
            ZertifizierterFahrlehrer = zertifizierterFahrlehrer;
        }

        public static Lehrer Create(
            string vorname,
            string nachname,
            Geschlecht geschlecht,
            DateTime geburtsdatum,
            Adresse adresse,
            Kontaktdaten kontaktdaten,
            List<FuehrerscheinKlasse>? fuehrescheinklasse,
            bool zertifizierterFahrlehrer
        )
        {
            return new Lehrer(
                Guid.NewGuid(),
                vorname,
                nachname,
                geschlecht,
                geburtsdatum,
                adresse,
                kontaktdaten,
                fuehrescheinklasse ?? new(),
                zertifizierterFahrlehrer
            );
        }

        public static Geschlecht CreateGeschlechter(string geschlecht)
        {
            Geschlecht geschlechter;
            if (Enum.TryParse(geschlecht, out geschlechter))
            {
                return geschlechter;
            }

            throw new Exception("Invalid Enum Value for Geschlechter detected");
        }

        public static Adresse CreateAdresse(string strasse, string hausNr, string stadt, string plz)
        {
            return new Adresse
            {
                Strasse = strasse,
                HausNr = hausNr,
                Stadt = stadt,
                Plz = plz
            };
        }

        public static Kontaktdaten CreateKontaktDaten(string tel, string email)
        {
            return new Kontaktdaten
            {
                Tel = tel,
                Email = email,
            };
        }

        public void Update(
            string vorname,
            string nachname,
            string street,
            string hausnr,
            string stadt,
            string plz,
            string tel,
            string email
         )
        {
                Vorname = vorname;
                Nachname = nachname;
                Adresse.Strasse = street;
                Adresse.HausNr = hausnr;
                Adresse.Stadt = stadt;
                Adresse.Plz = plz;
                Kontaktdaten.Tel = tel;
                Kontaktdaten.Email = email;
        }

        public void UpdateByAdmin(
            string vorname,
            string nachname,
            Geschlecht geschlecht,
            DateTime geburtsdatum,

            string street,
            string hausnr,
            string stadt,
            string plz,

            string tel,
            string email,

            //string fuehrerscheinklasse,
            bool zertifizierterFahrlehrer
         )
        {
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Geburtsdatum = geburtsdatum;

            Adresse.Strasse = street;
            Adresse.HausNr = hausnr;
            Adresse.Stadt = stadt;
            Adresse.Plz = plz;

            Kontaktdaten.Tel = tel;
            Kontaktdaten.Email = email;

            ZertifizierterFahrlehrer = zertifizierterFahrlehrer;
        }


    }
}
