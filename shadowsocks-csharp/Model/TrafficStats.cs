using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using Shadowsocks.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Shadowsocks.Model
{
    public class TrafficStatsChangedEventArgs : EventArgs
    {
        public bool IsDownload;
        public object Value;
    }

    public class TrafficStats
    {
        private const string jsonFileName = "traffic-stats.json";
        private long currentDownload;
        private long currentUpload;
        private long todayDownload;
        private long todayUpload;
        private long monthDownload;
        private long monthUpload;
        private long monthTotal;
        private long monthUsed;
        private string currentSpeed;

        public DateTime DateTime { get; set; }

        public long CurrentDownload
        {
            get { return currentDownload; }
            set { currentDownload = value; }
        }
        public long CurrentUpload
        {
            get { return currentUpload; }
            set { currentUpload = value; }
        }
        public long TodayDownload
        {
            get { return todayDownload; }
            set { todayDownload = value; }
        }
        public long TodayUpload
        {
            get { return todayUpload; }
            set { todayUpload = value; }
        }
        public long MonthDownload
        {
            get { return monthDownload; }
            set
            {
                monthDownload = value;
                OnDataChanged?.Invoke(this, new TrafficStatsChangedEventArgs()
                {
                    IsDownload = true,
                    Value = this.monthDownload
                });
            }
        }
        public long MonthUpload
        {
            get { return monthUpload; }
            set
            {
                monthUpload = value;
                OnDataChanged?.Invoke(this, new TrafficStatsChangedEventArgs()
                {
                    IsDownload = false,
                    Value = this.monthUpload
                });
            }
        }
        public long MonthUsed
        {
            get { return this.monthUsed; }
            set { this.monthUsed = value; }
        }
        public long MonthTotal
        {
            get { return this.monthTotal; }
            set { this.monthTotal = value; }
        }
        public string CurrentSpeed
        {
            get
            {
                return this.currentSpeed;
            }
            set
            {
                this.currentSpeed = value;
                this.OnSpeedChanged?.Invoke(this, new TrafficStatsChangedEventArgs()
                {
                    IsDownload = false,
                    Value = this.currentSpeed
                });
            }
        }

        public event EventHandler<TrafficStatsChangedEventArgs> OnDataChanged;
        public event EventHandler<TrafficStatsChangedEventArgs> OnSpeedChanged;

        public void Load()
        {
            if (File.Exists(jsonFileName))
            {
                string fileContent = File.ReadAllText(jsonFileName);
                TrafficStats trafficStats = JsonConvert.DeserializeObject<TrafficStats>(fileContent);

                DateTime dateTime = DateTime.Now;
                this.DateTime = trafficStats.DateTime;
                this.MonthTotal = trafficStats.MonthTotal;

                if (dateTime.Month == this.DateTime.Month)
                {
                    this.MonthUsed = trafficStats.MonthUsed;
                    this.MonthDownload = trafficStats.MonthDownload;
                    this.MonthUpload = trafficStats.MonthUpload;
                }

                if (dateTime.Day == this.DateTime.Day)
                {
                    this.TodayDownload = trafficStats.TodayDownload;
                    this.TodayUpload = trafficStats.TodayUpload;
                }

                this.DateTime = DateTime.Now;
            }
        }

        public void Save()
        {
            this.DateTime = DateTime.Now;
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(jsonFileName, json);
        }

        public void CorrectStats(DateTime dateTimeNow)
        {
            if (this.DateTime.Day != dateTimeNow.Day)
            {
                this.CurrentDownload = 0;
                this.CurrentUpload = 0;
                this.TodayDownload = 0;
                this.TodayUpload = 0;
            }
        }

        public void CalibrateTrafficDataStats()
        {
            Task.Factory.StartNew(new Action(() =>
            {
                int count = 0;
                try
                {
                    string pythonLibPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonLib");
                    string pythohFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stats_calibration.py");

                    ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
                    engine.SetSearchPaths(new List<string> { pythonLibPath });
                    dynamic pythonFile = engine.Runtime.UseFile(pythohFilePath);

                    while (count++ < 5)
                    {
                        try
                        {
                            IronPython.Runtime.PythonDictionary dictionary = (IronPython.Runtime.PythonDictionary)pythonFile.get_stats_by_http();
                            string monthTotalMib = (dictionary["MonthTotal"] as IronPython.Runtime.List)[0] as string;
                            string monthUsedMib = (dictionary["MonthUsed"] as IronPython.Runtime.List)[0] as string;
                            string monthUploadMib = (dictionary["MonthUpload"] as IronPython.Runtime.List)[0] as string;
                            string monthDownloadMib = (dictionary["MonthDownload"] as IronPython.Runtime.List)[0] as string;
                            this.MonthTotal = (long)Utils.ConvertToBytes(double.Parse(monthTotalMib)).Value;
                            this.MonthUsed = (long)Utils.ConvertToBytes(double.Parse(monthUsedMib)).Value;
                            this.MonthUpload = (long)Utils.ConvertToBytes(double.Parse(monthUploadMib)).Value;
                            this.MonthDownload = (long)Utils.ConvertToBytes(double.Parse(monthDownloadMib)).Value;
                            this.Save();
                            Console.WriteLine("CalibrateTrafficDataStats success.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CalibrateTrafficDataStats error: " + ex.Message);
                            continue;
                        }
                    }

                    if (count >= 5)
                    {
                        Console.WriteLine("CalibrateTrafficDataStats error: Over max attempt times.");
                    }
                }
                catch (Exception ex)
                {
                    //数据校正失败
                    Console.WriteLine("CalibrateTrafficDataStats error: " + ex.Message);
                }
            }), new CancellationTokenSource().Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
        }

        public void Clear()
        {
            this.CurrentDownload = 0;
            this.CurrentUpload = 0;
            this.TodayDownload = 0;
            this.TodayUpload = 0;
            this.MonthUsed = 0;
            this.MonthDownload = 0;
            this.MonthUpload = 0;
            this.Save();
        }
    }
}
