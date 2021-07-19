using ScalablePress.API.Models;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScalablePress.API.Converters
{
    internal class EnumValueAttributeConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var isEnum = typeToConvert.IsEnum;

            if (isEnum) {
                var jsonConverter = typeToConvert.GetCustomAttribute<JsonConverterAttribute>();

                return jsonConverter != null && jsonConverter.ConverterType == typeof(EnumValueAttributeConverter);
            }

            return false;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converter = new EnumValueConverter();
            return converter;
        }

        class EnumValueConverter : JsonConverter<Enum>
        {
            public override Enum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var memberName = reader.GetString().Replace("-", "_");
                var value = Enum.Parse(typeToConvert, memberName);
                return (Enum)value;
            }

            public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
            {
                var member = value.GetType().GetMember(value.ToString());
                var returnValue = member[0].GetCustomAttribute<EnumValueAttribute>();
                writer.WriteStringValue(returnValue.Value);
            }
        }
    }
}
