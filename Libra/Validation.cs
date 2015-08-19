using System;
using System.Linq;

namespace Libra
{
    static class Validation
    {
        public static void NotNull(params object[] args)
        {
            if (args.Any(x => x == null))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
