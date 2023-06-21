using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//CURSO – LEGAJO – APELLIDO – NOMBRE

namespace ABMMascotas
{
    public partial class frmMascota : Form
    {
       
        DBConnection DBconn = new DBConnection();


        public frmMascota()
        {
            InitializeComponent();
        }

        private void frmMascota_Load(object sender, EventArgs e)
        {
            CargaCombo(cboEspecie, "Especies");
            habilitar(false);
            cargaLista(lstMascotas, "Mascotas");
        }

        private void CargaCombo(System.Windows.Forms.ComboBox combo, string nombreTabla) // le paso el nombre de la tabla de la cualq uiero traer los datos y el combo donde cargarlo
        {
            string query = "SELECT * FROM " + nombreTabla;

            DataTable table = DBconn.ConsultarBD(query);

            combo.DataSource = table;
            combo.ValueMember = table.Columns[0].ColumnName;
            combo.DisplayMember = table.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cargaLista(ListBox listBox, string nombreTabla)
        {
            listBox.Items.Clear();

            string query = "SELECT * FROM " + nombreTabla;

            DataTable table = DBconn.ConsultarBD(query);

            foreach (DataRow row in table.Rows)
            {
                Mascota mascota = new Mascota();
                mascota.Codigo = Convert.ToInt32(row[0]);
                mascota.Nombre = row[1].ToString();
                mascota.Especie = Convert.ToInt32(row[2]);
                mascota.Sexo = Convert.ToInt32(row[3]);
                mascota.FechaNacimiento = (DateTime)(row[4]);

                listBox.Items.Add(mascota);

            }

        }

        private void habilitar(bool x)
        {

            txtCodigo.Enabled = x;
            txtNombre.Enabled = x;
            cboEspecie.Enabled = x;
            rbtMacho.Enabled = x;
            rbtHembra.Enabled = x;
            dtpFechaNacimiento.Enabled = x;

            btnGrabar.Enabled = x;

            btnNuevo.Enabled = !x;
            lstMascotas.Enabled = !x;
            

        }

        private void cargaForm()
        {
            if(lstMascotas.SelectedItems.Count > 0) 
            {
                Mascota mascota = (Mascota)lstMascotas.SelectedItem;

                txtCodigo.Text = mascota.Codigo.ToString();
                txtNombre.Text = mascota.Nombre.ToString();
                cboEspecie.SelectedValue = mascota.Especie;
                if(mascota.Sexo == 1)
                {
                    rbtMacho.Checked = true;
                    rbtHembra.Checked= false;
                }
                else{
                    rbtMacho.Checked = false;
                    rbtHembra.Checked = true;
                }
                dtpFechaNacimiento.Value = mascota.FechaNacimiento;
            }
        }

        private void limpiarForm()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboEspecie.SelectedIndex = -1;
            rbtMacho.Checked = false;
            rbtHembra.Checked = false;
            dtpFechaNacimiento.Value = DateTime.Now;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir del programa?", "Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                this.Close();
            }
            
            
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            limpiarForm();
            lstMascotas.ClearSelected();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool valido = true;

            //valida datos basico
            if (txtNombre.Text.Length < 1 || String.IsNullOrEmpty(txtNombre.Text) ||
                !rbtHembra.Checked || !rbtMacho.Checked)
            {
                valido = false;
            }
            

            if (valido)
            {
                    //crear objeto
                Mascota mascota = new Mascota();
                mascota.Nombre = txtNombre.Text;
                mascota.Especie = Convert.ToInt32(cboEspecie.SelectedValue);
                if (rbtMacho.Checked)
                {
                    mascota.Sexo = 1;
                } else if (rbtHembra.Checked)
                {
                    mascota.Sexo = 2;
                }
                mascota.FechaNacimiento = dtpFechaNacimiento.Value;

                //insert usando los parametros dentro del query
                string insertQuery = $"INSERT INTO Mascotas(nombre, especie, sexo, fechaNacimiento) " +
                    $"VALUES('{mascota.Nombre}', '{mascota.Especie}', '{mascota.Sexo}', '{mascota.FechaNacimiento.ToString("yyyy/MM/dd")}')";

                DBconn.IUD(insertQuery);
            
                MessageBox.Show("Se cargo correctamente la mascota!", "Cargado!", MessageBoxButtons.OK);
                // vuelvo a cargar la lista de items lstMascotas
                cargaLista(lstMascotas, "Mascotas");
                limpiarForm(); // para dejar nuevamente el form vacio


                // vuelvo a inhabilitar los campos
                habilitar(false);
            } else {
                MessageBox.Show("Debes completar todos los campos correctamente", "Error de validacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //SqlCommand = new SqlCommand(insertQuery, connection);


        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaForm();
        }

    }
}
