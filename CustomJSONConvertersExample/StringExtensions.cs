using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJSONConvertersExample
{
    /// <summary>
    /// Extension methods for <see cref="string"/> type.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Decapitalizes a first character <paramref name="value"/>.
        /// <br></br>
        /// <br></br>
        /// Does not change any other character in sequence.
        /// <br></br>
        /// <br></br>
        /// Example: if <paramref name="value"/> is <c>"Hello, World!"</c>,
        /// then result will be <c>"hello, World!"</c>.
        /// </summary>
        /// <param name="value">Any string.</param>
        /// <returns>
        /// A string with first character in lower case.
        /// </returns>
        public static string Decapitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return $"{value[..1].ToLower()}{value[1..]}";
        }

        /// <summary>
        /// Capitalizes a first character <paramref name="value"/>.
        /// <br></br>
        /// <br></br>
        /// Does not change any other character in sequence.
        /// <br></br>
        /// <br></br>
        /// Example: if <paramref name="value"/> is <c>"myHelloWorldVar"</c>,
        /// then result will be <c>"MyHelloWorldVar"</c>.
        /// </summary>
        /// <param name="value">Any string.</param>
        /// <returns>
        /// A string with first character in upper case.
        /// </returns>
        public static string Capitalize(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return $"{value[..1].ToUpper()}{value[1..]}";
        }
    }
}
