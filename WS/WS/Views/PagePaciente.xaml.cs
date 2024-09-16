using SQLite;
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
    public partial class PagePaciente : ContentPage
    {
        public PagePaciente()
        {
            InitializeComponent();
            ServiceDbMedico dbMedico = new ServiceDbMedico(App.DbPath);
            foreach (var item in dbMedico.Listar())
            {
                pckMedico.Items.Add(item.NomeMedico);
            }
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomePaciente.Text) || string.IsNullOrEmpty(pckMedico.Items.ToString()))
                {
                    DisplayAlert("Campos Vazios!!!", "Preencha os Campos", "OK");
                }
                else
                {
                    
                    SQLiteConnection conn = new SQLiteConnection(App.DbPath);
                    string nomePaciente = txtNomePaciente.Text;
                    string nomeMedico = pckMedico.SelectedItem.ToString();
                    string dia = dtpDia.Date.ToString();
                    string horario = tmpHora.Time.ToString();
                    var result = conn.FindWithQuery<Paciente>("SELECT NomeMedico,Dia,Horario FROM Paciente WHERE NomeMedico='"+nomeMedico+"' AND Dia='"+dia+"' AND Horario='"+horario+"'");
                    
                    if (result != null)
                    {
                        DisplayAlert("Médico Já está agendado!", "Esse médico já possui um agendamento!", "OK");
                    }
                    else
                    {
                        Paciente paciente = new Paciente();
                        ServiceDbPaciente dbPaciente = new ServiceDbPaciente(App.DbPath);
                        paciente.NomePaciente = nomePaciente;
                        paciente.NomeMedico = nomeMedico;
                        paciente.Dia = dia;
                        paciente.Horario = horario;
                        dbPaciente.Inserir(paciente);
                        DisplayAlert("Agendamento Concluído!!!", "Agendamento para esse Paciente Realizado com Sucesso!", "OK");
                    }          
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