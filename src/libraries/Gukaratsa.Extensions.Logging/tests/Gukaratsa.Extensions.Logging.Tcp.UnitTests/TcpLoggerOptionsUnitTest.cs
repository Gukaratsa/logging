using System.Text.Json;

namespace Gukaratsa.Extensions.Logging.Tcp.UnitTests
{
    public class TcpLoggerOptionsUnitTest
    {
        private static string DEFAULT_OPTIONS =
            """{"ServerEndpoint":"127.0.0.1:5001"}""";

        [Fact]
        public void Options_WhenSerializedToJson_ReturnsCorrectString()
        {
            var tcpLoggerOptions = new TcpLoggerOptions();

            var result = JsonSerializer.Serialize(tcpLoggerOptions);
            Assert.Equal(DEFAULT_OPTIONS, result);
        }

        [Fact]
        public void Options_WhenDeserializedFromJson_ReturnsCorrectOptions()
        {
            var result = JsonSerializer.Deserialize<TcpLoggerOptions>(DEFAULT_OPTIONS);
            Assert.NotNull(result);
            Assert.Equal("127.0.0.1", result.ServerEndpoint.Address.ToString());
            Assert.Equal(5001, result.ServerEndpoint.Port);
        }
    }
}