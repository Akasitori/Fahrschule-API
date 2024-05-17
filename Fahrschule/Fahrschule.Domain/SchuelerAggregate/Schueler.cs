using Fahrschule.Domain.Common;
using Fahrschule.Domain.Common.ValueObjects;
using Fahrschule.Domain.SchuelerAggregate.ValueObjects;

namespace Fahrschule.Domain.SchuelerAggregate
{
    public sealed class Schueler : IDomainEntity<Guid>
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Geschlecht Geschlecht { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Adresse Adresse { get; set; }
        public Kontaktdaten Kontaktdaten { get; set; }
        public DateTime DatumDerAnmeldung { get; set; }
        public Status Status { get; set; }
        public string? Fuehrerscheinklasse { get; set; }
        public GetriebeTyp GetriebeTyp { get; set; }
        public Guid? LehrerId { get; set; }

        public Guid Id { get; set; }

        public Schueler() // Für Mapster
        {

        }

        private Schueler(
            Guid id,
            string vorname,
            string nachname,
            Geschlecht geschlecht,
            DateTime geburtsdatum,
            Adresse adresse,
            Kontaktdaten kontaktdaten,
            DateTime datumDerAnmeldung,
            Status status,
            string? fuehrerscheinklasse,
            GetriebeTyp getriebeTyp,
            Guid? lehrerId) 
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Geburtsdatum = geburtsdatum;
            Adresse = adresse;
            Kontaktdaten = kontaktdaten;
            DatumDerAnmeldung = datumDerAnmeldung;
            Status = status;
            Fuehrerscheinklasse = fuehrerscheinklasse;
            GetriebeTyp = getriebeTyp;
            LehrerId = lehrerId;
        }

        public static Schueler Create(
            string vorname,
            string nachname,
            Geschlecht geschlecht,
            DateTime geburtsdatum,
            Adresse adresse,
            Kontaktdaten kontaktdaten,
            DateTime datumDerAnmeldung,
            Status status,
            string? fuehrerscheinklasse,
            GetriebeTyp getriebeTyp,
            Guid? lehrerId
            )
        {
            return new Schueler(
                Guid.NewGuid(),
                vorname,
                nachname,
                geschlecht,
                geburtsdatum,
                adresse,
                kontaktdaten,
                datumDerAnmeldung,
                status,
                fuehrerscheinklasse,
                getriebeTyp,
                lehrerId
                );
        }

        public static Adresse CreateAdresse(
            string strasse, 
            string hausNr, 
            string stadt, 
            string plz
            ) 
        {
            return new Adresse { 
                Strasse= strasse, 
                HausNr = hausNr, 
                Stadt = stadt, 
                Plz = plz 
            };
        }

        public static Kontaktdaten CreateKontaktdaten(string tel, string email) 
        {
            return new Kontaktdaten
            {
                Tel = tel,
                Email = email
            };
        }

        public static Geschlecht CreateGeschlecht(string geschlecht) 
        {
            Geschlecht geschlechter;
            if (Enum.TryParse(geschlecht, out geschlechter)) 
            {
                return geschlechter;
            }

            throw new Exception("Invalid Enum Value for Geschlechter detected");
        }

        public static Status CreateStatus(string status) 
        {
            Status statusPlural;
            if (Enum.TryParse(status, out statusPlural)) 
            {
                return statusPlural;
            }
            throw new Exception("Invalid Enum Value for Status detected");
        }

        public static GetriebeTyp CreateGetriebeTyp(string getriebetyp)
        {
            GetriebeTyp getriebeTypen;
            if (Enum.TryParse(getriebetyp, out getriebeTypen))
            {
                return getriebeTypen;
            }
            throw new Exception("Invalid Enum Value for GetriebeTyp detected");
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

        public void UpdateAdmin(
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

            DateTime datumDerAnmeldung,
            Status status,
            //string fuehrerscheinklassen,
            GetriebeTyp getriebeTyp,

            Guid? lehrerId
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

            DatumDerAnmeldung = datumDerAnmeldung;
            Status = status;

            //Fuehrerscheinklasse = fuehrerscheinklassen;

            GetriebeTyp = getriebeTyp;

            LehrerId = lehrerId;
        }

    }
}
