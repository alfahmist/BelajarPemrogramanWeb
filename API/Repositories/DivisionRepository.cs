using API.Context;
using API.Models;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class DivisionRepository : IDivisionRepository
    {
        myContext context = new myContext();
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Division GetDivision(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Division> GetDivisions()
        {
            var get = context.Divisions.ToList();
            return get;

        }

        public int Insert(Division division)
        {
            context.Divisions.Add(division);
            var insert = context.SaveChanges();
            return insert;
        }

        public int Update(int id, Division division)
        {
            throw new NotImplementedException();
        }
    }
}