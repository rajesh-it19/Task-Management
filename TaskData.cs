using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;

namespace TaskManagementApplication.App_Data
{
    public class TaskData
    {

        // Task Repository

        private static List<ZTask> _task = new List<ZTask>();
        int index = 0;
        public List<ZTask> GetTask(int userId)
        {
           
                var getTask = _task.Where(task => task.AssignTo.Contains(userId) && task.ParentTask == null).ToList();
                return getTask;
            
            
            
        }



        public int AddTask(string type, List<long>  assignTo, long taskId, string taskName, string taskDescription, DateTime startDate, DateTime endDate, TaskPriority priority, ZTaskStatus status, int assignBy ,long upVote)
        {
            int count = 0;

            foreach (var item in TaskData._task)
            {
                if (item.TaskStatus == ZTaskStatus.Done)             //TaskStatus.Done
                {
                    Console.WriteLine("Task Already Exists or Task Completed");
                }
            }

            //Console.Write( assignTo.Count);




            for (int i = 0; i < assignTo.Count; i++)
            {
                var task = new ZTask();
                task.ParentTask = type;
                task.AssignTo.Add(assignTo[i]);
                task.TaskId = taskId;
                task.TaskName = taskName;
                task.TaskDescription = taskDescription;
                task.StartDate = startDate;
                task.EndDate = endDate;
                task.TaskPriority = priority;
                task.TaskStatus = status;
                task.AssignBy = assignBy;
                TaskData._task.Add(task);
            }
           
            
            
            return ++count;
        }



        public void SetPriority(int taskId, int priority)
        {
            foreach (var item in TaskData._task)
            {
                if (item.TaskId == taskId)
                {
                    item.TaskPriority = (TaskPriority)priority;
                }
            }
        }




        public void SetSubTaskStatus(int taskId, int subtaskId, int status)
        {
            foreach (var item in TaskData._task)
            {
                if (item.ParentTask == taskId.ToString() && item.TaskId == subtaskId)
                {
                    item.TaskStatus = (ZTaskStatus)status;
                }
            }
        }




        public void SetStatus(int taskId, int status)
        {
            int flag = -1;
            foreach (var item in TaskData._task)
            {
                if (item.ParentTask == taskId.ToString())
                {
                    if ((int)item.TaskStatus == 1)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }

            }
            if (flag != 0)
            {
                foreach (var item in TaskData._task)
                {
                    if (item.TaskId == taskId)
                    {
                        item.TaskStatus = (ZTaskStatus)status;
                    }

                }
            }
            else
            {
                Console.WriteLine("Sub Task not completed");
            }
        }



        public List<ZTask> GetSubTask(string parentId)
        {
            var task = _task.Where(task =>task.ParentTask==parentId).ToList();
            return task;
        }

        public void UpVote( int taskId ,string userName)
        {
            foreach (var item in TaskData._task)
            {
                if (item.TaskId == taskId && item.TaskStatus == ZTaskStatus.UnDone)             
                {                   
                    ++item.TaskUpVote;
                    item.UpVoters.Add(userName);                                 
                }
            }
        }


    }
}
