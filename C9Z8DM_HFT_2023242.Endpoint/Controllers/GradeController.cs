using C9Z8DM_HFT_2023242.Logic;
using C9Z8DM_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace C9Z8DM_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        IGradeLogic logic;

        public GradeController(IGradeLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Grade> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Grade Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Grade value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Grade value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
