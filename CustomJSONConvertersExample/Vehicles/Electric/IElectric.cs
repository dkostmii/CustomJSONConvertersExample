namespace CustomJSONConvertersExample.Vehicles.Electric
{
    /// <summary>
    /// This interface represents a some entity with battery capacity.
    /// <br></br>
    /// <br></br>
    /// See also:
    /// <br></br>
    /// <seealso cref="ElectricBike"/>
    /// <br></br>
    /// <seealso cref="ElectricCar"/>
    /// </summary>
    internal interface IElectric
    {
        /// <summary>
        /// A capacity of battery in entity, that implements <see cref="IElectric"/> interface.
        /// </summary>
        public ElectricCapacity BatteryCapacity { get; set; }
    }
}
