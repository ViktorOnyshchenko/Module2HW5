using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace M2Homework5
{
	public static class Actions
	{
		private static readonly Logger logger = Logger.getInstance();

		public static void StartMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Info, $"Start method - {nameof(StartMethod)}"));
		}

		public static void SkipMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Warning, $"Skipped logic in method - {nameof(SkipMethod)}"));
			throw new BusinessException("Skipped logic in method");
		}

		public static void BrokeMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Broke method - {nameof(BrokeMethod)}"));
            throw new IOException("I broke a logic");
		}
	}
}
