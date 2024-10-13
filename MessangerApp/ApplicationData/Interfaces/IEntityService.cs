using ApplicationData.Core.Context;
using ApplicationData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Interfaces
{
    public abstract class IEntityService<T> where T : class
    {
        public abstract string Create(User user, AppDbContext context);
    }
}
