using System;

namespace Libra
{
    sealed class Scalar<S>
    {
        public readonly S Zero;
        public readonly S One;
        public readonly Func<S, S> Neg;
        public readonly Func<S, S, S> Add;
        public readonly Func<S, S, S> Sub;
        public readonly Func<S, S, S> Mul;
        public readonly Func<S, S, S> Div;
        public readonly Func<S, S, bool> Eq;

        public Scalar(S zero, S one, Func<S, S> neg, Func<S, S, S> add, Func<S, S, S> sub, Func<S, S, S> mul, Func<S, S, S> div, Func<S, S, bool> eq)
        {
            Validation.NotNull(zero, one, neg, add, sub, mul, div, eq);
            Zero = zero;
            One = one;
            Neg = neg;
            Add = add;
            Sub = sub;
            Mul = mul;
            Div = div;
            Eq = eq;
        }
    }

    static class Scalar
    {
        public static Scalar<S> Create<S>(S zero, S one, Func<S, S> neg, Func<S, S, S> add, Func<S, S, S> sub, Func<S, S, S> mul, Func<S, S, S> div, Func<S, S, bool> eq)
        {
            return new Scalar<S>(zero, one, neg, add, sub, mul, div, eq);
        }

        public static const Scalar<int> Int = Create(
            zero: 0,
            one: 1,
            neg: x => -x,
            add: (a, b) => a + b,
            sub: (a, b) => a - b,
            mul: (a, b) => a * b,
            div: (a, b) => a / b,
            eq: (a, b) => a == b
        );

        public static const Scalar<long> Long = Create(
            zero: 0L,
            one: 1L,
            neg: x => -x,
            add: (a, b) => a + b,
            sub: (a, b) => a - b,
            mul: (a, b) => a * b,
            div: (a, b) => a / b,
            eq: (a, b) => a == b
        );

        public static const Scalar<float> Float = Create(
            zero: 0f,
            one: 1f,
            neg: x => -x,
            add: (a, b) => a + b,
            sub: (a, b) => a - b,
            mul: (a, b) => a * b,
            div: (a, b) => a / b,
            eq: (a, b) => a == b
        );

        public static const Scalar<double> Double = Create(
            zero: 0.0,
            one: 1.0,
            neg: x => -x,
            add: (a, b) => a + b,
            sub: (a, b) => a - b,
            mul: (a, b) => a * b,
            div: (a, b) => a / b,
            eq: (a, b) => a == b
        );

        public static const Scalar<decimal> Decimal = Create(
            zero: 0m,
            one: 1m,
            neg: x => -x,
            add: (a, b) => a + b,
            sub: (a, b) => a - b,
            mul: (a, b) => a * b,
            div: (a, b) => a / b,
            eq: (a, b) => a == b
        );
    }
}
