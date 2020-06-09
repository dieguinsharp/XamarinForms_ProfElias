using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage {
        public Menu() {
            InitializeComponent();
        }

        private void openActivyIndicator(object sender, EventArgs args) {
            Detail = new NavigationPage(new Conteudo.ActivityIndicatorPage());
            IsPresented = false;
        }

        private void openProgressBar(object sender, EventArgs args) {
            Detail = new NavigationPage(new Conteudo.ProgressBarPage());
            IsPresented = false;
        }

        private void openBoxView(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.BoxViewPage());
            IsPresented = false;
        }

        private void openLabel(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.LabelPage());
            IsPresented = false;
        }

        private void openButton(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.ButtonPage());
            IsPresented = false;
        }

        private void openEntryEditor(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.EntryEditPage());
            IsPresented = false;
        }

        private void openDatePicker(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.DatePickerPage());
            IsPresented = false;
        }

        private void openTimePicker(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.TimePickerPage());
            IsPresented = false;
        }

        private void openPicker(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.PickerPage());
            IsPresented = false;
        }

        private void openSearchBar(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Conteudo.SearchBarPage());
            IsPresented = false;
        }

        private void openSlideStipper(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Conteudo.SlideStipperPage());
            IsPresented = false;
        }

        private void openSwitch(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Conteudo.SwitchPage());
            IsPresented = false;
        }

        private void openImage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Conteudo.ImagePage());
            IsPresented = false;
        }

        private void openListView(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.ListViewPage());
            IsPresented = false;
        }

        private void openTabbleViewPage(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.TabbleViewPage());
            IsPresented = false;
        }

        private void openWebViewPage(object sender,EventArgs args) {
            Detail = new NavigationPage(new Conteudo.WebViewPage());
            IsPresented = false;
        }
    }
}