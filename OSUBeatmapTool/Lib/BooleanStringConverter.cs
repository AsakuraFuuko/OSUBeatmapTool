using System;
using System.Windows.Data;

namespace OSUBeatmapTool.Lib
{
    public class BooleanStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //0 = Ranked, 3 = Ranked / Approved, 6 = Approved, 7 = Unranked (Others)
            int status = (int)value;
            switch (status)
            {
                case 0: return "Ranked";
                case 3: return "Ranked / Approved";
                case 6: return "Approved";
                default: return "Unranked";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}