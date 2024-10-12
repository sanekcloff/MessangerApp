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
    public class ChatHandler : IEntityHandler<Chat>
    {
        public Chat GetEntity(Chat entity, AppDbContext context) => context.Chats.FirstOrDefault(entity);

        public string Add(Chat entity, AppDbContext context)
        {
            try
            {
                context.Chats.Add(entity);
                context.SaveChanges();
                return "Чат добавлен!";
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }

        public string Delete(Chat entity, AppDbContext context)
        {
            try
            {
                entity.IsDeleted = true;
                context.Chats.Update(entity);
                context.SaveChanges();
                return "Чат удалён!";
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }

        public string Update(Chat entity, AppDbContext context)
        {
            try
            {
                context.SaveChanges();
                context.Chats.Update(entity);
                return "Чат обновлён!";
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}
