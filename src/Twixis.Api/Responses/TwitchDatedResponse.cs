// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Responses.Analytics;

namespace Twixis.Api.Responses;

public sealed record TwitchDatedResponse<TData>(
    TData[] Data,
    [property: JsonPropertyName("date_range")] DateRange DateRange,
    [property: JsonPropertyName("total")] int Total
) : TwitchResponse<TData>(Data)
    where TData : class;
