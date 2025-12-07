// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Net;

namespace Twixis.Api.Internal.Exceptions;

public sealed class ForbiddenException : HttpResponseException
{
    public ForbiddenException(string error, string message) : base(error, message, HttpStatusCode.Forbidden)
    {
    }
}
