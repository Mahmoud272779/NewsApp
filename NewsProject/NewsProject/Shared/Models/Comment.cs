using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public string CommentDetail { get; set; }
        public int newsListId { get; set; }
        public NewsList? newsList { get; set; }
    }
}
