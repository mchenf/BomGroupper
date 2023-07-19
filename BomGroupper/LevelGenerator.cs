using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomGroupper
{
    public static class LevelGenerator
    {
        public static string GetLevelString(int level)
        {
            if (level < 1) return string.Empty;

            return new string('.', level) + level.ToString();
        }

        public static bool TryParseLevel(string level, out int result)
        {
            result = -1;
            if (string.IsNullOrEmpty(level)) return false;

            int len = level.Length;
            if (len < 2) return false;

            if(!level.StartsWith(".")) { return false; }

            int i = 0;
            while (level[i] == '.')
            {
                i++;
            }

            string shouldBe = GetLevelString(i);

            if (shouldBe != level) return false;

            result = i;
            return true;
        }
    }
}
