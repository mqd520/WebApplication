using log4net.Layout;

namespace WebApplication1.log4net
{
    public class AppenderParameter
    {
        public string ParameterName { get; set; } = string.Empty;

        public IRawLayout Layout { get; set; } = default!; // Use default! to suppress the warning
    }
}
