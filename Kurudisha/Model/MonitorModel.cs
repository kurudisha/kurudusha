using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurudisha.Model
{
    public class MonitorModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public bool isNew { get; set; }

        public override string ToString()
        {
            return this.Comments + " ("+ this.Date +")";
        }
    }
}
