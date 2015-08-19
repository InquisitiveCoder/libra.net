using System;

namespace Libra
{
    struct Quantity<U, V>
    {
        public readonly V Value;

        Quantity(V value)
        {
            this.Value = value;
        }

        public sealed class Ops<S>
        {
            public readonly Vector<V, S> Vector;
            public readonly Func<V, Quantity<U, V>> New;
            public readonly Func<Quantity<U, V>, Quantity<U, V>, Quantity<U, V>> Add;

            public Ops(U unit, Vector<V, S> vector)
            {
                Validation.NotNull(unit, vector);
                Vector = vector;
                New = v => new Quantity<U, V>(v);
                Add = (u, v) => new Quantity<U, V>(Vector.Add(u.Value, v.Value));
            }
        }
    }

    static class Quantities
    {
        public static Quantity<U, S>.Ops<S> Create<U, S>(U unit, Scalar<S> scalar)
        {
            return Create<U, S, S>(unit, Vector.FromScalar(scalar));
        }

        public static Quantity<U, V>.Ops<S> Create<U, V, S>(U unit, Vector<V, S> vector)
        {
            return new Quantity<U, V>.Ops<S>(unit, vector);
        }
    }
}
