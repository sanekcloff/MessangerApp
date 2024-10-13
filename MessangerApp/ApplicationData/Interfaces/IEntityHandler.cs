using ApplicationData.Core.Context;
using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Interfaces
{
    public interface IEntityHandler<T> where T : class
    {
        T GetEntity(T entity, AppDbContext context);
        (string,string) Add(T entity, AppDbContext context);
        string Update(T entity, AppDbContext context);
        string Delete(T entity, AppDbContext context);
        bool IsIdentity(T entity) => entity == null;
    }
}
