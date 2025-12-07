// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

namespace Twixis.Api.Internal.Http;

public sealed class TwitchHttpClientOptions
{
    public required string ClientId { get; set; }

    public required string AccessToken { get; set; }
}
