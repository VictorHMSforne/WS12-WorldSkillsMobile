using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Models;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMedico : ContentPage
    {
        public PageMedico()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomeMedico.Text) || string.IsNullOrEmpty(txtEspecialidadeMedico.Text))
                {
                    DisplayAlert("Campos Vazios!!!", "Preencha os Campos", "OK");
                }
                else
                {
                    Medico medico = new Medico();
                    ServiceDbMedico dbMedico = new ServiceDbMedico(App.DbPath);
                    medico.NomeMedico = txtNomeMedico.Text;
                    medico.Especialidade = txtEspecialidadeMedico.Text;

                    dbMedico.Inserir(medico);
                    txtNomeMedico.Text = "";
                    txtEspecialidadeMedico.Text = "";
                    DisplayAlert("Sucesso!!!", "Médico Inserido!", "OK");
                }
            }
            catch (Exception er)
            {
                DisplayAlert("Erro!!!", er.Message, "OK");
            }
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