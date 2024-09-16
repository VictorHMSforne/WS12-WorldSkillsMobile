using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbPaciente
    {
        SQLiteConnection conn;
        public ServiceDbPaciente(string dbPath)
        {
            if (dbPath == null)
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Paciente>();
        }
        public List<Paciente> Listar()
        {
            try
            {
                List<Paciente> pacientes = new List<Paciente>();
                pacientes = conn.Table<Paciente>().ToList();
                return pacientes;
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }


        public void Inserir(Paciente paciente)
        {
            try
            {
                conn.Insert(paciente);
                //conn.Close();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
