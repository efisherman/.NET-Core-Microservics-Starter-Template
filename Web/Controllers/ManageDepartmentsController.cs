﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/admin/departments")]
    public class ManageDepartmentsController : Controller
    {
        [HttpGet] 
        public IActionResult GetDepartments()
        {
            var list = new List<DepartmentItemViewModel>
            {
                new DepartmentItemViewModel
                {
                     Id = Guid.NewGuid(),
                     Title = "aaaa aaaaa",
                     Description = "rrrrrrrrrrrr rrrrr",
                }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("{departmentId:guid}")]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertDepartment(AddDepartmentViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{departmentId:guid}")]
        public IActionResult GetDepartment(Guid departmentId)
        {
            var model = new EditDepartmentViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aaa",
                Description = "asssssddddddd ddd",
                Importance = 4,
                Title = "rrrr"
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("{departmentId:guid}")]
        public IActionResult UpdateDepartment(Guid departmentId, EditDepartmentViewModel model)
        {
            return Ok();
        }
    }
}