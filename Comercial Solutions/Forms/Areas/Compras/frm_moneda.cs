/***************************************************************
NOMBRE: Formulario de moneda
FECHA:  25/05/2014
CREADOR: Steffany Analy Torres Rivas
DESCRIPCIÓN  Area de compras
DETALLE: formulario multimonedas de compras
MODIFICACIÓN:
***************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comercial_Solutions.Clases;
using i3nRiqJSON;
using System.Net;
using System.IO;

using System.Collections;
           

namespace Comercial_Solutions.Forms.Areas.Compras
{
    public partial class frm_moneda : Form
    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        string EditCod = "";
        bool editar = false;
        string d;
        string stef;
        public frm_moneda()
        {
            X = Propp.X;
            Y = Propp.Y;
            
            InitializeComponent();
        }

        private void frm_moneda_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";
          /*  i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
           cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";*/

            //actualizar();
        }

        /***************************************************************
DESCRIPCION:  Procedimiento de actualizacion del dataGridView1
         	
 ***************************************************************/


        public void actualizar()
        {
            i3nRiqJson x = new i3nRiqJson();
            string query = "select tipo_moneda, simbolo_moneda, valor_moneda_nacional   from tbm_moneda";


             dataGridView1.DataSource = ((x.consulta_DataGridView(query)));


           /* dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbm_moneda");
            dataGridView1.Columns[1].HeaderText = "Tipo moneda";
            dataGridView1.Columns[2].HeaderText = "Simbolo moneda";
            dataGridView1.Columns[3].HeaderText = "Valor moneda nacional";
           
            this.dataGridView1.Columns[0].Visible = false;*/

        }

   /***************************************************************
   DESCRIPCION:   Procedimiento para guardar datos de moneda
       	
  ***************************************************************/

        public void guardarmoneda()
        {

            if ((txtmoneda.Text.Equals("")) || (txtsimbolo.Text.Equals("")) || (txtnacional.Text.Equals("")))
            {

                MessageBox.Show("Ingrese todos los datos requeridos");

            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Desea realizar el registro", "Registro de vehiculos", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string tabla = "tbm_moneda";
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("tipo_moneda", txtmoneda.Text);
                    dict.Add("simbolo_moneda", txtsimbolo.Text);
                    dict.Add("valor_moneda_nacional", txtnacional.Text);
                   

                    db.insertar("1", tabla, dict);
                    if (i3nRiqJson.RespuestaConexion.ToString().Equals("0"))
                    {
                        MessageBox.Show("Registro Realizado exitosamente");
                        //  Resetear();
                    }
                    else
                    {

                        MessageBox.Show("Registro no se ah realizado consulte con su administrador");

                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";

            actualizar();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtmoneda.ReadOnly = false;
            txtmoneda.Text = "";
            txtsimbolo.ReadOnly = false;
            txtsimbolo.Text = "";

            txtnacional.ReadOnly = false;
            txtnacional.Text = "";

          
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            guardarmoneda();
            txtmoneda.Text = "";
            txtsimbolo.Text = "";
            txtnacional.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbm_moneda";
            string condicion = "idtbm_moneda=" + cmb_eliminar.SelectedValue;


            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Datos eliminados de moneda " + i3nRiqJson.RespuestaConexion.ToString());


            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";


            actualizar();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbm_moneda where idtbm_moneda =" + busca + ";");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select idtbm_moneda, tipo_moneda from tbm_moneda where tipo_moneda='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);
            foreach (Dictionary<string, string> dic in array)
            {
                stef = (dic["idtbm_moneda"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbm_moneda";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("tipo_moneda", txtmoneda.Text);
            dict.Add("simbolo_moneda", txtsimbolo.Text);

            dict.Add("valor_moneda_nacional", txtnacional.Text);

            string condicion = "idtbm_moneda= " + stef;
            x.actualizar("3", tabla, dict, condicion);
            actualizar();

            MessageBox.Show("Datos Actualizados moneda",
        "Editar Moneda",
        MessageBoxButtons.OK);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            editar = true;
            txtmoneda.ReadOnly = false;
            txtsimbolo.ReadOnly = false;
            txtnacional.ReadOnly = false;
           
           
            actualizar();

            //dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_ingreso_vehiculo ;");

            // this.dataGridView1.Columns[0].Visible = false;
        }


        






    }
}
