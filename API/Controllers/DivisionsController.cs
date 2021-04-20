using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BelajarPemrogramanWeb.Controllers
{
    public class DivisionsController : ApiController
    {
        DivisionRepository divisionRepository = new DivisionRepository();

        //INSERT
        public IHttpActionResult Post(Division division)
        {
            var post = divisionRepository.Insert(division);
            return Ok(post);
        }    

        //GET
        public IHttpActionResult get()
        {
            var get = divisionRepository.GetDivisions();
            return Ok(get);
        } 

        //GET BY ID
        public IHttpActionResult getById(int id)
        {
            var get = divisionRepository.GetDivision(id);
            return Ok(get);
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var delete = divisionRepository.Delete(id);
            return Ok(delete);
        }

        //UPDATE
        public IHttpActionResult PutDivision(int id, Division division)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != division.id)
            {
                return BadRequest("Ids did not match");
            }
            var update = divisionRepository.Update(id, division);
            return Ok(update);
        }
    }
}
