namespace CustomJSONConvertersExample.Vehicles
{
    /// <summary>
    /// This class represents a car with doors.
    /// </summary>
    internal class Car : Vehicle
    {
        private int _doors;

        /// <summary>
        /// A number of doors in a Car. Must be either <b>2</b> or <b>4</b>.
        /// <br></br>
        /// <br></br>
        /// <see cref="InvalidDataException"/> is thrown otherwise.
        /// </summary>
        public int Doors
        {
            get => _doors;
            set
            {
                if (value != 2 && value != 4)
                    throw new InvalidDataException("Car should have either 2 or 4 doors.");

                _doors = value;
            }
        }

        /// <summary>
        /// This constructor creates a <see cref="Car"/> with <b>4</b> doors.
        /// </summary>
        public Car() : this(4) { }

        /// <summary>
        /// This constructor creates a <see cref="Car"/> with some number of <paramref name="doors"/>.
        /// </summary>
        /// <param name="doors">
        /// A number of doors in <see cref="Car"/>.
        /// Must be either <b>2</b> or <b>4</b>.
        /// <br></br>
        /// <br></br>
        /// See
        /// <see cref="Doors"/> for more information.
        /// </param>
        public Car(int doors)
        {
            Wheels = 4;
            Doors = doors;
        }
    }
}
