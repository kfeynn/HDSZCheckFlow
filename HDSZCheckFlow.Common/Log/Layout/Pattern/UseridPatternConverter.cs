using System;
using System.IO;

namespace HDSZCheckFlow.Common.Log.Layout.Pattern
{
	/// <summary>
	/// Summary description for UserNamePatternConverter.
	/// </summary>
	internal sealed class UseridPatternConverter : log4net.Layout.Pattern.PatternLayoutConverter
	{
		override protected void Convert(TextWriter writer,  log4net.Core.LoggingEvent loggingEvent)
		{
			Logger log = loggingEvent.MessageObject as Logger;

			if (log != null)
			{
//				writer.Write(log.Userid);
			}
		}
	}
}
