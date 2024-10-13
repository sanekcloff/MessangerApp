using ApplicationData.Core.Context;
using ApplicationData.Interfaces;
using ApplicationData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Handlers
{
    public class UserHandler : IEntityHandler<User>
    {
        public  User GetEntity(User entity, AppDbContext context) => context.Users.FirstOrDefault(entity);
        
        public string Add(User entity, AppDbContext context)
        {
            try
            {
                context.Users.Add(entity);
                context.SaveChanges();
                return "Пользователь добавлен!";
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }

        public string Delete(User entity, AppDbContext context)
        {
            try
            {
                entity.IsDeleted = true;
                context.Users.Update(entity);
                context.SaveChanges();
                return "Пользователь удалён!";
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }

        public string Update(User entity, AppDbContext context)
        {
            try
            {
                context.SaveChanges();
                context.Users.Update(entity);
                return "Пользователь обновлён!";
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }
    }
}
