using API.Context;
using API.Models;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        myContext context = new myContext();

        public int Delete(int id)
        {
            var getByid = context.Departments.Find(id);
            context.Departments.Remove(getByid);
            var delete = context.SaveChanges();
            return delete;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var get = context.Departments.Include("Division").ToList();
            return get;
        }

        public Department GetDepartment(int id)
        {
            var get = context.Departments.Include("Division").FirstOrDefault(d => d.id == id);
            return get;
        }

        public int Insert(Department department)
        {
            context.Departments.Add(department);
            var insert = context.SaveChanges();
            return insert;
        }

        public int Update(int id, Department department)
        {
            var get = context.Departments.Find(id);
            get.id = department.id;
            get.name = department.name;
            get.Division_id = department.Division_id;

            var save = context.SaveChanges();
            return save;
        }
    }
}