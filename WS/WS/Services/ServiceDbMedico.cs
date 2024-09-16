using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbMedico
    {
        SQLiteConnection conn;
        public ServiceDbMedico(string dbPath) 
        {
            if (dbPath == null)
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Medico>();
            
        }

        public List<Medico> Listar()
        {
            try
            {
                List<Medico> medicos = new List<Medico>();
                medicos = conn.Table<Medico>().ToList();
                return medicos;
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }


        public void Inserir(Medico medico)
        {
            try
            {
                conn.Insert(medico);
                //conn.Close();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
