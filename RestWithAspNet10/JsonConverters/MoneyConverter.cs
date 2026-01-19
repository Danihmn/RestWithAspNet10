using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWithAspNet10.JsonConverters
{
    public class MoneyConverter : JsonConverter<decimal>
    {
        private readonly string _culture;
        private readonly string _format;

        public MoneyConverter() : this("pt-BR", "C")
        {
        }

        public MoneyConverter(string culture, string format)
        {
            _culture = culture;
            _format = format;
        }

        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            return decimal.Parse(value, NumberStyles.Currency, new CultureInfo(_culture));
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format, new CultureInfo(_culture)));
        }
    }
}