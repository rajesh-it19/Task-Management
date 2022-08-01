using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;
using TaskManagementApplication.App_Data;
using System.Collections;

namespace TaskManagementApplication.Controller
{
    public class TaskController
    {
       
        TaskData taskData = new TaskData();
        
        //   Add Task




        int count = 0;
        public int AddTask(string type, List<long> assignTo , long taskId , string taskName , string taskDescription , DateTime startDate , DateTime endDate , TaskPriority priority , ZTaskStatus status , int assignBy ,long upVote)
        {
           taskData.AddTask( type, assignTo , taskId , taskName , taskDescription , startDate , endDate , priority , status , assignBy, upVote );
          return ++count;
        }


        //    Set Priority


        public void SetPriority(int taskId ,int priority)
        {
            taskData.SetPriority(taskId ,priority);
        }

        
        //   Set SubTask Status


        public void SetSubTaskStatus(int taskId,int subtaskId , int status)
        {
           taskData.SetSubTaskStatus(taskId ,subtaskId ,status);
        }


        //  Set Task Status


        public void SetStatus(int taskId , int status)
        {
            taskData.SetStatus(taskId ,status);
            
        }


        public List<ZTask> FetchTask(int userId)
        {
           var task =  taskData.GetTask(userId);
            return task;
        }

        public List<ZTask> FetchSubTask(string parentId)
        {
            var task = taskData.GetSubTask(parentId);
            return task;
        }

        public void UpVote( int taskId , string userName)
        {
            taskData.UpVote( taskId,userName);
        }




    }
}
