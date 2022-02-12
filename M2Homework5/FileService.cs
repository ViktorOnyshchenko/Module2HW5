using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2Homework5
{
    public class FileService
    {
		private readonly string currentDirectory;

		private const string ConfigFileName = "config1.json";
		private readonly Config config;
		public FileService()
        {
			currentDirectory = Directory.GetCurrentDirectory();
			if (!CheckConfigFile())
			{
				throw new ArgumentNullException("Config", "Config file wasn't find!");
			}
			string configFile = File.ReadAllText(ConfigFileName);
			config = JsonConvert.DeserializeObject<Config>(configFile);
		}
		private bool CheckConfigFile()
        {
			string path = String.Join('\\', currentDirectory, ConfigFileName);
			bool isExist = File.Exists(path);
			return isExist;
		}
		private void CreateDirectory()
		{
			string path = String.Join('\\', currentDirectory, config.DirectoryPath);
			DirectoryInfo directoryInfo = new DirectoryInfo(path.ToString());
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
		}
		private void CheckAmountFiles(string fileName)
		{
			string path = String.Join('\\', currentDirectory, config.DirectoryPath);
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			int amountFiles = directoryInfo.GetFiles().Length;
			if(amountFiles == 3)
            {
				FileInfo myFile = directoryInfo.GetFiles()
								.OrderBy(f => f.LastWriteTime)
								.First();
				myFile.Delete();
			}
		}
		public void FilePrint(Log[] logs)
		{
			string fileName = String.Join("", config.DirectoryPath, DateTime.Now.ToString(config.TimeFormat), config.FileExtension);
			CreateDirectory();
			CheckAmountFiles(fileName);

            using (FileStream fstream = new FileStream(fileName, FileMode.Create))
            {
                StringBuilder textLogs = new StringBuilder();
                foreach (var log in logs)
                {
                    if (log == null)
                    {
                        break;
                    }
                    textLogs.Append($"{log.ToString()}\n");
                }
                byte[] array = Encoding.Default.GetBytes(textLogs.ToString());
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Logs wrote in the file!");
            }
        }
	}
}
