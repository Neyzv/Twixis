// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Collections;
using System.Diagnostics;
using System.Text;

namespace Twixis.Api.Internal.Http.Uri;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UrlBuilder
{
    private const char Interrogation = '?';
    private const char Equal = '=';
    private const char Ampersand = '&';

    private readonly StringBuilder _builder;
    private readonly string _baseUrl;

    private UrlBuilder(string baseUrl)
    {
        _builder = new StringBuilder();
        _baseUrl = baseUrl;
    }

    public static UrlBuilder Create(string baseUrl)
    {
        return new UrlBuilder(baseUrl);
    }

    public UrlBuilder AddParameter(string parameter, object? value)
    {
        if (value is null)
            return this;

        _builder
            .Append(_builder.Length is 0 ? Interrogation : Ampersand)
            .Append(parameter)
            .Append(Equal)
            .Append(value);

        return this;
    }

    public UrlBuilder AddParameter(string parameter, IEnumerable? value)
    {
        if (value is null)
            return this;

        foreach (var v in value)
            AddParameter(parameter, v);

        return this;
    }

    public string Build()
    {
        _builder.Insert(0, _baseUrl);

        return _builder.ToString();
    }

    public override string ToString()
    {
        return string.Concat(_baseUrl, _builder);
    }
}
