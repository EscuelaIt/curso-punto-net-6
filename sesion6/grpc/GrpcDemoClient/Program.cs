using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;


using var channel = GrpcChannel.ForAddress("https://localhost:5005");
var client = new WeatherForecast.WeatherForecasts.WeatherForecastsClient(channel);

var response = await client.GetWeatherAsync(new Empty());

foreach (var forecast in response.WeatherData) {
    Console.WriteLine($"{forecast.DateTimestamp.ToDateTime():s} | {forecast.Summary} | {forecast.TemperatureC} C");
}

Console.WriteLine("Done");
Console.ReadLine();
Console.WriteLine("========================= STREAMING ===================");

var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

using var replies = client.GetWeatherStream(new Empty(), cancellationToken: cts.Token);

try {
    await foreach (var weatherData in replies.ResponseStream.ReadAllAsync(cancellationToken: cts.Token))
        {
            Console.WriteLine($"{weatherData.DateTimestamp.ToDateTime():s} | {weatherData.Summary} | {weatherData.TemperatureC} C");
        }
} catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
{
    Console.WriteLine("Stream cancelled.");
}

Console.WriteLine("Done!!!!");



Console.ReadLine();
