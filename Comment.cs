using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApplication.Model
{
    public class Comment
    {
        public string? ParentComment { get; set; }                         
       
        public int CommentTo { get; set; }
       
        public int CommentBy { get; set; } 

        public int TaskId { get; set; }
       
        public string CommentContent { get; set; }
    }
}
