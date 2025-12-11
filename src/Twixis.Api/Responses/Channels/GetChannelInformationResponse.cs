// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses.Channels;

public sealed record GetChannelInformationResponse(
    [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
    [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
    [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
    [property: JsonPropertyName("broadcaster_language")] string BroadcasterLanguage,
    [property: JsonPropertyName("game_name")] string GameName,
    [property: JsonPropertyName("game_id")] string GameId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("delay")] uint Delay,
    [property: JsonPropertyName("tags")] string[] Tags,
    [property: JsonPropertyName("content_classification_labels")] string[] ContentClassificationLabels,
    [property: JsonPropertyName("is_branded_content")] bool IsBrandedContent
);
