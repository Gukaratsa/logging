using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gukaratsa.Extensions.Logging.Tcp
{
    public sealed class TcpLoggerOptions
    {
        [JsonConverter(typeof(IPEndpontConverter))]
        public IPEndPoint ServerEndpoint { get; set; } = 
            IPEndPoint.Parse("127.0.0.1:5001");
    }

    internal sealed class IPEndpontConverter : JsonConverter<IPEndPoint>
    {
        public override IPEndPoint? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var segments = reader.GetString().Split(':');
             return new IPEndPoint(
                        IPAddress.Parse(segments[0]),
                        int.Parse(segments[1]));
        }

        public override void Write(
            Utf8JsonWriter writer,
            IPEndPoint value,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(
                    $"{value.Address}:{value.Port}");
    }
}
