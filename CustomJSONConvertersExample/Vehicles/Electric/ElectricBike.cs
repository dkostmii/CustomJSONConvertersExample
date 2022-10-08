namespace CustomJSONConvertersExample.Vehicles.Electric
{
    /// <summary>
    /// This class represents an electric car.
    /// Implements the <see cref="IElectric"/> interface.
    /// <br></br>
    /// <br></br>
    /// See also:
    /// <br></br>
    /// <seealso cref="ElectricCar"/>
    /// </summary>
    internal class ElectricBike : Bike, IElectric
    {
        private ElectricCapacity _batteryCapacity;

        /// <summary>
        /// The largest possible capacity of battery in <see cref="ElectricBike"/>.
        /// </summary>
        private static readonly ElectricCapacity _maxCapacity = new ElectricCapacity(7.5m);

        /// <summary>
        /// Battery capacity of <see cref="ElectricBike"/>.
        /// <br></br>
        /// Must be less or equal to <see cref="_maxCapacity"/>.
        /// <br></br>
        /// <see cref="InvalidDataException"/> is thrown otherwise.
        /// </summary>
        public ElectricCapacity BatteryCapacity
        {
            get => _batteryCapacity;
            set
            {
                if (value.Value > _maxCapacity.Value)
                {
                    throw new InvalidDataException($"Electric bike can't have more than {_maxCapacity} of battery capacity.");
                }

                _batteryCapacity = value;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ElectricBike"/> with <paramref name="batteryCapacity"/> value.
        /// </summary>
        /// <param name="batteryCapacity">A decimal value of electric capacity for battery.</param>
        public ElectricBike(decimal batteryCapacity) : base(BikeType.Road)
        {
            _batteryCapacity = new ElectricCapacity(batteryCapacity);
        }
    }
}
