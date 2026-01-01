using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.CSharp.Extensions
{
    static class StringExtensions
    {
        public static string PreAppendCompanyName(this string value)
            => $"Dematic-{value}";
    }
}
