using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace M2Homework5
{
	public class Log
	{
		private readonly DateTime time;
		private readonly LogType type;
		private readonly string message;

		public Log(DateTime time, LogType type, string message)
		{
			this.time = time;
			this.type = type;
			this.message = message;
		}

		public override string ToString()
		{
			return String.Format("{0}: {1}: {2}", time, type, message);
		}
	}
}
