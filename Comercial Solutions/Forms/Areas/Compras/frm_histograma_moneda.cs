/***************************************************************
NOMBRE: Formulario Histograma de monedas
FECHA:   25/05/2014
CREADOR:  Steffany Analy Torres Rivas
DESCRIPCIÓN   Area de compras
DETALLE:  formulario multimonedas de compras
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
    public partial class frm_histograma_moneda : Form
    {
        int inteditmode = 0;
        i3nRiqJson db = new i3nRiqJson();
        int X = 0;
        int Y = 0;
        string EditCod = "";
        bool editar = false;
        string d;


        string stef;
        

        string stef2;
        string stef3;
        public frm_histograma_moneda()
        {

            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }

        private void frm_histograma_moneda_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_vehiculo.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_vehiculo.ValueMember = "idtbm_moneda";
            cmb_vehiculo.DisplayMember = "tipo_moneda";


            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";




        }


        public void actualizar()
        {



            i3nRiqJson x = new i3nRiqJson();
            string query = "select cantidad_moneda, fecha_valor from tbt_histograma_moneda";
           dataGridView1.DataSource = ((x.consulta_DataGridView(query)));



           
        

          /*  dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_histograma_moneda");
            dataGridView1.Columns[1].HeaderText = "Cantidad";
            dataGridView1.Columns[2].HeaderText = "Fecha";
            dataGridView1.Columns[3].HeaderText = "Tipo moneda";
            this.dataGridView1.Columns[0].Visible = false;
            //this.dataGridView1.Columns[4].Visible = false;*/


        }




        public void ingresohistograma()
        {

            if ((txttotal.Text.Equals("")))
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbt_histograma_moneda";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("cantidad_moneda", txttotal.Text);
                dict.Add("fecha_valor", dtpfecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));
               

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_moneda, tipo_moneda  from tbm_moneda where tipo_moneda='" + cmb_vehiculo.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["idtbm_moneda"] + "\n");

                }
                dict.Add("tbm_moneda_idtbm_moneda", stef);


                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos ingresados en histograma moneda " + i3nRiqJson.RespuestaConexion.ToString());


             /*   i3nRiqJson x2 = new i3nRiqJson();

                string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


                cmb_vehiculo.DataSource = ((x2.consulta_DataGridView(query2)));
              
                cmb_vehiculo.DisplayMember = "tipo_moneda";
                cmb_vehiculo.ValueMember = " idtbm_moneda";*/

                actualizar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresohistograma();
            txttotal.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txttotal.ReadOnly = false;
            txttotal.Text = "";
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select id_histograma_monedacol, cantidad_moneda from tbt_histograma_moneda where cantidad_moneda='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);
            foreach (Dictionary<string, string> dic in array)
            {
                stef = (dic["id_histograma_monedacol"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbtbt_histograma_moneda";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("cantidad_moneda", txttotal.Text);




            string condicion = "iid_histograma_monedaco= " + stef;
            x.actualizar("3", tabla, dict, condicion);
            actualizar();

            MessageBox.Show("Datos Actualizados de histograma",
        "Editar Transaccion",
        MessageBoxButtons.OK);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_histograma_moneda where id_histograma_monedacol =" + busca + ";");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x3 = new i3nRiqJson();
            string query = "select idtbm_moneda from tbm_moneda where tipo_moneda='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic["idtbm_moneda"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;

            i3nRiqJson x4 = new i3nRiqJson();
            string query2 = "select id_histograma_monedacol from tbt_histograma_moneda where tbm_moneda_idtbm_moneda='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["id_histograma_monedacol"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_histograma_moneda";
            string condicion = "id_histograma_monedacol=" + stef3;

            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Dato eliminado en histograma moneda " + i3nRiqJson.RespuestaConexion.ToString());

            //ºº  x.eliminar("4", "tbt_bancos", condicion);


            actualizar();

            
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            editar = true;
            txttotal.ReadOnly = false;
        


            actualizar();
        }

 




    }
}
