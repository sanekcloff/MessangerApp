using ApplicationData.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Utilities.Generators
{
    internal static class TagGenerator
    {
        internal static string GenerateTag(string nickname)
        {
            var random = new Random();
            var tag = string.Empty;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    tag += random.Next(0, 10);
                }
                using (AppDbContext ctx = new())
                {
                    var isExist = ctx.Users.Any(u => u.Nickname == nickname && u.Tag == tag);
                    if (!isExist)
                        return tag;
                    else
                        tag = string.Empty;
                }
            }
        }
    }
}
