using System;

namespace Rpn
{
    public static class Int32ParserDecorator
    {
        public static int ToInt32(string value)
        {
            if (string.Equals(value, string.Empty) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value), "Value is null or empty.");
            }

            var @base = 10;
            if (value.StartsWith("0b"))
            {
                @base = 2;
            }
            else if (value.StartsWith("0x"))
            {
                @base = 16;
            }

            if (@base != 10)
            {
                value = value.Substring(2);
            }
            return Convert.ToInt32(value, @base);
        }
    }
}
