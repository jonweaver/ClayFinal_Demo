using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupDemo.Data;
using GroupDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GroupDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
       

        private readonly ILogger<ApiController> _logger;
        private readonly ApplicationContext _dbContext;

        public ApiController(ILogger<ApiController> logger, ApplicationContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet()]
        public async Task<ActionResult> GetEvents()
        {
            //we can look up a group by group name
            var group = await _dbContext.Groups.Where(g => g.GroupName == "some group name").FirstOrDefaultAsync();

            //then we can get all of the events for that group
            var eventsForThisGroup = group.Events.ToList();

            //or get the people in that group
            var peopleInTheGroup = group.GroupMembers.ToList();

            //we can add people to the group
            group.GroupMembers.Add(new GroupMember { Name = "steve" });

            //just save any changes we make
            await _dbContext.SaveChangesAsync();


            //you can also update a groupMember and save it

            var gm = await _dbContext.GroupMembers.Where(g => g.Name == "steve").FirstOrDefaultAsync();

            gm.Name = "SteveO";
            await _dbContext.SaveChangesAsync();

            return new OkResult();

        }
    }
}
