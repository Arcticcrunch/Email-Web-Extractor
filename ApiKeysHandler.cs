using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Web_Extractor
{
    public static class ApiKeysHandler
    {
        public const string KEYS_FILE_NAME = "API keys.txt";
        public const string LAST_USED_KEY_INDEX_KEY = "LastIndex";

        private static string keysFileFullPath;

        private static ApiKeyPair[] apiKeys;
        private static int currentIndex = 0;
        

        public static bool Init(string directory)
        {
            keysFileFullPath = directory + KEYS_FILE_NAME;

            try
            {
                if (File.Exists(keysFileFullPath) == false)
                {
                    string text =
                        "# В этот файл необходимо записывать API ключи для поиска в Google.\n" +
                        "# Формат записи: [ключ]=[cx]. Каждая пара должна быть с новйо строки.\n" +
                        "# Пример: aE4FdsnbF4i4=Gs4tdTsrYfd";
                    File.WriteAllText(keysFileFullPath, text);
                    return false;
                }

                string fileContent = File.ReadAllText(keysFileFullPath);
                string[] lines = fileContent.Split('\n');
                List<string> keys = new List<string>();
                List<string> cx = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Replace(" ", "");
                    if (line == "")
                        continue;
                    if (line[0] == '#')
                        continue;
                    string[] currentPair = line.Split('=');
                    if (currentPair.Length > 2 || currentPair.Length == 0)
                        continue;
                    if (currentPair[0] == LAST_USED_KEY_INDEX_KEY)
                    {
                        currentIndex = Convert.ToInt32(currentPair[1]);
                    }
                    else
                    {
                        keys.Add(currentPair[0]);
                        cx.Add(currentPair[1]);
                    }
                }

                apiKeys = new ApiKeyPair[keys.Count];
                for (int i = 0; i < apiKeys.Length; i++)
                {
                    ApiKeyPair currentKey = new ApiKeyPair();
                    apiKeys[i] = currentKey;
                    apiKeys[i].key = keys[i];
                    apiKeys[i].cx = cx[i];
                }
                Console.WriteLine("Загружено API ключей: " + apiKeys.Length);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при загрузке файла API ключей" + e.Message);
                return false;
            }
        }

        public static int GetCurrentIndex()
        {
            return currentIndex;
        }

        public static ApiKeyPair GetNextApiKey()
        {
            int nextIndex = currentIndex;
            currentIndex = (currentIndex + 1) % (apiKeys.Length - 1);
            Task t = new Task((Action)(() =>
            {
                try
                {
                    string fileContent = File.ReadAllText(keysFileFullPath);
                    string[] lines = fileContent.Split('\n');
                    StringBuilder sb = new StringBuilder();
                    bool isFound = false;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        if (line.Contains(LAST_USED_KEY_INDEX_KEY))
                        {
                            lines[i] = LAST_USED_KEY_INDEX_KEY + "=" + currentIndex;
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        File.WriteAllLines(keysFileFullPath, lines);
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка при сохранении данных в API файл ");
                }
            }));
            t.Start();
            ApiKeyPair result = apiKeys[nextIndex];
            Console.WriteLine("Пара ключей с индексом" + nextIndex + ": " + result.key + "=" + result.cx);
            return result;
        }

        


        public class ApiKeyPair
        {
            public string key = "";
            public string cx = "";
        }
    }
}
