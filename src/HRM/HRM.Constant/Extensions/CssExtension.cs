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
        public static string GetTextAlignStyle(this Enums.TextAlign align)
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

        /// <summary>
        /// Get color css class
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string GetColorClass(this Enums.Color color)
        {
            switch (color)
            {
                case Enums.Color.Default:
                    return "default";
                case Enums.Color.Primary:
                    return "primary";
                case Enums.Color.Secondary:
                    return "secondary";
                case Enums.Color.Dark:
                    return "dark";
                case Enums.Color.Tertiary:
                    return "tertiary";
                case Enums.Color.Error:
                    return "error";
            }
            return string.Empty;
        }

        /// <summary>
        /// Get size css class
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetSizeClass(this Enums.Size size)
        {
            switch (size)
            {
                case Enums.Size.Small:
                    return "small";
                case Enums.Size.Medium:
                    return "medium";
                case Enums.Size.Large:
                    return "large";
            }
            return string.Empty;
        }

        /// <summary>
        /// Get variant css class
        /// </summary>
        /// <param name="variant"></param>
        /// <returns></returns>
        public static string GetVariantClass(this Enums.Variant variant)
        {
            switch (variant)
            {
                case Enums.Variant.Filled:
                    return "hrm-button-filled";
                case Enums.Variant.Outlined:
                    return "hrm-button-outlined";
                case Enums.Variant.Text:
                    return "hrm-button-text";
            }
            return string.Empty;
        }

        /// <summary>
        /// Get full-width css class
        /// </summary>
        /// <param name="isFullWidth"></param>
        /// <returns></returns>
        public static string GetFullWidthClass(this bool isFullWidth)
        {
            if (isFullWidth == true)
            {
                return "hrm-width-full";
            }
            return string.Empty;
        }
    }
}
