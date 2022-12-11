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

namespace RegexLesson02
{
    [DataContract]
    class RecentItem
    {
        [DataMember] public string FileName { get; set; }
        [DataMember] public string EncodingName { get; set; }
    }
    [DataContract]
    class ConfigData
    {
        [DataMember] public ObservableCollection<RecentItem> Items { get; set;} = new ObservableCollection<RecentItem>();
    }

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
            try{
                XDocument aXDocument = XDocument.Load(ConfigFileName);
                this.ReadFromXml(aXDocument.Root.Element("Regex"));
            }catch (System.Exception){}
        }
        public void SaveConfig()
        {
            try{
                XDocument aXDocument = new XDocument(new XElement("Config", this.CreateXElement("Regex")));
                aXDocument.Save(ConfigFileName);
            }catch (System.Exception){}
        }
        #region 序列化
        public void ReadFromXml(XElement aXElement)
        {
            if (aXElement == null) return;
            Pattern = aXElement.Element(nameof(Pattern))?.Value;
        }
        public XElement CreateXElement(string aXmlNodeName)
        {
            return new XElement(aXmlNodeName, new XElement(nameof(Pattern), Pattern));
        }
        //#region 序列化
        //public void ReadFromXml(XElement aXElement)
        //{
        //    if (aXElement == null) return;
        //    Pattern = aXElement.Element(nameof(Pattern))?.Value;
        //}
        //public XElement CreateXElement(string aXmlNodeName)
        //{
        //    return new XElement(aXmlNodeName, new XElement(nameof(Pattern), Pattern));
        //}
        //#endregion

        public ConfigData Recents { get => _Recents; private set { if (_Recents == value) return; _Recents = value; OnPropertyChanged(nameof(Recents)); } }
        private ConfigData _Recents = new ConfigData();

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }


    public class Rootobject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

}
