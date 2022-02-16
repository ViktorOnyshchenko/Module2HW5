using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace M2Homework5
{
	public static class Starter
	{
		private const int Counter = 100;
		public static void Run()
		{
            FileService fileService = new FileService();
            Logger logger = Logger.getInstance();
			Random random = new Random();
			int number;
            try
            {
                for (int i = 0; i < Counter; i++)
                {
                    Console.WriteLine($"Current iteretion is {i}");
                    number = random.Next(1, 4);
                    try
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    Actions.StartMethod();
                                    break;
                                }
                            case 2:
                                {
                                    Actions.SkipMethod();
                                    break;
                                }
                            case 3:
                                {
                                    Actions.BrokeMethod();
                                    break;
                                }
                        }
                    }
                    catch (BusinessException ex)
                    {
                        logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Action got this custom Exception: {ex.Message}"));
                    }
                }
            } 
            catch (IOException ex)
            {
                logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Action failed by a reason: {ex}"));
                fileService.FilePrint(logger.Logs);
            }
            Console.ReadKey();
		}
	}
}
