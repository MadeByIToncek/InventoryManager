using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.Json;

namespace InventoryManager {
	public partial class ScannerServer {
		WebApplication server;

		public ScannerServer(Action<BinaryEyeResponse> callback) {
			server = WebApplication.Create();
			server.Urls.Add("http://0.0.0.0:5000");
			server.MapPost("/", handler => {
				using (var reader = new StreamReader(handler.Request.Body, true)) {
					// Do something with the value
					string value = reader.ReadToEndAsync().Result;
					BinaryEyeResponse? weatherForecast = JsonSerializer.Deserialize<BinaryEyeResponse>(value);
					callback.Invoke(weatherForecast);
				}
				return handler.Response.WriteAsync("ok!");
			});
			server.RunAsync();
		}

		public void close() {
			server.StopAsync();
		}

	}

	public class BinaryEyeResponse {
		public string content { get; set; }
		public string raw { get; set; }
		public string format { get; set; }
		public string errorCorrectionLevel { get; set; }
		public string version { get; set; }
		public string sequenceSize { get; set; }
		public string sequenceIndex { get; set; }
		public string sequenceId { get; set; }
		public string timestamp { get; set; }
	}
}
