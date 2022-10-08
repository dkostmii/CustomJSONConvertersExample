using System.Text.Json;
using System.Text.Json.Serialization;

using CustomJSONConvertersExample.Vehicles;
using CustomJSONConvertersExample.Vehicles.Electric;

namespace CustomJSONConvertersExample.Converters
{
    /// <summary>
    /// A <see cref="JsonConverter"/> for <see cref="Vehicle"/>.
    /// </summary>
    internal class VehicleConverter : JsonConverter<Vehicle>
    {
        public override Vehicle? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException($"Expected StartObject token. Got: {reader.TokenType}");

            int wheels = 0;
            int doors = 0;
            var bikeType = BikeType.Road;
            var batteryCapacity = new ElectricCapacity();
            var isElectric = false;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        if (reader.ValueTextEquals("wheels"))
                        {
                            reader.Read();
                            wheels = reader.GetInt32();
                        }
                        else if (reader.ValueTextEquals("doors"))
                        {
                            reader.Read();
                            doors = reader.GetInt32();
                        }
                        else if (reader.ValueTextEquals("bikeType"))
                        {
                            var bt = reader.GetString();
                            switch (bt)
                            {
                                case "BMX":
                                    bikeType = BikeType.BMX;
                                    break;
                                case "Mountain":
                                    bikeType = BikeType.Mountain;
                                    break;
                                case "Road":
                                    bikeType = BikeType.Road;
                                    break;
                                default:
                                    throw new JsonException($"Unknown BikeType {bt}");
                            }
                        }
                        else if (reader.ValueTextEquals("batteryCapacity"))
                        {
                            isElectric = true;
                            batteryCapacity =
                                new ElectricCapacityConverter().Read(ref reader, typeof(ElectricCapacity), options);
                        }
                        break;

                    case JsonTokenType.EndObject:
                        if (wheels == 2)
                        {
                            if (isElectric)
                            {
                                if (doors != 0)
                                    throw new JsonException("Bike can't have doors!");

                                if (bikeType != BikeType.Road)
                                    throw new JsonException("Electric bikes can only be BikeType.Road");

                                return new ElectricBike(batteryCapacity.Value);
                            }

                            return new Bike(bikeType);
                        }
                        else if (wheels == 4)
                        {
                            if (isElectric)
                            {
                                return new ElectricCar(doors, batteryCapacity.Value);
                            }

                            return new Car(doors);
                        }
                        else
                            throw new JsonException($"Could not find a vehicle with {wheels} wheels");
                }
            }

            throw new JsonException("Cannot deserialize JSON.");
        }

        public override void Write(Utf8JsonWriter writer, Vehicle value, JsonSerializerOptions options)
        {
            var typeDiscriminator = value.Wheels;

            var isElectric = value.GetType().IsAssignableTo(typeof(IElectric));

            writer.WriteStartObject();
            writer.WritePropertyName(nameof(value.Wheels).Decapitalize());
            writer.WriteNumberValue(value.Wheels);

            if (typeDiscriminator == 2)
            {
                // It's a Bike
                var bike = (value as Bike)!;
                writer.WritePropertyName(nameof(bike.BikeType).Decapitalize());
                writer.WriteStringValue(bike.BikeType.ToString());

                if (isElectric)
                {
                    // It's electric
                    var eBike = (bike as ElectricBike)!;
                    writer.WritePropertyName(nameof(eBike.BatteryCapacity).Decapitalize());
                    new ElectricCapacityConverter().Write(writer, eBike.BatteryCapacity, options);
                }

                writer.WriteEndObject();
                return;
            }
            else if (typeDiscriminator == 4)
            {
                // It's a Car
                var car = (value as Car)!;

                writer.WritePropertyName(nameof(car.Doors).Decapitalize());
                writer.WriteNumberValue(car.Doors);

                if (isElectric)
                {
                    var eCar = (value as ElectricCar)!;

                    writer.WritePropertyName(nameof(eCar.BatteryCapacity).Decapitalize());
                    new ElectricCapacityConverter().Write(writer, eCar.BatteryCapacity, options);
                }
                writer.WriteEndObject();
                return;
            }


            throw new JsonException("Can't serialize a Vehicle with neither 2 nor 4 wheels.");
        }
    }
}
