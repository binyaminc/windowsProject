using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit 
    {
        private Host owner;
        private string hostingUnitName;
        private bool[,] diary = new bool[12, 31];
        private int hostingUnitKey;
        private Area area;
        private string subArea;
        private Type type;
        private int capacity;
        private String address;
        private bool pool;
        private bool jacuzzi;
        private bool garden;
        private bool childrenAttractions;
        //price?



        public Host Owner { get => owner; set => owner = value; }
        public string HostingUnitName { get => hostingUnitName; set => hostingUnitName = value; }
        [XmlIgnore]
        public bool[,] Diary { get => diary; set => diary = value; }
        [XmlArray("Diary")]
        public bool[] DiaryDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); }
        }
        public int HostingUnitKey { get => hostingUnitKey; set => hostingUnitKey = value; }
        public Area Area { get => area; set => area = value; }
        public Type Type { get => type; set => type = value; }
        public string SubArea { get => subArea; set => subArea = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string Address { get => address; set => address = value; }
        public bool Pool { get => pool; set => pool = value; }
        public bool Jacuzzi { get => jacuzzi; set => jacuzzi = value; }
        public bool Garden { get => garden; set => garden = value; }
        public bool ChildrenAttractions { get => childrenAttractions; set => childrenAttractions = value; }

        public override string ToString()
        {
            string result = "HostingUnitKey: " + HostingUnitKey.ToString()
            + " Owner: " + Owner.ToString()
            + " HostingUnitName: " + HostingUnitName
            + " Diary: " + Diary.ToString()
            + " Area: " + Area;
            return result;
        }


    }
}
