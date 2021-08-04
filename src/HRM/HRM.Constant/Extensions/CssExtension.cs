using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Constant.Extensions
{
    public static class CssExtension
    {
        /// <summary>
        /// Return style
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        public static string GetTextAlign(this Enums.TextAlign align)
        {
            switch (align)
            {
                case Enums.TextAlign.Unset:
                    return string.Empty;
                case Enums.TextAlign.Left:
                    return "text-align: left;";
                case Enums.TextAlign.Center:
                    return "text-align: center;";
                case Enums.TextAlign.Right:
                    return "text-align: right;";
                case Enums.TextAlign.Justify:
                    return "text-align: justify;";
            }
            return string.Empty;
        }
    }
}
