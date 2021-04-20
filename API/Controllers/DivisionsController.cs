using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BelajarPemrogramanWeb.Controllers
{
    public class DivisionsController : ApiController
    {
        DivisionRepository divisionRepository = new DivisionRepository();

        public IHttpActionResult Post(Division division)
        {
            var post = divisionRepository.Insert(division);
            return Ok(post);
        }    

        public IHttpActionResult get()
        {
            var get = divisionRepository.GetDivisions();
            return Ok(get);
        }
    }
}
