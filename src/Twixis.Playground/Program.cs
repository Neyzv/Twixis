using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Twixis.Api;
using Twixis.Api.Endpoints;
using Twixis.Api.Enums;
using Twixis.Api.Internal.Http;
using Twixis.Api.Requests.Ads;
using Twixis.Api.Requests.Analytics;
using Twixis.Api.Requests.Bits;
using Twixis.Api.Requests.Channels;

var cancellationTokenSource = new CancellationTokenSource();

var cancellationToken = cancellationTokenSource.Token;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var twitchHttpClientOptions = Options.Create(configuration.GetSection("OAuth").Get<TwitchHttpClientOptions>()!);

var twitchHttpClient = new TwitchHttpClient(new HttpClient(new TwitchHttpClientHandler()) { BaseAddress = new Uri("https://api.twitch.tv/helix/") }, twitchHttpClientOptions);

var twitchApiClient = new TwitchApiClient(twitchHttpClient);

await twitchApiClient
    .Channels
    .ModifyChannelInformationAsync(
        new ModifyChannelInformationRequest(
            "sdf", ContentClassificationLabels: [new ContentClassificationLabel(ContentClassification.Gambling, true)]
            ),
        cancellationToken);

Console.ReadKey();
