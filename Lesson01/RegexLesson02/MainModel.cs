using RegexLesson02;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RegexLesson02
{
    class MainModel : INotifyPropertyChanged
    {
        public class Rootobject
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
        }

        public Encoding[] Encodings
        {
            get { return _Encodings; }
        }
        private Encoding[] _Encodings = new Encoding[]
        {
                Encoding.Default,
                Encoding.ASCII,
                Encoding.BigEndianUnicode,
                Encoding.Unicode,
                Encoding.UTF32,
                Encoding.UTF7,
                Encoding.UTF8,
        };

        public Encoding CurrentEncoding
        {
            get => _CurrentEncoding;
            set
            {
                if (_CurrentEncoding == value) return;
                _CurrentEncoding = value;
                OnPropertyChanged(nameof(CurrentEncoding));
            }
        }
        private Encoding _CurrentEncoding = Encoding.Default;

        public void Load(string aFileName, Encoding aEncoding)
        {
            string[] aLines = File.ReadAllLines(aFileName, aEncoding);
            SourceTexts = aLines;
            if (Recents.Items.FirstOrDefault(r => r.FileName == aFileName) == null)
                Recents.Items.Add(new RecentItem { FileName = aFileName, EncodingName = aEncoding.EncodingName });
        }

        public void Load(string aFileName, string aEncodingName)
        {
            Encoding aEncoding = (from r in Encodings where r.EncodingName == aEncodingName select r).FirstOrDefault(); 
            if (aEncoding == null) aEncoding = Encoding.Default;
            Load(aFileName, aEncoding);
        }

        public string[] SourceTexts
        {
            get { return _SourceTexts; }
            set
            {
                if (_SourceTexts == value) return;
                _SourceTexts = value;
                DoFilter();
                OnPropertyChanged(nameof(SourceTexts));
            }
        }
        private string[] _SourceTexts;

        public void DoFilter()
        {
            if (SourceTexts == null) return;
            if (string.IsNullOrEmpty(Pattern))
            {
                FilteredTexts = new List<string>(SourceTexts);
            }
            else
            {
                Regex aRegex = new Regex(Pattern);
                List<string> aLines = new List<string>();
                foreach (string aLine in SourceTexts)
                {
                    if (aRegex.IsMatch(aLine))
                        aLines.Add(aLine);
                }
                FilteredTexts = aLines;
            }
        }

        public List<string> FilteredTexts
        {
            get { return _FilteredTexts; }
            private set
            {
                if (_FilteredTexts == value) return;
                _FilteredTexts = value;
                OnPropertyChanged(nameof(FilteredTexts));
            }
        }
        private List<string> _FilteredTexts;

        public string Pattern
        {
            get { return _Pattern; }
            set
            {
                if (_Pattern == value) return;
                _Pattern = value;
                OnPropertyChanged(nameof(Pattern));
                DoFilter();
            }
        }
        private string _Pattern;

        // 配置文件操作
        private const string ConfigFileName = "Regex.config";
        public void LoadConfig()
        {
            try
            {
<<<<<<<<< Temporary merge branch 1
                string aConfigJson = File.ReadAllText(ConfigFileName);
                DataContractJsonSerializer aSerializer = new DataContractJsonSerializer(typeof(ConfigData));
                using (MemoryStream aStream = new MemoryStream(Encoding.UTF8.GetBytes(aConfigJson)))
                {
                    Recents = aSerializer.ReadObject(aStream) as ConfigData;
                }
=========
                XDocument aXDocument = XDocument.Load(ConfigFileName);
                this.ReadFromXml(aXDocument.Root.Element("Regex"));
>>>>>>>>> Temporary merge branch 2
            }
            catch (System.Exception) { }
        }
        public void SaveConfig()
        {
            try
            {
<<<<<<<<< Temporary merge branch 1
                byte[] aBytes;
                DataContractJsonSerializer aSerializer = new DataContractJsonSerializer(typeof(ConfigData));
                using (MemoryStream aStream = new MemoryStream())
                {
                    aSerializer.WriteObject(aStream, Recents);
                    aStream.Seek(0, SeekOrigin.Begin);
                    aBytes = aStream.ToArray();
                }
                string aConfigJson = Encoding.UTF8.GetString(aBytes);
                File.WriteAllText(ConfigFileName, aConfigJson);
            }
            catch (System.Exception ex) 
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
=========
                XDocument aXDocument = new XDocument(new XElement("Config", this.CreateXElement("Regex")));
                aXDocument.Save(ConfigFileName);
            }
            catch (System.Exception) { }
>>>>>>>>> Temporary merge branch 2
        }
        #endregion

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
