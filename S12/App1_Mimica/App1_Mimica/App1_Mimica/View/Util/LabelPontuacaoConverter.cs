using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.View.Util {
    public class LabelPontuacaoConverter:IValueConverter {
        public object Convert(object value,Type targetType,object parameter,CultureInfo culture) {
            if ((byte)value == 0) {
                return "Valor do Acerto: ...";
            } else {
                return "Valor do Acerto: " + value;
            }     
        }

        public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
