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
    /*Roberto José Melgares Zelaya - MZ221682
        René Eduardo Hernández Castro - HC220857
        Oscar Edgardo Navarro Banderas - NB220557
    */
    //form principal
    public partial class frmregistro : Form
    {
        public frmregistro()
        {
            InitializeComponent();
        }
        //generar la vista
        private void btnback_Click(object sender, EventArgs e)
        {
            if (HeapLista.ListaHeap.Count == 0)
            {
                MessageBox.Show("No hay registros.", "ERROR");
            }
            else
            {
                //Se manda como parametro al segundo form a la lista estatica
                InversoresView open = new InversoresView(HeapLista.ListaHeap);
                this.Hide();
                open.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (txtNombre.Text == "" || txtMail.Text == "Ejemplo: inversion@tm.com" || txtTel.Text == "Ejemplo: 50312345678" || txtMont.Text == "")
            {
                MessageBox.Show("Complete los campos vacíos.");
                txtNombre.Focus();
            }
            else
            {
                if (!Regex.IsMatch(txtNombre.Text, @"^[A-Z][a-z]*( [A-Z][a-z]*)*$"))
                {
                    MessageBox.Show("Nombre no es válido.");
                    txtNombre.Focus();
                }
                else if (!Regex.IsMatch(txtMail.Text, @"^.*@.*\.com$"))
                {
                    MessageBox.Show("E-mail no es válido.");
                    txtMail.Focus();
                }
                else if (!Regex.IsMatch(txtTel.Text, @"^.{11,}$"))
                {
                    MessageBox.Show("El teléfono es incorrecto.", "ERROR");
                    txtTel.Focus();
                }
                else if (!Regex.IsMatch(txtMont.Text, @"^[1-9]\d*$"))
                {
                    MessageBox.Show("El monto no puede ser 0.", "ERROR");
                    txtMont.Focus();
                }
                else
                {
                    //Guardar datos
                    MessageBox.Show("Registro agregado correctamente");
                    Inversionista I = new Inversionista();
                    I.Name = txtNombre.Text;
                    I.Monto = int.Parse(txtMont.Text);
                    I.Telefono = txtTel.Text;
                    I.Email = txtMail.Text;
                    HeapLista.ListaHeap.Add(I);
                    txtNombre.Text = "";
                    txtMail.Text = "";
                    txtTel.Text = "";
                    txtMont.Text = "";
                }
            }
        }
        //Más validaciones
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Solo se aceptan letras y espacios.", "ERROR");
            }
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (txtTel.Text == "Ejemplo: 50312345678")
            {
                txtTel.Text = ""; 
                txtTel.ForeColor = SystemColors.WindowText; 
            }
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text == "")
            {
                txtTel.Text = "Ejemplo: 50312345678"; 
                txtTel.ForeColor = SystemColors.GrayText; 
            }
        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Ejemplo: inversion@tm.com")
            {
                txtMail.Text = "";
                txtMail.ForeColor = SystemColors.WindowText; 
            }
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "Ejemplo: inversion@tm.com";
                txtMail.ForeColor = SystemColors.GrayText; 
            }
        }
        private void txtMail_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;            }
        }

        private void txtTel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Solo se aceptan números");
                e.Handled = true;
            }
        }

        private void txtMont_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Solo se aceptan números enteros.");
                e.Handled = true;
            }
        }
        private void ResaltarBtn(System.Windows.Forms.Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Blue;
            button.FlatAppearance.BorderSize = 1;
        }
        private void frmregistro_Load(object sender, EventArgs e)
        {
            txtMail.ForeColor = SystemColors.GrayText;
            txtMail.Text = "Ejemplo: inversion@tm.com";
            txtTel.ForeColor = SystemColors.GrayText;
            txtTel.Text = "Ejemplo: 50312345678";
            ResaltarBtn(btnReg);
        }
    }
}
