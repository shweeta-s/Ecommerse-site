using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POC.DTOs;
using POC.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Controllers
{
    [Route("api/product")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductController(ILogger<UsersController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/product
        public async Task<ActionResult<List<Product>>> Get()
        {
            var users = await context.Product.AsNoTracking().ToListAsync();
            var UserDTOS = mapper.Map<List<Product>>(users);
            return UserDTOS;
        }

    }
}
