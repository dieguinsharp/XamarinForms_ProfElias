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
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            /* Image img = new Image();
            if(Device.RuntimePlatform == Device.iOS) {
                img.Source = ImageSource.FromFile("usb.jpg");
            } else {

            }*/

            Image img = new Image();
            img.Source = ImageSource.FromFile("usb.jpg");
            container.Children.Add(img);
        }
    }
}