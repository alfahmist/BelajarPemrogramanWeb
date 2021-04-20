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
        IEnumerable<Division> GetDivions();

        Division GetDivision(int id);

        int Insert(Division divison)
        int Update(Division division);
        int Delete(Division division);

    }
}
