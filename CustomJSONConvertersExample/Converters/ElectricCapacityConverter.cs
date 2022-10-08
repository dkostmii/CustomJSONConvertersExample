using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CustomJSONConvertersExample.Converters
{
    /// <summary>
    /// A <see cref="JsonConverter"/> for <see cref="ElectricCapacity"/>.
    /// </summary>
    internal class ElectricCapacityConverter : JsonConverter<ElectricCapacity>
    {
        public override ElectricCapacity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var pattern = new Regex(@"\d+(\.?\d{0,}) kWh");

            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read ElectricCapacity. Unknown JSON token.");

            var strValue = reader.GetString();

            if (!pattern.IsMatch(strValue!))
                throw new JsonException($"Invalid format for ElectricCapacity: {strValue}");

            var value = decimal.Parse(strValue!.Split(" ")[0]);

            return new ElectricCapacity(value);
        }

        public override void Write(Utf8JsonWriter writer, ElectricCapacity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
