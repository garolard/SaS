using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace SaS.Converter
{
    public class StringToColorConverter : IValueConverter
    {
        private static Regex _hexColorMatchRegex = new Regex("^#?(?<a>[a-z0-9][a-z0-9])?(?<r>[a-z0-9][a-z0-9])(?<g>[a-z0-9][a-z0-9])(?<b>[a-z0-9][a-z0-9])$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static Dictionary<string, Brush> _brushCache = new Dictionary<string, Brush>();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var colorStr = ((string)value).ToLower();

            lock (_brushCache)
            {
                if (!_brushCache.ContainsKey(colorStr))
                    _brushCache.Add(colorStr, new SolidColorBrush(HtmlStringToColor(colorStr)));

                return _brushCache[colorStr];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private Color HtmlStringToColor(string hexColorString)
        {
            if (hexColorString == null)
                throw new NullReferenceException("Hex string can't be null.");

            // Regex match the string
            var match = _hexColorMatchRegex.Match(hexColorString);

            if (!match.Success)
                throw new InvalidCastException(string.Format("Can't convert string \"{0}\" to argb or rgb color. Needs to be 6 (rgb) or 8 (argb) hex characters long. It can optionally start with a #.", hexColorString));

            // a value is optional
            byte a = 255, r = 0, b = 0, g = 0;
            if (match.Groups["a"].Success)
                a = System.Convert.ToByte(match.Groups["a"].Value, 16);
            // r,b,g values are not optional
            r = System.Convert.ToByte(match.Groups["r"].Value, 16);
            b = System.Convert.ToByte(match.Groups["b"].Value, 16);
            g = System.Convert.ToByte(match.Groups["g"].Value, 16);
            return Color.FromArgb(a, r, g, b);
        }

    }
}
