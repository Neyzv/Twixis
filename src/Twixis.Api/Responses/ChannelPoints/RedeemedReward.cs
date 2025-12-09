// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses.ChannelPoints;

public sealed record RedeemedReward(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("cost")] long Cost
);
