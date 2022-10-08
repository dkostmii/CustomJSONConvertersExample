namespace CustomJSONConvertersExample.Vehicles
{
    /// <summary>
    /// This class represents a bike of some <see cref="BikeType"/>.
    /// </summary>
    internal class Bike : Vehicle
    {
        public BikeType BikeType { get; set; }

        /// <summary>
        /// Creates a <see cref="BikeType.Road"/> bike.
        /// </summary>
        public Bike() : this(BikeType.Road)
        { }

        /// <summary>
        /// Creates a bike of <paramref name="bikeType"/>.
        /// </summary>
        /// <param name="bikeType">
        /// A type of <see cref="Bike"/>.
        /// <br></br>
        /// <br></br>
        /// For example, <see cref="BikeType.Road"/> or <see cref="BikeType.BMX"/>.
        /// </param>
        public Bike(BikeType bikeType)
        {
            Wheels = 2;
            BikeType = bikeType;
        }
    }
}
