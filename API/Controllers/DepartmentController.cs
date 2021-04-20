using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartmentController : ApiController
    {
        DepartmentRepository departmentRepository = new DepartmentRepository();

        //POST
        public IHttpActionResult Post(Department department)
        {
            var post = departmentRepository.Insert(department);
            return Ok(post);
        }

        //GET
        public IHttpActionResult get()
        {
            var get = departmentRepository.GetDepartments();
            return Ok(get);
        }

        //GET BY ID
        public IHttpActionResult getById(int id)
        {
            var get = departmentRepository.GetDepartment(id);
            return Ok(get);
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var delete = departmentRepository.Delete(id);
            return Ok(delete);
        }

        //UPDATE
        public IHttpActionResult PutDivision(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.id)
            {
                return BadRequest("Ids did not match");
            }
            var update = departmentRepository.Update(id, department);
            return Ok(update);
        }

    }
}
