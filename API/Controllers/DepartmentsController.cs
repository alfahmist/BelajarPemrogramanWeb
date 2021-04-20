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
            var post = departmentRepository.Insert(department);
            if(post == 1)
            {
                return Ok("Data Berhasil Dimasukkan");
            }

            return BadRequest("Data Gagal DiMasukkan");
        }

        //GET
        public IHttpActionResult get()
        {
            var get = departmentRepository.GetDepartments();
            if (get.Count() == 0)
            {
                return BadRequest("Belum input apa apa");
            }
            else
            {
                return Ok(get);
            }
        }

        //GET BY ID
        public IHttpActionResult getById(int id)
        {
            var get = departmentRepository.GetDepartment(id);
            if (get == null)
            {
                return BadRequest("Data Tidak Ditemukan");
            } else
            {
                return Ok(get);
            }
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {

            var get = departmentRepository.GetDepartment(id);
            if (get == null)
            {
                return BadRequest("Data Tidak Ditemukan");
            }
            else
            {
                departmentRepository.Delete(id);
                return Ok("Berhasil Delete");
            }
           
        }

        //UPDATE
        public IHttpActionResult PutDepartment(int id, Department department)
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
                return BadRequest("Data tidak ditemukan");
            } 
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                // Nama Kolom Beda
                return BadRequest("Nama Kolom Beda");
            }
        }

    }
}
