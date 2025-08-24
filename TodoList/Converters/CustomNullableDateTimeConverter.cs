using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoList.Converters
{
    public class CustomNullableDateTimeConverter : JsonConverter<DateTime?>
    {
        private readonly string _format = "yyyy/MM/dd";
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            if (str == null || !reader.TryGetDateTime(out DateTime date))
            {
                return null;
            }
            else
            {
                return date;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value.ToString(_format));
            }
        }
    }
}
