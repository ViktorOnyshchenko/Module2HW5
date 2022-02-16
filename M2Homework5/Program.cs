using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace M2Homework5
{
	public static class Program
	{
		public static void Main()
		{
			try
			{
				Starter.Run();
			}
			catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
				Console.ReadKey();
			}
		}
	}
}