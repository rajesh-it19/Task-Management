using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApplication.Model
{
    public class ZTask 
    {

        public string? ParentTask {  get; set; }               //contains MainTask or SubTask

        public List<long> AssignTo { get; set; } = new List<long>();
        
        
        public long TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public ZTaskStatus TaskStatus { get; set; }
        
        public TaskPriority TaskPriority { get; set; }
        
        public long TaskUpVote { get; set; }

        public List<string> UpVoters { get; set; } = new List<string>();    

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
      
        public int AssignBy { get; set; }
    }




    public enum ZTaskStatus
    {
        UnDone,
        Done

    }


    public enum TaskPriority
    {
        NoPriority,
        HighPriority
    }
}