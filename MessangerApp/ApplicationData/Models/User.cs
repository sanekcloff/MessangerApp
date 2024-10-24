using ApplicationData.Core.Context;
using ApplicationData.Utilities.Converters;
using ApplicationData.Utilities.Enums;
using ApplicationData.Utilities.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ApplicationData.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public byte[]? Image { get; set; } = null!;
        public string Color { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty; 
        public string Tag { get; set; } = string.Empty;
        public string? CustomStatus { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        
        public Statuses Status { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsOnline { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = null!;

        [NotMapped]
        public string Username => $"{Nickname}#{Tag}";
        public string DisplayStatus => string.IsNullOrEmpty(CustomStatus) ? "Указать статус" : $"{CustomStatus}";
        public ImageBrush DisplayImage
        {
            get
            {
                if (Image==null)
                {
                    return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/UI;component/Assets/Icons/Controls/Patch/UserPatch.png")));
                }
                else
                {
                    return new ImageBrush(ImageConverter.GetBitmapImage(Image));
                }
            }
        }
        public bool WithAvatar { get; }
        public string CreationDateFormated => CreationDate.ToString("f");
        public string LastActiveFormated => CreationDate.ToString("f");

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                Debug.WriteLine("DEBUG: Объект сравнения имеет значение NULL!");
                return false;
            }
            else if (GetType() != obj.GetType())
            {
                Debug.WriteLine("DEBUG: Объекты имеют разные типы данных!");
                return false;
            }
            var entity = (User)obj;

            return Email == entity.Email;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nickname, Tag);
        }
    }
}
