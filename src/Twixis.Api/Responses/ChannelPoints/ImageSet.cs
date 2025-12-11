// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses.ChannelPoints;

public sealed record ImageSet(
    [property: JsonPropertyName("url_1x")] string Url1X,
    [property: JsonPropertyName("url_2x")] string Url2X,
    [property: JsonPropertyName("url_4x")] string Url4X
);
