using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_LayoutXL.Master {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage {
        public Menu() {
            InitializeComponent();
        }
        private void openSobreJoseph(object sender, EventArgs args) {
            string nome = "Joseph Hill";
            string idade = "N/A";
            string data = "N/A";
            string info = "O co-fundador da Xamarin, Joseph, participa ativamente da comunidade Mono desde 2003, e também contribuiu para várias aplicações de código aberto .NET. Como desenvolvedor profissional, trabalhou com várias empresas da Fortune 500 na concepção e implementação de aplicativos .NET. Em janeiro de 2008, Joseph juntou-se à Novell para servir como gerente de produto da Mono, impulsionando os esforços de desenvolvimento e marketing de produtos para lançar os produtos comerciais da Xamarin.";
            Detail = new NavigationPage(new Pages.Perfil(idade,data,info, nome));
            IsPresented = false;
        }
        private void openSobreNat(object sender,EventArgs args) {
            string nome = "Nat Friedman";
            string idade = "42";
            string data = "06/08/1977";
            string info = "Em 1996, quando era calouro no Massachusetts Institute of Technology, Friedman fez amizade com Miguel de Icaza no LinuxNet, a rede IRC que Friedman havia criado para discutir o Linux. Como estagiário na Microsoft Friedman trabalhou no servidor web IIS. No MIT estudou Ciência da Computação e Matemática e graduou-se com um Bacharelado em Ciências em 1999.";
            Detail = new NavigationPage(new Pages.Perfil(idade,data,info, nome));
            IsPresented = false;
        }
        private void openSobreMiguel(object sender, EventArgs args) {
            string nome = "Miguel de Icaza";
            string idade = "18";
            string data = "26/03/2002";
            string info = "Miguel de Icaza nasceu na Cidade do México e estudou na Universidade Nacional Autônoma do México UNAM. Ele começou a escrever software em 1992." + Environment.NewLine + "Icaza começou o projeto GNOME em Agosto de 1997.Ele e Federico Mena, criaram um completo sistema de desktop livre e um componente para sistemas GNU / Linux.Antes disso, Icaza já havia trabalhado em um gerente de arquivos, o Midnight Commander, assim como no núcleo Linux.";
            Detail = new NavigationPage(new Pages.Perfil(idade,data,info, nome));
            IsPresented = false;
        }
        private void openSobreXamarin(object sender,EventArgs args) {
            Detail = new NavigationPage(new Pages.PaginaXamarin());
            IsPresented = false;
        }
    }
}