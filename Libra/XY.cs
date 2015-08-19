using System;

namespace Libra
{
    public struct XY<S>
    {
        public readonly S X;
        public readonly S Y;

        XY(S x, S y)
        {
            this.X = x;
            this.Y = y;
        }

        public sealed class Ops
        {
            public readonly Scalar<S> Scalar;
            public readonly XY<S> Zero;
            public readonly Func<S, S, XY<S>> New;
            public readonly Func<XY<S>, Func<S, S>, XY<S>> Map;
            public readonly Func<XY<S>, XY<S>, Func<S, S, S>, XY<S>> Map2;
            public readonly Func<XY<S>, XY<S>, XY<S>> Add;
            public readonly Func<XY<S>, XY<S>, XY<S>> Sub;
            public readonly Func<S, XY<S>, XY<S>> Mul;
            public readonly Func<XY<S>, S, XY<S>> Div;
            public readonly Func<XY<S>, XY<S>, bool> Eq;
            public readonly Vector<XY<S>, S> Vector;

            public Ops(Scalar<S> scalar)
            {
                Validation.NotNull(scalar);
                this.Scalar = scalar;
                this.New = (x, y) => new XY<S>(x, y);
                this.Zero = New(scalar.Zero, scalar.Zero);
                this.Map = (v , f) => new XY<S>(f(v.X), f(v.Y));
                this.Map2 = (u, v, f) => new XY<S>(f(u.X, v.X), f(u.Y, v.Y));
                this.Add = (u, v) => Map2(u, v, scalar.Add);
                this.Sub = (u, v) => Map2(u, v, scalar.Sub);
                this.Mul = (a, v) => Map(v, x => scalar.Mul(a, x));
                this.Div = (v, a) => Map(v, x => scalar.Div(x, a));
                this.Eq = (u, v) => scalar.Eq(u.X, v.X) && scalar.Eq(u.Y, v.Y);
                this.Vector = Vector.Of(scalar, Zero, Add, Sub, Mul, Div, Eq);
            }
        }
    }

    public static class XY
    {
        public static XY<S>.Ops Create<S>(Scalar<S> scalar)
        {
            return new XY<S>.Ops(scalar);
        }

        public static XY<int>.Ops Int = Create(Scalar.Int);
        public static XY<long>.Ops Long = Create(Scalar.Long);
        public static XY<float>.Ops Float = Create(Scalar.Float);
        public static XY<double>.Ops Double = Create(Scalar.Double);
        public static XY<decimal>.Ops Decimal = Create(Scalar.Decimal);
    }
}