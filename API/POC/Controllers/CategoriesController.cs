using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POC.DTOs;
using POC.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace POC.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly ILogger<CartController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoriesController(
            ApplicationDbContext context,
            IMapper mapper)
        {
          
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet] // api/categories
        public async Task<ActionResult<List<CategoriesDTO>>> Get()
        {
            var users = await context.Categories.AsNoTracking().ToListAsync();
            var UserDTOS = mapper.Map<List<CategoriesDTO>>(users);
            return UserDTOS;
        }

    }
}
