using System.Linq;

namespace System
{
    public class UrnSegment
    {
        private readonly UrnSegment _parent;
        private readonly string _part;
        public static char Separator = ':';

        public UrnSegment(
            UrnSegment parent,
            string part)
        {
            _parent = parent;

            _part =
                !string.IsNullOrWhiteSpace(part) && !part.Contains(Separator)
                    ? part.ToLowerInvariant()
                    : throw new ArgumentException(
                        $"{nameof(part)} is missing or contains the urn separator character [{Separator}].");
        }

        public override string ToString()
        {
            return
                _parent != null
                    ? $"{_parent}{Separator}{_part}"
                    : _part;
        }

        public UrnSegment With(
            params string[] parts)
        {
            return
                parts.Aggregate(
                    this,
                    (current, part) =>
                        new UrnSegment(current, part));
        }
    }
}