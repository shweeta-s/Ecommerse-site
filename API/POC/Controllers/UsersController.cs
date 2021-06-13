
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POC.DTOs;
using POC.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace POC.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsersController(
            ApplicationDbContext context,
            IMapper mapper, IConfiguration configuration)
        {
           
            this.context = context;
            this.mapper = mapper;
            _jwtGenerator = new JwtGenerator(configuration.GetValue<string>("JwtPrivateSigningKey"));
        }

        public class AuthenticateRequest
        {
            [Required]
            public string IdToken { get; set; }
        }

        private readonly JwtGenerator _jwtGenerator;

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest data)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            // Change this to your google client ID
            settings.Audience = new List<string>() { "425874635785-9qbseena0h69r9f6jbe7o84qpfjk6krr.apps.googleusercontent.com" };

            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(data.IdToken, settings).Result;
            return Ok(new { AuthToken = _jwtGenerator.CreateUserAuthToken(payload.Email) });
        }

        [HttpGet] // api/users      
        
        public async Task<ActionResult<List<UsersDTO>>> Get()
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            var UserDTOS = mapper.Map<List<UsersDTO>>(users);
            return UserDTOS;
        }

        [HttpGet("{Id}", Name = "getUser")] // api/users/getUsers
        public async Task<ActionResult<Users>> Get(string Id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.email == Id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<Users>(user);

            return userDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Users personCreationDTO)
        {
            var person = mapper.Map<Users>(personCreationDTO);
            context.Add(person);
            await context.SaveChangesAsync();
            var personDTO = mapper.Map<Users>(person);
            return new CreatedAtRouteResult("getUser", new { id = person.email }, personDTO);
        }

       

       
       

        




    }
}



