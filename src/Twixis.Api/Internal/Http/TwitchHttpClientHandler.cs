// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;
using Twixis.Api.Internal.Exceptions;
using Twixis.Api.Internal.Json;

namespace Twixis.Api.Internal.Http;

public sealed class TwitchHttpClientHandler : DelegatingHandler
{
    public TwitchHttpClientHandler() : base(new HttpClientHandler())
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            await HandleErrorAsync(response, cancellationToken).ConfigureAwait(false);

        return response;
    }

    [DoesNotReturn]
    private static async Task HandleErrorAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        var error = await response.Content
            .ReadFromJsonAsync(TwitchJsonSerializerContext.Default.ErrorResponse, cancellationToken)
            .ConfigureAwait(false);

        if (error is null)
            throw new HttpResponseException("Unknown error", "An unknown error occurred.", response.StatusCode);

        switch (error.Status)
        {
            case HttpStatusCode.BadRequest:
                throw new BadRequestException(error.Error, error.Message);

            case HttpStatusCode.Unauthorized when response.Headers.WwwAuthenticate.Count is 0:
                throw new BadScopeException(error.Error, error.Message);

            case HttpStatusCode.Unauthorized:
                throw new TokenExpiredException(error.Error, error.Message);

            case HttpStatusCode.NotFound:
                throw new BadResourceException(error.Error, error.Message);

            case HttpStatusCode.TooManyRequests when response.Headers.TryGetValues("RateLimit-Reset", out var resetValues):
                throw new TooManyRequestsException(error.Error, error.Message, int.Parse(resetValues.First()));

            case HttpStatusCode.TooManyRequests:
                throw new TooManyRequestsException(error.Error, error.Message, 0);

            case HttpStatusCode.BadGateway:
                throw new BadGatewayException(error.Error, error.Message);

            case HttpStatusCode.GatewayTimeout:
                throw new GatewayTimeoutException(error.Error, error.Message);

            case HttpStatusCode.InternalServerError:
                throw new InternalServerErrorException(error.Error, error.Message);

            case HttpStatusCode.Forbidden:
                throw new ForbiddenException(error.Error, error.Message);

            default:
                throw new HttpResponseException(error.Error, error.Message, response.StatusCode);
        }
    }
}
