namespace CustomJSONConvertersExample.Vehicles.Electric
{
    /// <summary>
    /// This class represents an electric bike.
    /// Implements the <see cref="IElectric"/> interface.
    /// <br></br>
    /// <br></br>
    /// See also:
    /// <br></br>
    /// <seealso cref="ElectricBike"/>
    /// </summary>
    internal class ElectricCar : Car, IElectric
    {
        private ElectricCapacity _batteryCapacity;

        /// <summary>
        /// The smallest possible capacity of battery in <see cref="ElectricCar"/>.
        /// </summary>
        private static readonly ElectricCapacity _minCapacity = new ElectricCapacity(25);

        /// <summary>
        /// Battery capacity of <see cref="ElectricCar"/>.
        /// <br></br>
        /// Must be more or equal to <see cref="_minCapacity"/>.
        /// <br></br>
        /// <see cref="InvalidDataException"/> is thrown otherwise.
        /// </summary>
        public ElectricCapacity BatteryCapacity
        {
            get => _batteryCapacity;
            set
            {
                if (value.Value < _minCapacity.Value)
                {
                    throw new InvalidDataException($"Electric cars can't have less than {_minCapacity} of battery capacity.");
                }

                _batteryCapacity = value;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ElectricCar"/> with some number of <paramref name="doors"/> and <paramref name="batteryCapacity"/> value.
        /// </summary>
        /// <param name="doors">
        /// A number of doors in <see cref="ElectricCar"/>.
        /// Must be either <b>2</b> or <b>4</b>.
        /// <br></br>
        /// <br></br>
        /// See
        /// <see cref="Doors"/> for more information.
        /// </param>
        /// <param name="batteryCapacity">A decimal value of electric capacity for battery.</param>
        public ElectricCar(int doors, decimal batteryCapacity) : base(doors)
        {
            BatteryCapacity = new ElectricCapacity(batteryCapacity);
        }

        /// <summary>
        /// Creates a new <see cref="ElectricCar"/> with <paramref name="batteryCapacity"/> value.
        /// </summary>
        /// <param name="batteryCapacity">A decimal value of electric capacity for battery.</param>
        public ElectricCar(decimal batteryCapacity) : base()
        {
            BatteryCapacity = new ElectricCapacity(batteryCapacity);
        }
    }
}
