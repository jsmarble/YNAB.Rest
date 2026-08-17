using System;
using Newtonsoft.Json;

namespace YNAB.Rest
{
    /// <inheritdoc />
    public class IsoDateOnlyConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-dd";

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(Format));
        }

        /// <inheritdoc />
        public override DateTime ReadJson(
            JsonReader reader,
            Type objectType,
            DateTime existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return DateTime.ParseExact(
                (string)reader.Value,
                Format,
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
