using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IDivisionRepository
    {
        IEnumerable<Division> GetDivisions();
        Division GetDivision(int id);
        int Insert(Division division);
        int Update(int id, Division division);
        int Delete(int id);

    }
}
