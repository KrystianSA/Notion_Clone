using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbModels;
using Notion_Clone.Api.Services;

namespace Notion_Clone.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly ListService _listService;
        public ListController(ListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public async Task<List<Exercise>> Get() =>
        await _listService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Exercise newTask)
        {
            await _listService.CreateAsync(newTask);
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }
    }
}
