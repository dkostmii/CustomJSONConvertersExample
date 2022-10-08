using CustomJSONConvertersExample.Vehicles.Electric;
using CustomJSONConvertersExample.Vehicles;
using System.Text.Json;
using CustomJSONConvertersExample.Converters;

var vehicles = new List<Vehicle>
{
    new ElectricBike(batteryCapacity: 5),
    new ElectricCar(batteryCapacity: 75),
    new Car(doors: 2),
    new Car(doors: 4),
    new Bike(BikeType.BMX),
};

var opts = new JsonSerializerOptions()
{
    WriteIndented = true
};

Console.WriteLine("Serializing wihtout converters...");
Console.Write(JsonSerializer.Serialize(vehicles, opts));

var optsConverters = new JsonSerializerOptions()
{
    WriteIndented = true
};

optsConverters.Converters.Add(new ElectricCapacityConverter());
optsConverters.Converters.Add(new VehicleConverter());

Console.WriteLine("Serializing with converters...");
Console.Write(JsonSerializer.Serialize(vehicles, optsConverters));
