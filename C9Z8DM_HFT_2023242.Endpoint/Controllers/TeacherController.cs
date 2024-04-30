﻿using C9Z8DM_HFT_2023242.Logic;
using C9Z8DM_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace C9Z8DM_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherLogic logic;

        public TeacherController(ITeacherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Teacher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Teacher Real(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Teacher value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Teacher value)
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
