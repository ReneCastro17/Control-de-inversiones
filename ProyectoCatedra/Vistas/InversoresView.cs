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
    public partial class InversoresView : Form
    {
        //Estado de orden.
        bool OrdenAscendente = true;
        //Se declara la instancia de la lista que nos servirá para imprimir los datos.
        private List<Inversionista> ListaI;
        //Recibe la lista
        public InversoresView(List<Inversionista> ListaHeap)
        {
            //Reasigna esta lista a la lista local del form 2.
            InitializeComponent();
            this.ListaI = ListaHeap;
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            frmregistro open = new frmregistro();
            this.Hide();
            open.ShowDialog();
            this.Close();
        }
        private void InversoresView_Load(object sender, EventArgs e)
        {
            frmregistro open = new frmregistro();
            open.Close();
            //El datagrid recibe los valores en sus celdas de los elementos en la lista de inversores.
            dataGridViewF.DataSource = ListaI;
            //Ajustar el tamaño de cada columna en el grid.
            foreach (DataGridViewColumn col in dataGridViewF.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //Establecer las columnas y colocarles su nombre.
            dataGridViewF.Columns["IdInver"].HeaderText = "ID";
            dataGridViewF.Columns["IdInver"].DataPropertyName = "IdInver";
            dataGridViewF.Columns["FechaInversion"].HeaderText = "Fecha";
            dataGridViewF.Columns["FechaInversion"].DataPropertyName = "FechaInversion";
            dataGridViewF.Columns["Name"].HeaderText = "Nombre";
            dataGridViewF.Columns["Name"].DataPropertyName = "Name";
            dataGridViewF.Columns["Email"].HeaderText = "Correo eléctronico";
            dataGridViewF.Columns["Email"].DataPropertyName = "Email";
            dataGridViewF.Columns["Telefono"].HeaderText = "Teléfono";
            dataGridViewF.Columns["Telefono"].DataPropertyName = "Telefono";
            dataGridViewF.Columns["Monto"].HeaderText = "Monto";
            dataGridViewF.Columns["Monto"].DataPropertyName = "Monto";
            dataGridViewF.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListaI.Count <= 1)
            {
                MessageBox.Show("No se puede ordenar.");
            }
            else
            {
                //Se alterna el valor de orden.
                OrdenAscendente = !OrdenAscendente;
                //Se ordena según el orden seleccionado.
                if (OrdenAscendente)
                {
                    HeapLista.HeapSort(ListaI, ListSortDirection.Ascending);
                    lblStatus.Text = "Mostrando: orden descendente.";
                }
                else
                {
                    HeapLista.HeapSort(ListaI, ListSortDirection.Descending);
                    lblStatus.Text = "Mostrando: orden ascendente.";
                }
                dataGridViewF.Refresh();
            }
        }
    }
}
