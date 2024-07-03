using ProyectoCatedra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Text.RegularExpressions;

namespace ProyectoCatedra
{
    //Clase de nuestro inversionista con sus propiedades respectivas
    public class Inversionista
    {
        string name, email, telefono;
        int monto, idInver;
        static int cont;
        static DateTime fechaActual;
        DateTime fechaInversion;
        static Inversionista()
        {
            cont = 1;
            fechaActual = DateTime.Now;
        }
        public Inversionista()
        {
            idInver = cont++;
            fechaInversion = fechaActual;
        }
        public int IdInver
        {
            get { return idInver; }
        }
        public DateTime FechaInversion
        {
            get { return fechaInversion; }
        }
        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }
        public string Email 
        {
            get { return email; }
            set { email = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public int Monto 
        {
            get { return monto; }
            set { monto = value; }
        }
    }
}
