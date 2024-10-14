using ApplicationData.Core.Context;
using ApplicationData.Interfaces;
using ApplicationData.Models;
using ApplicationData.Utilities.EntityCheckups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Handlers
{
    internal class UserHandler : IEntityHandler<User>
    {
        // Проверка на существование пользователя в БД
        public User GetEntity(User entity, AppDbContext context) => context.Users.FirstOrDefault(e=>e.Email == entity.Email)!;
        // Добавление пользьзователя
        public (string,string) Add(User entity, AppDbContext context)
        {
            try
            {
                // Проверка на ввод
                var exception = UserChekup.CheckupUser(entity);
                if (exception != null) 
                    throw exception;
                var user = GetEntity(entity, context);
                // Вызов метода IsIdentity через явную реализацию
                if (((IEntityHandler<User>)this).IsIdentity(user))
                {
                    context.Users.Add(entity);
                    context.SaveChanges();
                    return ("DEBUG: Пользователь добавлен!","DEBUG: Операция выполнена!");
                }
                else
                {
                    return ("DEBUG: Пользователь уже существует", "DEBUG: Операция не выполнена!");
                }
                    
            }
            catch (Exception ex)
            {

                return ($"DEBUG: {ex.Message}",$"DEBUG: В {this} возникло исключение");
            }
        }
        // Удаление пользьзователя
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
        // Изменение пользьзователя
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
