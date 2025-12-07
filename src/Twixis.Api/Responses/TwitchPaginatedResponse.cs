// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses;

public sealed record TwitchPaginatedResponse<TData>(
    TData[] Data,
    [property: JsonPropertyName("pagination")] TwitchPagination Pagination
) : TwitchResponse<TData>(Data)
    where TData : class;

public sealed record TwitchPagination([property: JsonPropertyName("cursor")] string Cursor);
