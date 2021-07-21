using Microsoft.AspNetCore.Mvc;
using DatingAppNew.Data;
using System.Collections.Generic;
using DatingAppNew.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatingAppNew.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly DatingDbContext _dbContext;

        public UsersController(DatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users;
        }

        //api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user;
        }
    }
}
