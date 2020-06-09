using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlideStipperPage : ContentPage
    {
        public SlideStipperPage()
        {
            InitializeComponent();
        }

        private void modifyValue(object sender, ValueChangedEventArgs args)
        {
            lblSliderresult.Text = args.NewValue.ToString();
        }

        private void newStepper(object sender, ValueChangedEventArgs args)
        {
            lblNewStepper.Text = args.NewValue.ToString();
        }
    }
}