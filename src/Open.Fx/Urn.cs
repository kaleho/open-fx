using System.Linq;

namespace System
{
    public class Urn
    {
        private Urn()
        {
        }

        public static UrnSegment New()
        {
            return new UrnSegment(null, "urn");
        }

        public static UrnSegment With(
            params string[] parts)
        {
            return
                parts.Aggregate(
                    New(),
                    (current, part) =>
                        new UrnSegment(current, part));
        }
    }
}