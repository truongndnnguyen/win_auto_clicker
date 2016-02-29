using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;



namespace Auto_Clicker
{
    [Serializable]
    
    public class ClickPoint 
    {

        [XmlAttribute]
        public int X { get; set; }
        [XmlAttribute]
        public int Y { get; set; }
        [XmlAttribute]
        public int Wait { get; set; }
        [XmlAttribute]
        public string Note { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public int Index { get; set; }
        [XmlAttribute]
        public bool Enable { get;  set; }


        public ClickPoint()
        {

            Enable = true;
            Note = "";
        }
    }

    [Serializable]
   [XmlRoot (ElementName = "ClickPoints")]
    public class ClickPoints : List<ClickPoint>
    {
        [XmlAttribute]
        public string RepeatCounts { get; set; }

        public ClickPoints ()
        {

            RepeatCounts = "10000";
        }
    }
}
