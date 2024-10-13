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
        internal static string GenerateTag(string nickname, Random random, AppDbContext context)
        {
            var tag = string.Empty;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    tag += random.Next(0, 10);
                }
                var isExist = context.Users.Any(u => u.Nickname == nickname && u.Tag == tag);
                if (!isExist)
                    return tag;
                else
                    tag = string.Empty;
            }
        }
    }
}
