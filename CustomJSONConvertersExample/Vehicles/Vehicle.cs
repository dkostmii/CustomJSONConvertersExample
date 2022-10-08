namespace CustomJSONConvertersExample.Vehicles
{
    /// <summary>
    /// An abstract class, which represents some vehicle.
    /// </summary>
    internal abstract class Vehicle
    {
        /// <summary>
        /// A number of wheels in <see cref="Vehicle"/>.
        /// </summary>
        public int Wheels { get; protected set; }
    }
}
