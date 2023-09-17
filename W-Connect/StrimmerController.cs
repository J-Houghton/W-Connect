using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W_Connect
{
    public class StrimmerController
    {
        public bool isDeleter { get; set; }
        public int index { get; set; }
        public int com { get; set; }
        public int conType { get; set; }
        public string name { get; set; }
        public string sn { get; set; }
        public bool isOnline { get; set; }
        public float version { get; set; }
        public string compile { get; set; }
        public string typeName { get; set; }
        public int state { get; set; }
        public bool isHid { get; set; }
        public int extendPortType { get; set; }
        public List<Road> roads { get; set; }

    }
    public class Road
    {
        public List<StrimmerEffect> singleMode { get; set; }
        public int lineNum { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class StrimmerEffect
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<List<int>> colors = new List<List<int>>();
        public int direction { get; set; }
        public int speed { get; set; }
        public int brightness { get; set; }
        public List<int> lightNum = new List<int>();
        public int modelIndex { get; set; }
        
    }
}
