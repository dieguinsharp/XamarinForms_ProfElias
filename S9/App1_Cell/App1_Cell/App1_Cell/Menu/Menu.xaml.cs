using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu:MasterDetailPage {
        public Menu() {
            InitializeComponent();
        }
        public void GoTextCell(object sender, EventArgs args) {
            Detail = new NavigationPage(new Pagina.TextCellPage());
            IsPresented = false;
        }
        public void GoImageCell(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.ImageCellPage());
            IsPresented = false;
        }

        public void GoEntryCell(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.EntryCellPage());
            IsPresented = false;
        }

        public void GoSwitchCell(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.SwitchCellPage());
            IsPresented = false;
        }
        public void GoViewCell(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.ViewCellPage());
            IsPresented = false;
        }

        public void GoListView(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.ListViewPage());
            IsPresented = false;
        }
        public void GoListViewButton(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pagina.ListViewButtonlPage());
            IsPresented = false;
        }
    }
}