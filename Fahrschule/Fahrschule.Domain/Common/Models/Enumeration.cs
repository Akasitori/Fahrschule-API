using System.Reflection;

namespace Fahrschule.Domain.Common.Models
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        protected Enumeration(int id, string name) => (Id, Name) = (id, name);
        public override string ToString() => Name;
        public static IEnumerable<T> GetAll <T>() where T : Enumeration =>
            typeof(T).GetFields(
                BindingFlags.Public | 
                BindingFlags.Static |
                BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null)) 
            .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherVale) 
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherVale.Id);

            return typeMatches && valueMatches;

        }

        public int CompareTo(object? other) // why like this ?
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }
    }
}
