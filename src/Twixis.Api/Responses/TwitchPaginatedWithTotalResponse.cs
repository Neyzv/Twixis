// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses;

public sealed record TwitchPaginatedWithTotalResponse<TData>(
    TData[] Data,
    TwitchPagination Pagination,
    [property: JsonPropertyName("total")] int Total
) : TwitchPaginatedResponse<TData>(Data, Pagination)
    where TData : class;
