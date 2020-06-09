using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_LayoutXL {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage :ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void openAbsolute(object sender, EventArgs args) {
            Navigation.PushAsync(new Layouts.Absolute.AbsolutePage());
        }
        private void openGrid(object sender,EventArgs args) {
            Navigation.PushAsync(new Layouts.Grid.GridPage());
        }
        private void openRelative(object sender,EventArgs args) {
            Navigation.PushAsync(new Layouts.Relative.RelativePage());
        }
        private void openScroll(object sender,EventArgs args) {
            Navigation.PushAsync(new Layouts.Scroll.ScrollPage());
        }
        private void openStack(object sender,EventArgs args) {
            Navigation.PushAsync(new Layouts.StackLayout.StackPage());
        }
    }
}
