using Newtonsoft.Json;
using System;
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
    public partial class FormLogin : Form
    {
        /*este String (path) debe cambiarse por cualquier otra direccion en su 
        computador personal para que funcione Correctamente*/
        string _pathLogin = @"C:\Users\Fran\Documents\VISUAL STUDIO\COMUNNITY\ExamenDockUp\Users.json";
        int _posicionUser = -1;
        Usuario Admin = new Usuario("Admin", "Admin", true);
        List<Usuario> Usuarios = new List<Usuario>();
        public FormLogin()
        {
            InitializeComponent();
            Usuarios.Add(Admin);
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<Usuarios.Count; i++)
            {
                if (Usuarios[i].Nombre == txtUsuario.Text && Usuarios[i].Clave == txtClave.Text)
                {
                    this.DialogResult = DialogResult.OK;
                    _posicionUser = i;
                    this.Close();
                }
                else MessageBox.Show("Usuario y/o Clave Incorrectas");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try { Usuarios = JsonConvert.DeserializeObject<List<Usuario>>(File.ReadAllText(_pathLogin)); }
            catch 
            {
                MessageBox.Show("Es primera vez que se inicia el Programa.\nLos Datos para Ingresar como Administrador son:\n\nUsuario: Admin\nClave: Admin");
                /*MessageBox.Show("A Continuacion escoja una ubicacion para Guardar Datos de usuario:");
                if (BusquedaCarpeta.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(BusquedaCarpeta.SelectedPath + "/Direccion.txt",BusquedaCarpeta.SelectedPath);
                    _pathLogin = BusquedaCarpeta.SelectedPath + "/Users.json";
                }
                else Application.Exit();*/
            }
        }
        public string Path { set { _pathLogin = value; } get { return _pathLogin; } }
        public int Posicion { set { _posicionUser = value; } get { return _posicionUser; } }
        public List<Usuario> ListaUsuarios { set { Usuarios = value; } get { return Usuarios; } }
    }
    public class Usuario
    {
        private string _nombre;
        private string _clave;
        private string _cargo;
        public Usuario() 
        {
            _nombre = "";
            _clave = "";
            _cargo = "";
        }
        public Usuario(string Nombre, string Clave, bool Admin)
        {
            _nombre = Nombre;
            _clave = Clave;
            if (Admin)
            {
                _cargo = "Administrador";
            }
            else
            {
                _cargo = "Empleado";
            }
        }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Clave { get { return _clave;} set { _clave = value; } }
        public string Cargo { get { return _cargo;} set { _cargo = value; } }
    }
}
