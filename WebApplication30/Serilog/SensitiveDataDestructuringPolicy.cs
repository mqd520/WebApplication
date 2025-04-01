using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Serilog.Core;
using Serilog.Events;

namespace WebApplication30.Serilog
{
    public class SensitiveDataDestructuringPolicy : IDestructuringPolicy
    {
        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, [NotNullWhen(true)] out LogEventPropertyValue? result)
        {
            var logEventProperties = new List<LogEventProperty>();
            var props = value.GetType().GetTypeInfo().DeclaredProperties;
            result = new StructureValue(logEventProperties);
            return true;
        }
    }
}
