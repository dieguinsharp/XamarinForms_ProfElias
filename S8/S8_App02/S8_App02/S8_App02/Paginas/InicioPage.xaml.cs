using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S8_App02.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace S8_App02.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage:ContentPage {
        public InicioPage() {
            InitializeComponent();
            CultureInfo culture = new CultureInfo("pt-br");
            string data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy",culture);
            dtDataHoje.Text = string.Format(data,"de");
            carregarTarefas();
        }

        private void carregarTarefas() {
            SLTarefas.Children.Clear();    
            List<Tarefa> list = new Armazenamento().listagem();
            int i = 0;
            foreach (Tarefa tarefa in list) {
                linhaStackLayout(tarefa, i);
                i++;
            }
        }

        private void openCadastro(object sender, EventArgs args) {
            Navigation.PushAsync(new CadastroPage());
        }

        public void linhaStackLayout(Tarefa tarefa, int i) {
            Image imageDelete = new Image() { VerticalOptions = LayoutOptions.Center,Source = "Delete.png",BackgroundColor = Color.Transparent };
            if(Device.RuntimePlatform == Device.iOS) {
                imageDelete.Source = ImageSource.FromFile("Resources/Delete.png");
            }

            TapGestureRecognizer deletetap = new TapGestureRecognizer();
            deletetap.Tapped += delegate {
                new Armazenamento().Deletar(i);
                carregarTarefas();
            };

            imageDelete.GestureRecognizers.Add(deletetap);

            Image imagePrioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = "p" + tarefa.prioridade + ".png",BackgroundColor = Color.Transparent };
            if(Device.RuntimePlatform == Device.iOS) {
                imagePrioridade.Source = ImageSource.FromFile("Resources/p" + tarefa.prioridade +".png");
            }
            View StackCentral = null;
            if(tarefa.dataFim == null) {
                StackCentral = new Label() { VerticalOptions = LayoutOptions.Center,FontSize = 15,HorizontalOptions = LayoutOptions.FillAndExpand,Text = tarefa.nome, TextColor = Color.Black};
            }else {
                StackCentral = new StackLayout() { VerticalOptions = LayoutOptions.Center,HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = tarefa.nome, TextColor = Color.Gray, FontSize=15});
                ((StackLayout)StackCentral).Children.Add(new Label() { Text = "Finalizado em " + tarefa.dataFim.Value.ToString("dd/MM/yyyy - hh:mm") + "h",TextColor = Color.Gray,FontSize = 10 });
            }
            


            Image imageCheck = new Image() { VerticalOptions = LayoutOptions.Center,Source = "CheckOff.png",BackgroundColor = Color.Transparent };
            if (Device.RuntimePlatform == Device.iOS) {
                if(tarefa.dataFim != null) {
                    imageCheck.Source = ImageSource.FromFile("Resources/CheckOn.png");
                } else {
                    imageCheck.Source = ImageSource.FromFile("Resources/CheckOff.png");
                }     
            }
            if (tarefa.dataFim != null) {
                imageCheck.Source = ImageSource.FromFile("Resources/CheckOn.png");
            }


            TapGestureRecognizer checkModf = new TapGestureRecognizer();
            checkModf.Tapped += delegate {
                new Armazenamento().Finalizar(tarefa, i);
                carregarTarefas();
            };

            imageCheck.GestureRecognizers.Add(checkModf);


            StackLayout linha = new StackLayout() { Orientation = StackOrientation.Horizontal,Spacing = 15,Padding = 10 };


            linha.Children.Add(imageCheck);
            linha.Children.Add(StackCentral);
            linha.Children.Add(imagePrioridade);
            linha.Children.Add(imageDelete);

            SLTarefas.Children.Add(linha);

        }
    }
}