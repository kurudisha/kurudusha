using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurudisha.Model
{
   public class TaskModel
    {

        [PrimaryKey]
        public int Id { get; set; }
        public string TaskName { get; set; }

        public DateTime TaskDate { get; set; }

        public bool IsCompleted { get; set; }

    }
}
