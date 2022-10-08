using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJSONConvertersExample
{
    /// <summary>
    /// Custom data type, holding a <see cref="decimal"/> kWh unit of electric capacity.
    /// </summary>
    internal readonly struct ElectricCapacity
    {
        private readonly decimal _value;

        /// <summary>
        /// The <see cref="decimal"/> value of <see cref="ElectricCapacity"/>.
        /// </summary>
        public decimal Value
        {
            get => _value;
        }

        /// <summary>
        /// Creates a <b>0 kWh</b> value.
        /// </summary>
        public ElectricCapacity()
        {
            _value = 0.0m;
        }

        /// <summary>
        /// Creates <b><paramref name="value"/> kWh</b>.
        /// <br></br>
        /// <br></br>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">A <see cref="decimal"/> value in <b>kWh</b> units. Can't be negative.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ElectricCapacity(decimal value)
        {
            if (value < 0.0m)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = decimal.Round(value, 2);
        }

        /// <summary>
        /// Creates <b><paramref name="value"/> kWh</b>.
        /// <br></br>
        /// <br></br>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is negative.
        /// </summary>
        /// <param name="value">A <see cref="int"/> value in <b>kWh</b> units. Can't be negative.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ElectricCapacity(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = decimal.Round(value);
        }

        /// <summary>
        /// A string representation of current <see cref="ElectricCapacity"/> value.
        /// </summary>
        /// <returns>
        /// A string representing a value of <see cref="ElectricCapacity"/>
        /// in human-readable format.
        /// </returns>
        public override string ToString()
        {
            return $"{_value} kWh";
        }
    }
}
