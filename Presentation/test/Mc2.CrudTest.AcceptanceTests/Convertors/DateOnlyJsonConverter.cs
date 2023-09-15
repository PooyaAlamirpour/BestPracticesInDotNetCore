using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mc2.CrudTest.AcceptanceTests.Convertors;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "M/d/yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}