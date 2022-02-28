using Microsoft.Win32;
using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Diagnostics;

namespace Email_Web_Extractor
{
    public partial class MainForm : Form
    {
        public const int MAX_GOOGLE_REQUEST_THREADS = 10;
        public const int MAX_GOOGLE_REQUEST_PAGES_COUNT = 10;

        private static string rootDirectory = "";
        private static string tempFileName = "Web pages list temp.txt";
        private static string fullTempFilePath;
        private static string webAddresesListFileName = "Web-addreses list.txt";
        private static string webAddresesListFilePath;
        private static string emailListFileName = "Emails list temp.txt";
        private static string emailListFilePath;
        //$key = "AIzaSyBAizc5lFHVGWsIF7hWeIRqlUQ1vVAO1WM"; // AIzaSyAS3xsRNoyZDVmZB-rCGMC6_HxeY4MMnKI
        //$cx = "a6e5f637bbb80bcab"; // d23c46183e23f890e
        //$key = "AIzaSyAS3xsRNoyZDVmZB-rCGMC6_HxeY4MMnKI";
        //$cx = "d23c46183e23f890e";
        private static string[] APIkeys = new string[]
        {
            "AIzaSyBAizc5lFHVGWsIF7hWeIRqlUQ1vVAO1WM",
            "AIzaSyAS3xsRNoyZDVmZB-rCGMC6_HxeY4MMnKI"
        };

        private static string[] CXkeys = new string[]
        {
            "d23c46183e23f890e",
            "a6e5f637bbb80bcab"
        };

        // $request = "https://www.googleapis.com/customsearch/v1?key=$key&start=$offset&cx=$cx&q=$url";

        Color normalColor = Color.FromKnownColor(KnownColor.Highlight);
        Color greenColor = Color.FromKnownColor(KnownColor.ForestGreen);
        Color yellowColor = Color.FromArgb(255, 200, 150, 0);
        Color redColor = Color.FromKnownColor(KnownColor.OrangeRed);

        Color disabledTextColor = Color.FromKnownColor(KnownColor.ActiveBorder);
        Color disabledBGColor = Color.FromKnownColor(KnownColor.Control);

        bool isAPIHandlerInit = false;
        //List<Thread> threadsPool = new List<Thread>();
        //int maxThreds = 1;
        Stopwatch googleRequestStopWatch;

        Queue<int> searchOffsetsQueue = new Queue<int>();
        List<SiteEmailRecord[]> siteRecordsList = new List<SiteEmailRecord[]>();

        int currentSearchPages = 10;
        //int currentSearchThreads = 0;

        int currentAvalableThreads = 1;
        int currentActiveThreads = 0;
        bool canDoGoogleRequest = true;

        public event CanDoGoogleRequestChanged CanDoGoogleRequestChangedEvent;
        public event TaskComplited GoogleRequestTaskComplitedEvent;
        public event EmailSearch GoogleSearchStartedEvent;
        public event EmailSearch GoogleSearchEndedEvent;
        public event EmailSearch EmailSearchStartedEvent;
        public event EmailSearch EmailSearchEndedEvent;


        public bool CanDoGoogleRequest
        {
            get
            {
                return canDoGoogleRequest;
            }

            set
            {
                canDoGoogleRequest = value;
                CanDoGoogleRequestChangedEvent?.Invoke(value);
            }
        }





        /// <summary>
        /// Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fullTempFilePath = rootDirectory + tempFileName;
            webAddresesListFilePath = rootDirectory + webAddresesListFileName;
            emailListFilePath = rootDirectory + emailListFileName;

            webPagesTempFilePathTextBox.Text = fullTempFilePath;
            sitesPathFileLabel.Text = webAddresesListFilePath;
            emailsPathFileLabel.Text = emailListFilePath;

            // Получение кол-ва макс потоков
            int cpuCores = GetCPUThreadsCount();
            for (int i = 0; i < cpuCores; i++)
            {
                coresCountComboBox.Items.Add(i + 1);
            }
            coresCountComboBox.SelectedIndex = Clamp(0, cpuCores - 1, cpuCores - 1);

            // Кол-во запрашиваемых страниц Google
            for (int i = 1; i <= MAX_GOOGLE_REQUEST_PAGES_COUNT; i++)
            {
                pagesCountComboBox.Items.Add(i);
            }
            pagesCountComboBox.SelectedIndex = MAX_GOOGLE_REQUEST_PAGES_COUNT - 1;

            CanDoGoogleRequestChangedEvent += OnCanDoGoogleRequestChanged;
            GoogleRequestTaskComplitedEvent += OnGoogleRequestTaskComplited;
            GoogleSearchStartedEvent += OnGoogleSearchStarted;
            GoogleSearchEndedEvent += OnGoogleSearchEnded;

            // Отключить кнопку поиска на старте
            findWebSitesButton.Enabled = false;
            findWebSitesButton.BackColor = disabledBGColor;
            findWebSitesButton.ForeColor = disabledTextColor;


            this.isAPIHandlerInit = ApiKeysHandler.Init(rootDirectory);

            // Обновить состояние кнопок открытия и удаления временного файла
            if (File.Exists(fullTempFilePath) && this.isAPIHandlerInit)
            {
                deleteWebPagesTempFileButton.Enabled = true;
                deleteWebPagesTempFileButton.BackColor = redColor;
                deleteWebPagesTempFileButton.ForeColor = disabledBGColor;

                openWebPagesTempFileButton.Enabled = true;
                openWebPagesTempFileButton.BackColor = normalColor;
                openWebPagesTempFileButton.ForeColor = disabledBGColor;

                // Включить кнопку поиска имейлов
                findEmailsButton.Enabled = true;
                findEmailsButton.ForeColor = disabledBGColor;
                findEmailsButton.BackColor = normalColor;
            }
            else
            {
                deleteWebPagesTempFileButton.Enabled = false;
                deleteWebPagesTempFileButton.BackColor = disabledBGColor;
                deleteWebPagesTempFileButton.ForeColor = disabledTextColor;

                openWebPagesTempFileButton.Enabled = false;
                openWebPagesTempFileButton.BackColor = disabledBGColor;
                openWebPagesTempFileButton.ForeColor = disabledTextColor;

                // Отключить кнопку поиска имейлов
                findEmailsButton.Enabled = false;
                findEmailsButton.ForeColor = disabledTextColor;
                findEmailsButton.BackColor = disabledBGColor;
            }
            

            
            //ToggleFindWebSitesButton(false);
            //try
            //{
            //    string address = "https://cryptocasinos.com/about-us/asdf";
            //    string page = GetWebPageContent(address);
            //    string[] emailsArr = GetEmailsFromText(page);
            //    Console.WriteLine("Найдено имейлов на странице '" + address + "': " + emailsArr.Length);
            //    for (int i = 0; i < emailsArr.Length; i++)
            //    {
            //        Console.WriteLine("-- " + emailsArr[i]);
            //    }
            //}
            //catch (WebException e)
            //{
            //    Console.WriteLine("Ошибка HTTP: " + e.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Ошибка: " + e.Message);
            //}

            //string filePath = rootDirectory + "/" + tempFileName;
            //File.WriteAllText(filePath, page);
            //
            //
            //string regexString = @"[\._a-zA-Z0-9-]+@[\._a-zA-Z0-9-]+\.[\._a-zA-Z0-9-]+";
            //string[] matches = GetRegexFromString(regexString, "CryptoCasinos is an online casino guide that provides all information related to crypto-gambling. 
            // The site was created by a team of crypto enthusiasts with a love for online casinos.
            //Our goal is to provide unbiased reviews and top lists so that players can make an educated choice when it comes to choosing which site to play at.
            // This page aims to help answer questions about who owns the site and how we operate. If you have any questions, feel free to reach out at info@cryptocasinos.com.");

            //Console.WriteLine("TEST REGEX: " + matches.Length);
            //for (int i = 0; i < matches.Length; i++)
            //{
            //    Console.WriteLine("-- " + matches[i]);
            //}

            //this.statusBarText.Text = GetCPUCoresCount().ToString();
        }


        /// <summary>
        /// Получить макс кол-во потоков CPU
        /// </summary>
        /// <returns></returns>
        private int GetCPUThreadsCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// Получить содержимое Web страницы
        /// </summary>
        /// <param name="page">URL-адрес страницы</param>
        /// <returns></returns>
        private string GetWebPageContent(string page)
        {
            StringBuilder sb = new StringBuilder();
            WebClient myClient = new WebClient();
            using (Stream response = myClient.OpenRead(page))
            {
                using (StreamReader sr = new StreamReader(response))
                {
                    while (sr.EndOfStream == false)
                    {
                        sb.Append(sr.ReadLine());
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Получить массив имейлов (string) из строки
        /// </summary>
        /// <param name="text">Строка в которой происходит поиск</param>
        /// <returns></returns>
        private string[] GetEmailsFromText(string text)
        {
            //preg_match_all("/[\._a-zA-Z0-9-]+@[\._a-zA-Z0-9-]+\.[\._a-zA-Z0-9-]+/", $text, $result);
            //preg_match_all("[a-zA-Z0-9_.+-]+@[a-zA-Z-]+\.+[a-zA-Z.-]+", $text, $result);
            string regexStr = @"[\._a-zA-Z0-9-]+@[\._a-zA-Z0-9-]+\.[\._a-zA-Z0-9-]+";
            return GetRegexFromString(regexStr, text);
        }

        /// <summary>
        /// Получить подстроку из строки основываясь на RegEx
        /// </summary>
        /// <param name="regexStr">RegEx выражение</param>
        /// <param name="text">Строка в которой происходит поиск</param>
        /// <returns></returns>
        private string[] GetRegexFromString(string regexStr, string text)
        {
            Regex regex = new Regex(regexStr);
            MatchCollection matches = regex.Matches(text);
            string[] result = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].Value;
            }
            return result;
        }

        /// <summary>
        /// Запрос в Google (JSON)
        /// </summary>
        /// <param name="searchRequest">Поисковой запрос</param>
        /// <param name="offset">Отступ 0-99</param>
        /// <returns></returns>
        private string RequestGoogleAPI(string searchRequest, int offset)
        {
            string currentAPIKey = APIkeys[0];
            string currentCXKey = CXkeys[0];

            string fullRequest = "https://www.googleapis.com/customsearch/v1?key=" + currentAPIKey + "&" +
                "start=" + offset + "&cx=" + currentCXKey + "&q=" + WebUtility.UrlEncode(searchRequest);
            //Print("---" + fullRequest);

            StringBuilder sb = new StringBuilder();
            WebClient myClient = new WebClient();
            try
            {
                Stream stream = myClient.OpenRead(fullRequest);
                using (Stream response = stream)
                {
                    using (StreamReader sr = new StreamReader(response))
                    {
                        while (sr.EndOfStream == false)
                        {
                            sb.Append(sr.ReadLine());
                        }
                    }
                }
                return sb.ToString();
            }
            catch (WebException e)
            {
                //throw e;
                if (e.Message.Contains("(429) Too Many Requests"))
                {
                    Print("Слишком много запросов! Нужно сменить API Key!");
                }
                else Print("Ошибка при выполнении HTTP запроса Google: " + e.Message);
                return "";
            }
        }



        private int Clamp(int min, int max, int value)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }


        private void findWebSitesButton_Click(object sender, EventArgs e)
        {
            if (searchRequestTextBox.Text != "")
            {
                StartGoogleRequest(searchRequestTextBox.Text);
            }
            else
            {
                PrintStatusBar("Введите запрос для поиска!", yellowColor);
            }
        }


        private void StartGoogleRequest(string googleRequest)
        {
            try
            {
                if (canDoGoogleRequest)
                {
                    Print("Начался запрос в Google...");
                    GoogleSearchStartedEvent?.Invoke(this, null);
                    
                    for (int i = 0; i < currentAvalableThreads; i++)
                    {
                        if (i >= MAX_GOOGLE_REQUEST_PAGES_COUNT || i >= currentSearchPages)
                            break;
                        searchOffsetsQueue.Enqueue(i * MAX_GOOGLE_REQUEST_PAGES_COUNT);
                    }
                    int threadsToLaunchCount = currentAvalableThreads;
                    int currentLaunchedThreads = 0;

                    while (currentLaunchedThreads < threadsToLaunchCount && currentLaunchedThreads < MAX_GOOGLE_REQUEST_THREADS)
                    {
                        currentLaunchedThreads++;
                        currentActiveThreads++;
                        Task t = null;
                        t = new Task(() =>
                        {
                            while (searchOffsetsQueue.Count > 0)
                            {
                                int currOffset = 0;
                                lock (searchOffsetsQueue)
                                {
                                    if (searchOffsetsQueue.Count > 0)
                                    {
                                        currOffset = searchOffsetsQueue.Dequeue();
                                    }
                                    else break;
                                }
                                GetEmailsByRequest(googleRequest, currOffset);
                            }
                            currentActiveThreads--;
                            GoogleRequestTaskComplitedEvent.Invoke(t);
                        });
                        t.Start();
                    }
                }
                else
                {
                    PrintStatusBar("Запрос в Google уже выполняется...", yellowColor);
                }

                //string strTest = jo["items"].Count().ToString();
                //Console.WriteLine("strTest: " + strTest);
                // DVD read/writer

                //IList<string> allDrives = o["Drives"].Select(t => (string)t).ToList();
                // DVD read/writer
                // 500 gigabyte hard drive



                //JObject items = JObject.Parse((string)reader.Value);

                //string prop = (string)jo["prop"];
                //JEnumerable<JToken> childrens = jo.Children();
                //JToken token = ((JArray)jo)["items"];//jo.GetValue("items");
                //string value = jo["items"];//GetTokenKeys(token);

                //"link": "https://acronyms.thefreedictionary.com/GHFG",
                //"displayLink":

                //for (int i = 0; i < childrens.Count(); i++)
                //{
                //    //JTokenReader reader = new JTokenReader(childrens.ElementAt(i));
                //    string values = GetTokenKeys(childrens.ElementAt(i));
                //    
                //    //childrens[values];
                //    Console.WriteLine(values);
                //    //for (int y = 0; y < values.Length; y++)
                //    //{
                //    //    Console.WriteLine(values[y]);
                //    //}
                //    //GetTokenKeys((JObject)jo["items"]);
                //
                //}
                //foreach (JToken s in childrens)
                //{
                //    JTokenReader reader = new JTokenReader(s);
                //    reader.Read();
                //    Console.WriteLine("JToken: " + reader.Value);
                //}
                //for (int i = 0; i < childrens.Count(); i++)
                //{
                //    Console.WriteLine("JObject: " + (string)jo[childrens[i]]);
                //}
                //Console.WriteLine("JObject: " + (string)jo[);

                //var ja = (JArray)JsonConvert.DeserializeObject(json);
                //var jo = (JObject)ja[0];
                //Console.WriteLine(jo["a"]);
                //Console.jo(jo["a"]);
                //PrintStatusBar("Поиск начался...", normalColor);
                //}
                //catch (WebException s)
                //{
                //    PrintStatusBar("Ошибка HTTP при загрузке:" + s.Message, redColor);
                //}

            }
            catch (Exception s)
            {
                //PrintStatusBar("Ошибка при выполнении Google запроса: " + s.Message, redColor);
                Print("Ошибка при выполнении Google запроса: " + s.Message);
                GoogleSearchEndedEvent?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Записать все записи сайтов во временный файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        private void WriteAllRequestResultsToTempFile(string filePath)
        {
            if (siteRecordsList.Count == 0)
            {
                return;
            }

            if (appendToTempFileCheckBox.Checked)
            {
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        for (int i = 0; i < siteRecordsList.Count; i++)
                        {
                            for (int y = 0; y < siteRecordsList[i].Length; y++)
                            {
                                string record = (siteRecordsList[i][y].Site).Replace("\n" , "");
                                if (fileContent.Contains(record) == false)
                                {
                                    streamWriter.WriteLine(record);
                                }
                                else Print("--skipped double...");
                            }
                        }
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    string temp = "";
                    for (int i = 0; i < siteRecordsList.Count; i++)
                    {
                        for (int y = 0; y < siteRecordsList[i].Length; y++)
                        {
                            temp = (siteRecordsList[i][y].Site).Replace("\n", "");
                            sb.Append(temp + "\n");
                        }
                    }
                    File.WriteAllText(filePath, sb.ToString());
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string temp = "";
                for (int i = 0; i < siteRecordsList.Count; i++)
                {
                    for (int y = 0; y < siteRecordsList[i].Length; y++)
                    {
                        temp = (siteRecordsList[i][y].Site).Replace("\n", "");
                        sb.Append(temp + "\n");
                    }
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        /// <summary>
        /// Запросить страницу результатов Google запроса. (макс 10 результатов)
        /// </summary>
        /// <param name="googleRequest">Строка запроса</param>
        /// <param name="offset">Отступ от начала (в результатах, а не в страницах)</param>
        private void GetEmailsByRequest(string googleRequest, int offset = 0)
        {
            //try
            //{
            //googleRequestStopWatch = new Stopwatch();
            string responce = RequestGoogleAPI(googleRequest, offset);

            // Запросов не найдено... возможна ошибка или привышение лимита запросов.
            if (responce == "")
                return;

            JObject jo = JObject.Parse(responce);

            JToken token = jo["items"];

            // Если результатов нет...
            if (token == null)
                return;
            //Print(jo.ToString());
            int count = token.Count();
            SiteEmailRecord[] records = new SiteEmailRecord[count];
            for (int i = 0; i < count; i++)
            {
                string str = token[i].ToString();
                JObject jo1 = JObject.Parse(str);
                string page = jo1["link"].ToString();
                string site = jo1["displayLink"].ToString();
                SiteEmailRecord record = new SiteEmailRecord();
                record.Site = site;
                record.Page = page;
                records[i] = record;
            }
            siteRecordsList.Add(records);
            //}
            //catch (WebException e)
            //{
            //    PrintStatusBar("Ошибка HTTP: " + e.Message, redColor);
            //}
            //catch (Exception e)
            //{
            //    PrintStatusBar("Ошибка при выполнении Google запроса: : " + e.Message, redColor);
            //}

            //Console.WriteLine(jo1["link"].ToString());
            //Console.WriteLine("Token " + i +": " + str);
            //File.WriteAllText(fullTempFilePath, responce);
            //JArray ja = (JArray)JsonConvert.DeserializeObject(responce);
            //JObject jo = (JObject)ja[0];

            //JToken token = jo["items"];
            //JTokenReader reader = new JTokenReader(token);
            //reader.Read();
        }

        [Obsolete]
        private string GetTokenKeys(JToken jo)
        {
            //JEnumerable<JToken> childrens = jo.Children();
            //string[] result = new string[childrens.Count()];
            //
            //for (int i = 0; i < result.Length; i++)
            //{
            //    JTokenReader reader = new JTokenReader(childrens.ElementAt(i));
            //    reader.Read();
            //    result[i] = (string)reader.Value;
            //    Console.WriteLine("JToken: " + reader.Value);
            //}
            //return result;
            JTokenReader reader = new JTokenReader(jo);
            reader.Read();
            return (string)reader.Value;
        }




        private void PrintStatusBar(string text)
        {
            PrintStatusBar(text, normalColor);
        }
        private void PrintStatusBar(string text, Color color)
        {
            this.Invoke((Action)(() => statusBarText.Text = text));
            this.Invoke((Action)(() => statusBar.BackColor = color));
            Print(text);
        }
        private void Print(string text)
        {
            Console.WriteLine(text);
        }
        private void Print(int text)
        {
            Console.WriteLine(text);
        }




        private void webPagesTempFilePathTextBox_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = rootDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void deleteWebPagesTempFileButton_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            bool existsAfterDelete = false;
            if (File.Exists(fullTempFilePath))
            {
                isExists = true;
            }
            File.Delete(fullTempFilePath);
            if (File.Exists(fullTempFilePath))
            {
                existsAfterDelete = true;
            }

            if (isExists)
            {
                if (existsAfterDelete)
                {
                    PrintStatusBar("Не удалось удалить временный файл...", redColor);
                }
                else
                {
                    PrintStatusBar("Временный файл успешно удалён!", greenColor);
                }
            }
            else
            {
                PrintStatusBar("Временный итак не существует!", greenColor);
            }

            UpdateButtons();
        }

        private void openWebPagesTempFileButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(fullTempFilePath))
            {
                Process openFileProcess = new Process();
                openFileProcess.StartInfo.FileName = fullTempFilePath;
                openFileProcess.Start();
            }
            else
            {
                UpdateButtons();
                PrintStatusBar("Невозможно открыть временный файл. Его нет!", yellowColor);
            }
        }

        private void coresCountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentAvalableThreads = coresCountComboBox.SelectedIndex + 1;
            //Print(currentAvalableThrads);
        }
        private void pagesCountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSearchPages = Clamp(1, MAX_GOOGLE_REQUEST_PAGES_COUNT, pagesCountComboBox.SelectedIndex + 1);
        }
        private void searchRequestTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchRequestTextBox.Text == "")
            {
                ToggleFindWebSitesButton(false);
            }
            else
            {
                ToggleFindWebSitesButton(true);
            }
        }
        private void sitesPathFileLabel_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = rootDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void emailsPathFileLabel_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = rootDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        private void findEmailsButton_Click(object sender, EventArgs e)
        {
            string[] pagesToSearchArr = null;
            if (pagesNamesTextBox.Text != "")
            {
                try
                {
                    pagesToSearchArr = (pagesNamesTextBox.Text).Split(' ');
                    //Print(pagesToSearchArr.Length);
                }
                catch (Exception ex)
                {
                    pagesNamesTextBox.Text = "";
                    PrintStatusBar("Страницы поиска заданы некорректно!", yellowColor);
                    throw ex;
                    return;
                }
            }

            // Создание списка страниц
            string tempFileContent;
            string[] sitesArr;
            if (File.Exists(fullTempFilePath) == false)
            {
                PrintStatusBar("Временный файл со списком сайтов не существует!", redColor);
                return;
            }
            try
            {
                tempFileContent = File.ReadAllText(fullTempFilePath);
                sitesArr = tempFileContent.Split('\n');

                if (sitesArr == null)
                {
                    PrintStatusBar("Временный файл не содержит web-адресов!", yellowColor);
                    return;
                }
                if (sitesArr.Length <= 1)
                {
                    PrintStatusBar("Временный файл не содержит web-адресов!", yellowColor);
                    return;
                }
            }
            catch (Exception ex)
            {
                PrintStatusBar("Не удалось открыть временный файл!", redColor);
                throw ex;
                return;
            }

            int pagesToSearchSize = 1;
            if (pagesToSearchArr != null)
            {
                pagesToSearchSize = pagesToSearchArr.Length;
            }
            string[] allPagesToCheck = new string[sitesArr.Length * pagesToSearchSize];
            int index = 0;

            for (int i = 0; i < sitesArr.Length; i++)
            {
                //Print(sitesArr[i]);
                if (pagesToSearchArr != null)
                {
                    for (int y = 0; y < pagesToSearchArr.Length; y++)
                    {
                        string site = sitesArr[i];
                        allPagesToCheck[index] = WebUtility.UrlEncode(site + "/" + pagesToSearchArr[y]);
                        index++;
                    }
                }
                else
                {
                    allPagesToCheck[index] = WebUtility.UrlEncode(sitesArr[i]);
                    index++;
                }
            }

            Print("Всего сайтов: " + sitesArr.Length + "; Страни на каждый сайт: " + pagesToSearchArr.Length + 
                "; Всего страниц для проверки: " + allPagesToCheck.Length);
            //if (pagesToSearchArr != null)
            //{
            //    if (pagesToSearchArr.Length > 0)
            //    {
            //
            //        EmailSearchEndedEvent?.Invoke(this, null);
            //    }
            //    else
            //    {
            //
            //    }
            //}

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (isAPIHandlerInit == false)
            {
                PrintStatusBar("Файл с API ключами не содержит ни одного ключа или отсутствует!", redColor);
            }
        }















        private void OnCanDoGoogleRequestChanged(bool canDoGoogleRequest)
        {
            ToggleFindWebSitesButton(canDoGoogleRequest);

            //Print("Можно ли выполнить запрос в Google: " + canDoGoogleRequest);
        }
        private void OnGoogleRequestTaskComplited(Task task)
        {
            if (currentActiveThreads <= 0)
            {
                GoogleSearchEndedEvent?.Invoke(this, null);
                PrintStatusBar("Запрос выполнен! " + ((float)(googleRequestStopWatch.ElapsedMilliseconds) * 0.001f) + "с", greenColor);
            }
        }

        // Запрос начался
        private void OnGoogleSearchStarted(object sender, EventArgs e)
        {
            CanDoGoogleRequest = false;
            siteRecordsList.Clear();

            this.Invoke((Action)(() =>
            {
                // Отключить кнопку поиска имейлов
                findEmailsButton.Enabled = false;
                findEmailsButton.ForeColor = disabledTextColor;
                findEmailsButton.BackColor = disabledBGColor;

                appendToTempFileCheckBox.Enabled = false;
                pagesCountComboBox.Enabled = false;
                coresCountComboBox.Enabled = false;
                searchRequestTextBox.Enabled = false;
                pagesNamesTextBox.Enabled = false;

                deleteWebPagesTempFileButton.Enabled = false;
                deleteWebPagesTempFileButton.BackColor = disabledBGColor;
                deleteWebPagesTempFileButton.ForeColor = disabledTextColor;

                openWebPagesTempFileButton.Enabled = false;
                openWebPagesTempFileButton.BackColor = disabledBGColor;
                openWebPagesTempFileButton.ForeColor = disabledTextColor;
            }));

            googleRequestStopWatch = new Stopwatch();
            googleRequestStopWatch.Start();
        }
        // Запрос завершился
        private void OnGoogleSearchEnded(object sender, EventArgs e)
        {
            currentActiveThreads = 0;
            WriteAllRequestResultsToTempFile(fullTempFilePath);
            googleRequestStopWatch.Stop();

            this.Invoke((Action)(() =>
            {
                appendToTempFileCheckBox.Enabled = true;
                pagesCountComboBox.Enabled = true;
                coresCountComboBox.Enabled = true;
                searchRequestTextBox.Enabled = true;
                pagesNamesTextBox.Enabled = true;

                deleteWebPagesTempFileButton.Enabled = true;
                deleteWebPagesTempFileButton.BackColor = redColor;
                deleteWebPagesTempFileButton.ForeColor = disabledBGColor;

                openWebPagesTempFileButton.Enabled = true;
                openWebPagesTempFileButton.BackColor = normalColor;
                openWebPagesTempFileButton.ForeColor = disabledBGColor;
            }));

            UpdateButtons();
            
            CanDoGoogleRequest = true;
        }


        private void ToggleFindWebSitesButton(bool state)
        {
            this.Invoke((Action)(() =>
            {
                findWebSitesButton.Enabled = state;
                if (state)
                {
                    findWebSitesButton.BackColor = normalColor;
                    findWebSitesButton.ForeColor = disabledBGColor;
                }
                else
                {
                    findWebSitesButton.BackColor = disabledBGColor;
                    findWebSitesButton.ForeColor = disabledTextColor;
                }
            }));
        }

        private void UpdateButtons()
        {
            if (File.Exists(fullTempFilePath))
            {
                this.Invoke((Action)(() =>
                {
                    deleteWebPagesTempFileButton.Enabled = true;
                    deleteWebPagesTempFileButton.BackColor = redColor;
                    deleteWebPagesTempFileButton.ForeColor = disabledBGColor;

                    openWebPagesTempFileButton.Enabled = true;
                    openWebPagesTempFileButton.BackColor = normalColor;
                    openWebPagesTempFileButton.ForeColor = disabledBGColor;

                    // Включить кнопку поиска имейлов
                    findEmailsButton.Enabled = true;
                    findEmailsButton.ForeColor = disabledBGColor;
                    findEmailsButton.BackColor = normalColor;
                }));
            }
            else
            {
                this.Invoke((Action)(() =>
                {
                    deleteWebPagesTempFileButton.Enabled = false;
                    deleteWebPagesTempFileButton.BackColor = disabledBGColor;
                    deleteWebPagesTempFileButton.ForeColor = disabledTextColor;

                    openWebPagesTempFileButton.Enabled = false;
                    openWebPagesTempFileButton.BackColor = disabledBGColor;
                    openWebPagesTempFileButton.ForeColor = disabledTextColor;

                    // Отключить кнопку поиска имейлов
                    findEmailsButton.Enabled = false;
                    findEmailsButton.ForeColor = disabledTextColor;
                    findEmailsButton.BackColor = disabledBGColor;
                }));
            }
        }


        public delegate void CanDoGoogleRequestChanged(bool canDoGoogleRequest);
        public delegate void TaskComplited(Task task);
        public delegate void EmailSearch(object sender, EventArgs e);
    }
}
