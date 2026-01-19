using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.JsonConverters
{
    public class GenderConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            reader.GetString();

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            string formated = value == "Male" ? "M" : "F";
            writer.WriteStringValue(formated);
        }
    }
}