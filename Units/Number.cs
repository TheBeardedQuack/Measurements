using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TBQ.Measurements
{
    static class Number
    {
        public static (double Value, string Remainder) Parse(string value)
        {
            value = (value ?? string.Empty).Trim();
            var result = RegexParseDouble.Match(value);
            if(result.Success)
            {
                return (double.Parse(value.Substring(0, result.Length)), value.Substring(result.Length));
            }
            throw new FormatException("Value cannot be parsed as a floating point number.");
        }

        private static Regex RegexParseDouble
        {
            get => new Regex(
                @"^[-+]?(\d+" +
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator +
                @"\d+)*\d*(" +
                Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator +
                @")?\d+([eE][-+]?\d+)?");
        }

    }
}
