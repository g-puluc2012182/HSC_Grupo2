﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
   public  class clsControlador
    {
        clsSentencias sn = new clsSentencias();
        public OdbcDataReader consultar(string tabla)
        {
            return sn.consulta(tabla);
        }

        public string[] items(string tabla, string campo1, string campo2)
        {
            string[] Items = sn.llenarCmb(tabla, campo1, campo2);
            return Items;
        }

        public DataTable enviar(string tabla, string campo1, string campo2)
        {
            var dt1 = sn.obtener(tabla, campo1, campo2);
            return dt1;
        }
    }
}
