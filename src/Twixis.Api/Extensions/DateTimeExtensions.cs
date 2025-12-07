// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Globalization;

namespace Twixis.Api.Extensions;

public static class DateTimeExtensions
{
    public static int ToUnixTimestampSeconds(this DateTime dateTime)
    {
        return (int)new DateTimeOffset(dateTime).ToUnixTimeSeconds();
    }

    public static string ToRfc3339String(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
    }
}
