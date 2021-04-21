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
    public class DepartmentsController : ApiController
    {
        DepartmentRepository departmentRepository = new DepartmentRepository();

        //POST
        public IHttpActionResult Post(Department department)
        {
            try { 
                var post = departmentRepository.Insert(department);
                if(post == 1)
                {
                    return Ok("Data Berhasil Dimasukkan");
                }
                else
                {
                    return BadRequest("Error");
                }
            } 
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return BadRequest("Data Gagal Dimasukkan : Nama Kolom Salah ");
            }
        }

        //GET
        public IHttpActionResult Get()
        {
            var get = departmentRepository.GetDepartments();
            if (get.Count() == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data tidak ditemukan");
            }
            else
            {
                return Ok(get);
            }
        }

        //GET BY ID
        public IHttpActionResult GetById(int id)
        {
            var get = departmentRepository.GetDepartment(id);
            if (get == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound,($"Data dengan id = {id} tidak ditemukan")));
            } 
                return Ok(get);
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            // pilh id yang di delete
            var get = departmentRepository.GetDepartment(id);
            if (get == null)
            {
                return Content(HttpStatusCode.NotFound, "Data tidak ditemukan");
            }
            else {
                departmentRepository.Delete(id);
                return Ok("Berhasil Delete");
            }
        }

        //UPDATE
        [HttpPut]
        [ActionName("Edit")]
        public IHttpActionResult Put(int id, Department department)
        {
            try { 
                var update = departmentRepository.Update(id, department);
                if (update == 1)
                {
                    // kalau datanya beda
                    return Ok("Data berhasil diubah");
                }
                else 
                {
                    // kalau datanya sama
                    return Ok("Data berhasil diubah : datanya sama");        
                }
            } catch (System.NullReferenceException)
            {
                // Id nya tidak ada
                return Content(HttpStatusCode.NotFound, "Data tidak ditemukan");
            } 
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                // Nama Kolom Beda
                return BadRequest("Data gagal diubah");
            }
        }

    }
}
