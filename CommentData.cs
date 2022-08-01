using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;

namespace TaskManagementApplication.App_Data
{
    public class CommentData
    {

        //  Comment Repository



        Comment comment = new Comment();
        private static List<Comment> _comment = new List<Comment>();

   

        int iteration = 0;
        public int AddComment(string cmt, int commentTo, int commentBy, int taskId)
        {

            int count = 0;
            foreach (var item in CommentData._comment)
            {
                if (comment.TaskId == taskId)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                comment.ParentComment = null;
            }
            else
            {
                comment.ParentComment = taskId.ToString();
            }
            comment.TaskId = taskId;
            comment.CommentTo = commentTo;
            comment.CommentContent = cmt;
            comment.CommentBy = commentBy;

            CommentData._comment.Add(comment);

            return ++iteration;
        }

        public List<Comment> GetComment(int taskId , int userId)
        {
            var comment = _comment.Where(comment => comment.TaskId == taskId && comment.CommentTo == userId).ToList(); 
            return comment;
        }



    }
}
