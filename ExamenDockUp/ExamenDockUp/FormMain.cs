using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenDockUp
{
    public partial class FormMain : Form
    {
        FormLogin Login = new FormLogin();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(Login.ShowDialog()!=DialogResult.OK){
                Application.Exit();
            }
            else
            {
                lblNombre.Text = Login.ListaUsuarios[Login.Posicion].Nombre;
                lblCargo.Text = Login.ListaUsuarios[Login.Posicion].Cargo;
                string Json = JsonConvert.SerializeObject(Login.ListaUsuarios.ToArray(), Formatting.Indented);
                File.WriteAllText(Login.Path, Json);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
