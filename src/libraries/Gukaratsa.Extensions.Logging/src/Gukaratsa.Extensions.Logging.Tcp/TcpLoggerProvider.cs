using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace Gukaratsa.Extensions.Logging.Tcp;

[UnsupportedOSPlatform("browser")]
[ProviderAlias("Tcp")]
public sealed class TcpLoggerProvider : ILoggerProvider, ISupportExternalScope
{
    private readonly IOptionsMonitor<TcpLoggerOptions> _options;
    private readonly ConcurrentDictionary<string, TcpLogger> _loggers;
    private ConcurrentDictionary<string, TcpLoggerFormatter> _formatters;
    private readonly TcpLoggerProcessor _messageQueue;

    private IDisposable? _optionsReloadToken;
    //private IExternalScopeProvider _scopeProvider = NullExternalScopeProvider.Instance;

    public TcpLoggerProvider(IOptionsMonitor<TcpLoggerOptions> options)
           : this(options, Array.Empty<TcpLoggerFormatter>()) { }

    public TcpLoggerProvider(
        IOptionsMonitor<TcpLoggerOptions> options, 
        IEnumerable<TcpLoggerFormatter>? formatters)
    {
        _options = options;
        _loggers = new ConcurrentDictionary<string, TcpLogger>();
        _messageQueue = new TcpLoggerProcessor();
    }

    public ILogger CreateLogger(string categoryName)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void SetScopeProvider(IExternalScopeProvider scopeProvider)
    {
        throw new NotImplementedException();
    }
}
