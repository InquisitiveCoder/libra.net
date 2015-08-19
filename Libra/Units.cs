using System;

namespace Libra
{
    public struct Pixels { }
    public struct Inches { }
    public struct Feet { }
    public struct Kilometers { }
    public struct Meters { }
    public struct Centimeters { }
    public struct Millimeters { }

    static class Units
    {
        public const Pixels Pixels = default(Pixels);
        public const Inches Inches = default(Inches);
        public const Feet Feet = default(Feet);
        public const Kilometers Kilometers = default(Kilometers);
        public const Meters Meters = default(Meters);
        public const Centimeters Centimeters = default(Centimeters);
        public const Millimeters Millimeters = default(Millimeters);
    }
}
