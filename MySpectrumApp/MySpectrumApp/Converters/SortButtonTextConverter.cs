using System;
using System.Globalization;
using Xamarin.Forms;

namespace MySpectrumApp.Converters
{
    public class SortButtonTextConverter : IValueConverter
    {
        public SortButtonTextConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = "Sort Asc";
            if (value is bool sortOrder &&
                !sortOrder)
                text = "Sort Desc";

            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

