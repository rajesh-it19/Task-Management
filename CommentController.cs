using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;
using TaskManagementApplication.App_Data;


namespace TaskManagementApplication.Controller
{
    public class CommentController
    {
        Comment com = new Comment();
        CommentData commentData = new CommentData();

        int iteration = 0;

        //Add Comment




          public int AddComment(string comment , int commentTo, int commentBy,int taskId)
          {
            
            commentData.AddComment(comment , commentTo, commentBy, taskId);
            
            return ++iteration;
          }

         

        //  view Comment
         public List<Comment> FetchComment(int taskId , int userId)
        {
            var comment = commentData.GetComment(taskId, userId);
            return comment;
            
        }




    }
}
