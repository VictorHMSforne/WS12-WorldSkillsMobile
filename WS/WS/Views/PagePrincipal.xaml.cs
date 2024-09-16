using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarMedico_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageMedico());
        }

        private void btnCadastrarPaciente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagePaciente());
        }

        private void btnListagemDados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageListagem());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}