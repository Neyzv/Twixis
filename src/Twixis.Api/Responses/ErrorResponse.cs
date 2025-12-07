// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Net;
using System.Text.Json.Serialization;

namespace Twixis.Api.Responses;

public sealed record ErrorResponse(
    [property: JsonPropertyName("error")] string Error,
    [property: JsonPropertyName("status"), JsonConverter(typeof(JsonNumberEnumConverter<HttpStatusCode>))] HttpStatusCode Status,
    [property: JsonPropertyName("message")] string Message
);
