using log4net.Appender;
using log4net.Core;

namespace WebApplication1.log4net
{
    public class CustomAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            //System.Diagnostics.Debug.WriteLine(loggingEvent.RenderedMessage);
        }
    }
}
