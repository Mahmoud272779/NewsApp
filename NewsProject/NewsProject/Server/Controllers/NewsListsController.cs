using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Dtos;
using NewsProject.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsListsController : ControllerBase
    {
        private readonly MainInteface<NewsList> _newsList;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsListsController(MainInteface<NewsList> newsList, IWebHostEnvironment webHostEnvironment)
        {
            _newsList = newsList;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<NewsListsController>
        [HttpGet]
        public IActionResult GetAllNewsList()
        {
            return Ok(_newsList.GetAllDate("category"));
        }
        [HttpGet]
        public IActionResult GetAllNewsListByCategory(int id)
        {
            return Ok(_newsList.GetAllDate("category").Where(nl=> nl.categoryId == id));
        }
        [HttpGet]
        public IActionResult GetAllNewsListByTitle(string Title)
        {
            return Ok(_newsList.GetAllDate("category").Where(nl => nl.category.CategoryName.Contains(Title)));
        }
        // GET api/<NewsListsController>/5
        [HttpGet("{id}")]
        public IActionResult GetNewById(int id)
        {
            return Ok(_newsList.GetAllDate("category").Where(nl => nl.Id == id));
        }

        // POST api/<NewsListsController>
        [HttpPost]
        public async Task<IActionResult> AddNews([FromForm] NewsListDto modelDto)
        {
            string FileName = "";
            if (modelDto.NewImg != null)
            {
                string FullPath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsImages");
                if (!Directory.Exists(FullPath))
                {
                    Directory.CreateDirectory(FullPath);
                }
                FileName = Guid.NewGuid() + "_" + modelDto.NewImg.FileName;
                string ImagePath = Path.Combine(FullPath, FileName);
                using(var stream = new FileStream(ImagePath, FileMode.Create))
                {
                    await modelDto.NewImg.CopyToAsync(stream);
                    stream.Dispose();
                }
            }
            NewsList model = new NewsList()
            {
                Title = modelDto.Title,
                SubTitle = modelDto.SubTitle,
                ShortDetails = modelDto.ShortDetails,
                Details = modelDto.Details,
                categoryId = modelDto.categoryId,
                ImgPath= FileName
            };
            _newsList.AddRow(model);
            return Ok(model);
        }

        // PUT api/<NewsListsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateNews(int id, [FromBody] NewsList model)
        {
            _newsList.UpdateRow(model);
            return Ok(model);
        }

        // DELETE api/<NewsListsController>/5
        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _newsList.DeleteRow(id);
        }
    }
}
