using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;
using TaskManagementApplication.Controller;
using System.Collections;


namespace TaskManagementApplication.View
{
    public class TaskManagemet
    {
        
        
        public static void Main(String[] arg)
        {
           
            ZTask zTask = new ZTask();
            Comment comment = new Comment();
            
           
           
            //   Creating Users


           


            int count = 0;
         
            //  Output Console

            login:                                                                                                       // Login with Other User

            Console.WriteLine("                           Welcome To  Task Management Application                      ");
            Console.WriteLine($"{Environment.NewLine}Enter your Login Credentials");
            int userId;
            Console.Write($"{Environment.NewLine}Enter your User ID : ");
            try
            {
                userId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception )
            {
                Console.WriteLine("Incorrect Format Enter a Valid Id.");
                Console.WriteLine("Enter Any Key To Retry.....");
                Console.ReadKey();
                Console.Clear();
                goto login;
            }
            Console.Write($"{Environment.NewLine}Enter UserName : ");
            string userName = Console.ReadLine();

            
            //     Validating user input in User Controller


            
            UserController userController = new UserController();
            userController.CreateUser();
            bool IsValidUser = userController.IsValidUser(userId,userName.ToUpper());
            if (IsValidUser)
            {
                Console.WriteLine("Logged In Successfully");
                Thread.Sleep(500);
            }
            else
            {
                ++count;
                
                Console.WriteLine("Incorrect Id or User name");
                if (count == 3)
                {
                    Environment.Exit(0);
                }
                Thread.Sleep(500);
                Console.Clear();
                goto login;
            }
            Console.Clear();



            //    Performing Operations  using Switch Case under do-while

           
            int assignTo = userId;
            short exit = 1;
            TaskController taskController = new TaskController();
            CommentController commentController = new CommentController();
            List<int> taskIdVote = new List<int>();



            do
            {
                Console.Clear();
                Console.WriteLine($"                                                              WELCOME {userName.ToUpper()}                                   ");
                Console.WriteLine($"{Environment.NewLine}Select an Option to Continue...");
                Console.WriteLine($"{Environment.NewLine} 1.Login With Another Id \n 2.Add Task \n 3.Add SubTask \n 4.ShowTask \n 5.ShowSubTask \n 6.Add Comment \n 7.Show Comment \n 8.Set Priority \n 9.Set SubTask status\n 10.Set Task status \n 0.Exit");

                Console.Write($"{Environment.NewLine}Enter Your Choice : ");
                
                short btn;
                btn = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                
                switch (btn)
                {
                    case 0:
                        exit = 0;
                        break;
                   
                    case 1:
                        goto login;
                        
                    case 2:


                        // Add Task

                        addTask:

                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Enter The Required Details To Add Task");
                            zTask.ParentTask = null;                                                           //  Null for ParentTask 
                            Console.WriteLine("Enter No of User to assign a task");
                            int noofUser = Convert.ToInt16(Console.ReadLine());
                             
                            for (int i = 0; i < noofUser; i++)
                            {
                                Console.Write($"{Environment.NewLine}Enter The ID Of the User : ");

                               int id = Convert.ToInt32(Console.ReadLine());
                                zTask.AssignTo.Add(id);
                            }
                            Console.Write($"{Environment.NewLine}Enter Task Id : ");
                            zTask.TaskId = Convert.ToInt64(Console.ReadLine());

                            Console.Write($"{Environment.NewLine}Enter Task Name : ");
                            zTask.TaskName = Console.ReadLine();

                            Console.Write($"{Environment.NewLine}Enter Task Description : ");
                            zTask.TaskDescription = Console.ReadLine();

                            Console.Write($"{Environment.NewLine}Enter Start Date : ");
                            zTask.StartDate = DateTime.Now;
                            Console.WriteLine(zTask.StartDate.ToShortDateString());

                            Console.Write($"{Environment.NewLine}Enter End Date : ");
                            zTask.EndDate = Convert.ToDateTime(Console.ReadLine());

                            zTask.TaskStatus = 0;
                            zTask.TaskPriority = 0;
                            zTask.TaskUpVote = 0;   
                            //  Date Checker

                            
                            if (zTask.StartDate > zTask.EndDate)
                            {
                                throw new Exception("Wrong Date Format");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Format");
                            goto addTask;
                        }


                        //  Giving input To Task Controller
                        //for (int i = 0; i < noofUser; i++)
                        //{
                                       var result = taskController.AddTask(zTask.ParentTask, zTask.AssignTo, zTask.TaskId, zTask.TaskName, zTask.TaskDescription, zTask.StartDate, zTask.EndDate, zTask.TaskPriority, zTask.TaskStatus, assignTo, zTask.TaskUpVote);
                       // }
                        
                        Console.WriteLine($"{result} row Affected");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("1.Add SubTask \n 2.exit");
                        short choose = Convert.ToInt16(Console.ReadLine()); 

                        switch(choose)
                        {
                            case 1:
                                goto subTask;
                            case 2:
                                break;
                        }
                        break;

                    case 3:


                           // Add SubTask


                        subTask:

                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Enter The Required Details To Add SubTask");

                            Console.Write($"{Environment.NewLine}Enter Parent Task Id :");
                            Console.WriteLine("Enter No of User to assign a task");
                            int n = Convert.ToInt16(Console.ReadLine());
                            zTask.ParentTask = Console.ReadLine();
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write($"{Environment.NewLine}Enter The ID Of the User : ");

                                zTask.AssignTo[i]= Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write($"{Environment.NewLine}Enter SubTask Id : ");
                            zTask.TaskId = Convert.ToInt64(Console.ReadLine());

                            Console.Write($"{Environment.NewLine}Enter SubTask Name : ");
                            zTask.TaskName = Console.ReadLine();

                            Console.Write($"{Environment.NewLine}Enter SubTask Description : ");
                            zTask.TaskDescription = Console.ReadLine();

                            Console.Write($"{Environment.NewLine}Enter Start Date : ");
                            zTask.StartDate = DateTime.Now;
                            Console.WriteLine(zTask.StartDate);

                            Console.Write($"{Environment.NewLine}Enter End Date : ");
                            zTask.EndDate = Convert.ToDateTime(Console.ReadLine());

                            zTask.TaskStatus = 0;
                            zTask.TaskPriority = 0;
                            zTask.TaskUpVote = 0;   
                            //    Date Checker

                            
                            if (zTask.StartDate > zTask.EndDate)
                            {
                                throw new Exception("Wrong Date Format");
                            }
                        }
                        catch
                        {
                            goto subTask;
                        }
                        

                        //   Giving Input to Task Controller

                        var res = taskController.AddTask(zTask.ParentTask, zTask.AssignTo, zTask.TaskId, zTask.TaskName, zTask.TaskDescription, zTask.StartDate, zTask.EndDate, zTask.TaskPriority, zTask.TaskStatus, assignTo,zTask.TaskUpVote);
                        
                        
                        Console.WriteLine($"{res} row Affected");
                        Console.ReadKey();
                        Console.Clear();
                      
                        Console.WriteLine("1.Add SubTask \n2.Exit");
                        short chose = Convert.ToInt16(Console.ReadLine());
                        
                        switch(chose)
                        {
                            case 1:
                                goto subTask;
                            case 2:
                                break;
                        }
                        break;
                    
                    
                    
                    
                    
                    
                    
                    case 4:


                       // Show Task


                        Console.WriteLine("Task List :");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("|UserId      |TaskId        |TaskName           |TaskDescription         |StartDate       |EndDate           |TaskPriority          |TaskStatus      |AssignBy  |Upvotes     |Up Voters| ");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        var  mainTask = taskController.FetchTask( userId);

                        var order = from item in mainTask
                                     orderby item.TaskUpVote
                                     descending
                                     select item;


                        foreach (var item in order)
                        {
                            if (item.TaskUpVote >= 1)
                            {
                                Console.Write($"{userId}       {item.ParentTask}          {item.TaskId}      {item.TaskName}      {item.TaskDescription}         {item.StartDate}       {item.EndDate}           {item.TaskPriority}           {item.TaskStatus}      {item.AssignBy}           {item.TaskUpVote}");
                                foreach (var voter in item.UpVoters)
                                {
                                    Console.Write($"     {Convert.ToString(voter)}");
                                   
                                }
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine($"{userId}       {item.ParentTask}          {item.TaskId}      {item.TaskName}      {item.TaskDescription}         {item.StartDate}       {item.EndDate}           {item.TaskPriority}           {item.TaskStatus}      {item.AssignBy}           {item.TaskUpVote}    ");
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                            }

                        }















                        Console.Write("Click 1 here to add your vote ");
                        int upVote = Convert.ToInt32(Console.ReadLine());
                        if (upVote == 1)
                        {
                           

                            Console.Write("Enter Task Id to Upvote");
                            int taskIdUpVote = Convert.ToInt32(Console.ReadLine());
                            
                                                        
                            if(taskIdVote.Contains(taskIdUpVote))
                            {
                                Console.WriteLine("Already Voted");
                            }
                            else
                            {
                                
                                taskController.UpVote( taskIdUpVote,userName);
                                Console.WriteLine("Voted");
                            }

                            taskIdVote.Add(taskIdUpVote);


                        }
   

                        Console.ReadKey();
                        Console.Clear();
                        break;



                    case 5:

                    //  Show SubTask

                    
                    
                    
                        Console.Write($"{Environment.NewLine}Enter Task Id : ");
                        string taskid7 = (Console.ReadLine());   
                        Console.WriteLine("Task List :");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("|UserId      |TaskId          |SubTAskId           |TaskName           |TaskDescription         |StartDate       |EndDate           |TaskPriority          |TaskStatus      |AssignBy |UpVotes|");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");

                        var subTask = taskController.FetchSubTask(taskid7);


                        foreach (var item in subTask)
                        {
                                Console.WriteLine($"{item.AssignTo}       {item.ParentTask}          {item.TaskId}      {item.TaskName}      {item.TaskDescription}         {item.StartDate}       {item.EndDate}           {item.TaskPriority}           {item.TaskStatus}      {item.AssignBy}  {item.TaskUpVote}");
                                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                        }


                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case 6:


                        //Add Comment
                        
                    
                       addComment:
                        try 
                        {
                            Console.Write($"{Environment.NewLine}Enter Your Comment : ");
                            comment.CommentContent = Console.ReadLine();

                            Console.Write($"{Environment.NewLine}Enter the Id to send Comment");
                            comment.CommentTo = Convert.ToInt32(Console.ReadLine());

                        


                        }
                        catch
                        {
                            goto addComment;
                        }
                        Console.WriteLine($"{Environment.NewLine}Enter Task Id");
                        int taskId = Convert.ToInt32(Console.ReadLine());
                        int commentBy = userId; 
                        
                       var output= commentController.AddComment(comment.CommentContent, comment.CommentTo,commentBy, taskId);

                        Console.WriteLine($"{output} Comment Added");
                        
                        Console.ReadKey();
                        Console.Clear();


                        break;

                    case 7:


                        //Show Comment


                        Console.WriteLine($"{Environment.NewLine}Enter TaskID : ");
                        int commentTaskId = Convert.ToInt32(Console.ReadLine());

                        var showComment = commentController.FetchComment(commentTaskId, userId);
                        foreach (var item in showComment)
                        {
                             
                               Console.WriteLine($"{item.TaskId}   {item.CommentContent}  {item.CommentBy}");
                        

                                int comments;
                                Console.WriteLine("1.Add Comment\n2.exit");
                                comments = int.Parse(Console.ReadLine());
                                switch (comments)
                                {
                                    case 1:
                                        goto addComment;
                                    case 2:
                                        break;

                                }
                        }
                            
                        
                        

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 8:
                       
                        
                        // set Priority
                       
                        
                        Console.WriteLine("1 for High Priority");
                        int priorityTaskId;
                        Console.Write($"{Environment.NewLine}Enter Task Id : ");
                        priorityTaskId = int.Parse(Console.ReadLine());
                        
                        Console.Write($"{Environment.NewLine}Enter Priority : ");
                        int priority= int.Parse(Console.ReadLine());
                        taskController.SetPriority(priorityTaskId, priority);

                        Console.WriteLine("Priority Updated");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 9:
                       
                        
                        
                        
                        Console.Write($"{Environment.NewLine}Enter TaskId : ");
                        int taskId5 = int.Parse(Console.ReadLine());
                        Console.Write($"{Environment.NewLine}Enter SubTaskId : ");
                        int taskId6 = int.Parse(Console.ReadLine());
                        taskController.SetSubTaskStatus(taskId5,taskId6, 1);

                        Console.WriteLine("Status Updated");

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 10:
                        
                        
                       
                      
                        Console.Write($"{Environment.NewLine}Enter TaskId : ");
                        int taskId7 = int.Parse(Console.ReadLine());
                        taskController.SetStatus(taskId7, 1);
                        
                        Console.WriteLine("Status Updated");

                        Console.ReadKey();
                        Console.Clear();
                        break;



                    default:
                        Console.WriteLine("Enter Corect Option (type number between 0 and 10)");
                        break;

                }


            } while (exit != 0);

        }
    }
}
