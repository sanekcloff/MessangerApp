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
    public class MessageHandler : IEntityHandler<Message>
    {
        public Message GetEntity(Message entity, AppDbContext context) => context.Messages.FirstOrDefault(entity);

        public (string, string) Add(Message entity, AppDbContext context)
        {
            try
            {
                context.Messages.Add(entity);
                context.SaveChanges();
                return ("Сообщение добавлено!", "DEBUG: Операция успешна!");
            }
            catch (Exception ex)
            {

                return ($"{ex.Message}", "");
            }
        }

        public string Delete(Message entity, AppDbContext context)
        {
            try
            {
                entity.IsDeleted = true;
                context.Messages.Update(entity);
                context.SaveChanges();
                return "Сообщение удалёно!";
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }

        public string Update(Message entity, AppDbContext context)
        {
            try
            {
                context.SaveChanges();
                context.Messages.Update(entity);
                return "Сообщение обновлёно!";
            }
            catch (Exception ex)
            {

                return $"{ex.Message}";
            }
        }
    }
}
