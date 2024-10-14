using ApplicationData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApplicationData.Utilities.EntityCheckups
{
    internal static class UserChekup
    {
        internal static Exception CheckupUser(User user)
        {
            if (!Regex.IsMatch(user.Nickname, "^[A-Za-z]+$"))
                return new Exception("Nickname может включать сиволы A - Z");
            return null!;
        }
    }
}
