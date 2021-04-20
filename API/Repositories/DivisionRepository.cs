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

        //DELETE
        public int Delete(int id)
        {
            // dapetin id nya
            var getByid = context.Divisions.Find(id);
            // execute delete
            context.Divisions.Remove(getByid);
            var delete = context.SaveChanges();
            return delete;
        }

        //GET BY ID
        public Division GetDivision(int id)
        {
            // dapetin id nya
            var getByid = context.Divisions.Find(id);
            return getByid;
        }

        //GET
        public IEnumerable<Division> GetDivisions()
        {
            var get = context.Divisions.ToList();
            return get;
        }

        //INSERT
        public int Insert(Division division)
        {
            context.Divisions.Add(division);
            var insert = context.SaveChanges();
            return insert;
        }

        //UPDATE
        public int Update(int id, Division division)
        {
            var get = context.Divisions.Find(id);
            get.id = division.id;
            get.name = division.name;
            get.about = division.about;

            var save = context.SaveChanges();
            return save;
        }
    }
}