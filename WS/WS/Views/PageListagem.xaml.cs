using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListagem : ContentPage
    {
        public PageListagem()
        {
            InitializeComponent();
            ServiceDbPaciente dbPaciente = new ServiceDbPaciente(App.DbPath);
            lstAgendamento.ItemsSource = dbPaciente.Listar();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception er)
            {
                DisplayAlert("Erro!!!", er.Message, "OK");
            }
        }
    }
}