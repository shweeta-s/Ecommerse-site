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
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CartController(ILogger<CartController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {
           
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/Cart
        public async Task<ActionResult<List<Cart>>> Get()
        {
            var users = await context.Cart.AsNoTracking().ToListAsync();
            var UserDTOS = mapper.Map<List<Cart>>(users);
            return UserDTOS;
        }

        
        [HttpGet("{Id:int}", Name = "getCart")] 
        public async Task<ActionResult<Cart>> Get(int Id)
        {
            var user = await context.Cart.FirstOrDefaultAsync(x => x.cart_id== Id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Cart>(user);

            return userDTO;
        }
        
        [HttpGet("{Id},{productId}",Name = "getQuantity")]
        public async Task<ActionResult<Item>> GetQuantity(int Id, int productId)
        {
            var item = await context.Item.FirstOrDefaultAsync(x => x.cart_id == Id && x.product_id== productId);

            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = mapper.Map<Item>(item);

            return itemDTO;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CartCreationDTO personCreationDTO)
        {
            var person = mapper.Map<Cart>(personCreationDTO);
            context.Add(person);
            await context.SaveChangesAsync();
            var personDTO = mapper.Map<Cart>(person);
            return new CreatedAtRouteResult("getCart", new { id = person.cart_id }, personDTO);
        }

        [HttpPut ("{id:int}")]
        public async Task<ActionResult> Put( int id,[FromBody] Product product, string action)
        {
            
            var cart = await context.Cart.FirstOrDefaultAsync(x => x.cart_id == id );
            if (cart == null)
            {
                return NotFound();
            }
            if (action.Equals("add")) {

                var item = context.Item.Find(id, product.product_id);
                if (item != null)
                {
                    item.quantity += 1;
                    context.Update(item);
                }
                else
                {
                    item = new Item();
                    item.cart_id = id;
                    item.quantity += 1;
                    item.product_id = product.product_id;
                    context.Item.Add(item);
                }


            }
            else {

                var item = context.Item.Find(id, product.product_id);
                if (item != null)
                {
                    item.quantity -= 1;
                    context.Update(item);
                }
                


            }
            
                      
            await context.SaveChangesAsync();
            var personDTO = mapper.Map<Cart>(cart);
            return new CreatedAtRouteResult("getCart", new { id = cart.cart_id }, personDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await context.Cart.FirstOrDefaultAsync(x => x.cart_id == id);
            if (user==null)
            {
                return NotFound();
            }

            context.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
