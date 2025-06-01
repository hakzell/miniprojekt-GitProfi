using smartwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartwork.Data.Services;

public interface IRepository
{
    List<Project> Get();

    bool Delete(Project p); // löschen
    bool Save(Project project);
}
