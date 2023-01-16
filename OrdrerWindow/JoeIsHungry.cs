using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdrerWindow
{
    public class JsonFileInfo
    {
        public int NummerID { get; set; }
        public ObservableCollection<OrderTing> filJson { get; set; }
        public JsonFileInfo(int ID, ObservableCollection<OrderTing> filJson) 
        { 
            this.NummerID = ID;
            this.filJson = filJson;
        }
    }
}
