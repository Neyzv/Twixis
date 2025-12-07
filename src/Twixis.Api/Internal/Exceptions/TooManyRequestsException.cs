// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Net;

namespace Twixis.Api.Internal.Exceptions;

public sealed class TooManyRequestsException : HttpResponseException
{
    public DateTime RateLimitReset { get; }

    public TooManyRequestsException(string error, string message, int rateLimitReset) : base(error, message, HttpStatusCode.TooManyRequests)
    {
        RateLimitReset = DateTimeOffset.FromUnixTimeSeconds(rateLimitReset).LocalDateTime;
    }
}
