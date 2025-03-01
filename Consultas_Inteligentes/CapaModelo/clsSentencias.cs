﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsSentencias
    {
        clsConexion cn = new clsConexion(); //crear objeto
        OdbcCommand com; //variable para querys

        public OdbcDataReader consulta(string tabla)
        {
            try
            {
                cn.conexion();
                string consulta = "SELECT * FROM " + tabla + ";";
                com = new OdbcCommand(consulta, cn.conexion());
                OdbcDataReader respuesta = com.ExecuteReader();
                return respuesta;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }


        public string[] llenarCmb(string tabla, string campo1, string campo2)
        {

            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string sql = "SELECT " + campo1 + "," + campo2 + " FROM " + tabla + " where estado = 1 ;";
            try
            {
                OdbcCommand command = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString();
                    i++;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + tabla + "\n -" + campo1); }
            return Campos;
        }

        public DataTable obtener(string tabla, string campo1, string campo2)
        {
            string sql = "SELECT " + campo1 + "," + campo2 + " FROM " + tabla + " where estado = 1  ;";
            OdbcCommand command = new OdbcCommand(sql, cn.conexion());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }
    }
}
