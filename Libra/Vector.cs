using System;

namespace Libra
{
    sealed class Vector<V, S>
    {
        public readonly Scalar<S> Scalar;
        public readonly V Zero;
        public readonly Func<V, V, V> Add;
        public readonly Func<V, V, V> Sub;
        public readonly Func<S, V, V> Mul;
        public readonly Func<V, S, V> Div;
        public readonly Func<V, V, bool> Eq;

        public Vector(Scalar<S> scalar, V zero, Func<V, V, V> add, Func<V, V, V> sub, Func<S, V, V> mul, Func<V, S, V> div, Func<V, V, bool> eq)
        {
            Validation.NotNull(scalar, zero, add, sub, mul, div, eq);
            Scalar = scalar;
            Zero = zero;
            Add = add;
            Sub = sub;
            Mul = mul;
            Div = div;
            Eq = eq;
        }
    }

    static class Vector
    {
        public static Vector<V, S> Of<V, S>(Scalar<S> scalar, V zero, Func<V, V, V> add, Func<V, V, V> sub, Func<S, V, V> mul, Func<V, S, V> div, Func<V, V, bool> eq)
        {
            return new Vector<V, S>(scalar, zero, add, sub, mul, div, eq);
        }

        public static Vector<S, S> FromScalar<S>(Scalar<S> scalar)
        {
            return new Vector<S, S>(
                scalar: scalar,
                zero: scalar.Zero,
                add: scalar.Add,
                sub: scalar.Sub,
                mul: scalar.Mul,
                div: scalar.Div,
                eq: scalar.Eq
            );
        }
    }
}
