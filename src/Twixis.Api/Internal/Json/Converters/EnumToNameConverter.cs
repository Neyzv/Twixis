// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Twixis.Api.Internal.Json.Converters;

public sealed class EnumToNameConverter<TEnum>
    : JsonConverter<TEnum>
    where TEnum : struct, Enum
{
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var name = reader.GetString();

        return Enum.TryParse(name, ignoreCase: true, out TEnum result) ? result : throw new JsonException($"Invalid enum name '{name}' for {typeof(TEnum).Name}");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
