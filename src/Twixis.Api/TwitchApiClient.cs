// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Endpoints;
using Twixis.Api.Internal.Http;

namespace Twixis.Api;

public sealed class TwitchApiClient
{
    public Ads Ads { get; }

    public Analytics Analytics { get; }

    public Bits Bits { get; }

    public TwitchApiClient(TwitchHttpClient http)
    {
        Ads = new Ads(http);
        Analytics = new Analytics(http);
        Bits = new Bits(http);
    }
}
