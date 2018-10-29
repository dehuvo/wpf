using System;
using System.Windows.Data;
using System.Globalization;

namespace Converter_227 {
  class YesNoToBoolConverter : IValueConverter {
    public object Convert(object value, Type tergetType, object param, CultureInfo culture) {
      return value.ToString() == "Yes";
    }

    public object ConvertBack(object value, Type tergetType, object param, CultureInfo culture) {
      return value is bool && (bool) value ? "Yes" : "No";
    }
  }
}