// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Net;

namespace Twixis.Api.Internal.Exceptions;

public class HttpResponseException : Exception
{
    public string Error { get; }

    public HttpStatusCode StatusCode { get; }

    public HttpResponseException(string error, string message, HttpStatusCode statusCode) : base(message)
    {
        Error = error;
        StatusCode = statusCode;
    }
}
