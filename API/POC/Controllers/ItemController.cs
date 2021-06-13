using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POC.DTOs;
using POC.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace POC.Controllers
{
    [Route("api/Item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemController(ILogger<ItemController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {

            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{Id:int}", Name = "getItem")]
        public IQueryable<Item> Get(int Id)
        {
            var user = context.Item.Where(x => x.cart_id == Id);
            return user;                
        }

        [HttpGet]
        public IQueryable Get()
        {
            
            var query = from i in context.Item
                        join p in context.Product on i.product_id equals p.product_id
                        select new { i.cart_id, i.quantity, p.product_name, p.imageurl, p.amount };

            return query;
        }
        


    }

   
}
