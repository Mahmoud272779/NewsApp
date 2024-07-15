using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos
{
    public class NewsListDto
    {
        public int Id { get; set; }
        public DateTime NewDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ShortDetails { get; set; }
        public string Details { get; set; }
        public IFormFile NewImg { get; set; }
        public string? ImgPath { get; set; }
        public int categoryId { get; set; }
    }
}
