using System.Runtime.Serialization;

namespace System
{
    [DataContract]
    public sealed class TriState
    {
        public TriState(
            string state)
        {
            State = state;
        }

        public static TriState False { get; } = new TriState("False");

        public static TriState Indeterminate { get; } = new TriState("Indeterminate");

        [DataMember(Order = 0)]
        public string State { get; }

        public static TriState True { get; } = new TriState("True");

        public static bool operator !=(
            TriState a,
            TriState b)
        {
            return !(a == b);
        }

        public static bool operator ==(
            TriState a,
            TriState b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        public override bool Equals(
            object obj)
        {
            return
                ReferenceEquals(this, obj) ||
                obj is TriState other &&
                GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(State);
        }
    }
}