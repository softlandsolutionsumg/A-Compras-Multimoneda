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


            cmb_moneda.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_moneda.ValueMember = "idtbm_moneda";
            cmb_moneda.DisplayMember = "tipo_moneda";


            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_eliminar.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_eliminar.ValueMember = "idtbm_moneda";
            cmb_eliminar.DisplayMember = "tipo_moneda";




        }


        public void actualizar()
        {


       /*    i3nRiqJson x = new i3nRiqJson();
            dataGridView1.DataSource = db.consulta_DataGridView("SELECT * FROM tbt_cambio_moneda");
            dataGridView1.Columns[1].HeaderText = "Fecha";
            dataGridView1.Columns[2].HeaderText = "Compra";
            dataGridView1.Columns[3].HeaderText = "Venta";
         //   dataGridView1.Columns[4].HeaderText = "Codigo";
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;*/

            
         

            i3nRiqJson x = new i3nRiqJson();

            string query = "SELECT tbt_cambio_moneda.fecha_cambio as Fecha,tbt_cambio_moneda.valor_compra_moneda as CompraMoneda,tbt_cambio_moneda.valor_venta_moneda as VentaMoneda,tbm_moneda.tipo_moneda as Moneda from tbt_cambio_moneda,tbm_moneda where tbt_cambio_moneda.tbm_moneda_idtbm_moneda = tbm_moneda.idtbm_moneda";
           // string query2 = "SELECT tbm_compra.fecha_compra as Fecha,tbm_compra.Cantidad_compra as Cantidad,tbm_empleado.nombre_empleado as Empleado,tbt_detalle_proveedor.producto_detalle_proveedorcol as Producto,tbt_detalle_proveedor.precio_compra as Precio, tbm_almacen.nombre_bodega as Almacen from tbm_compra,tbm_empleado,tbt_detalle_proveedor,tbm_almacen where tbm_empleado.idtbm_empleado = tbm_compra.tbm_empleado_idtbm_empleado and tbm_compra.tbm_almacen_idtbm_bodega=tbm_almacen.idtbm_bodega";
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

           
            if ((txtcantidad.Text.Equals("")) || (txtventa.Text.Equals("")))
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbt_cambio_moneda";
                Dictionary<string, string> dict = new Dictionary<string, string>();
              
              string fecha_actual = DateTime.Now.ToString("yyyy-MM-dd");

             dict.Add("fecha_cambio", fecha_actual);

             i3nRiqJson x = new i3nRiqJson();
            
                dict.Add("valor_compra_moneda", txtcantidad.Text);
                dict.Add("valor_venta_moneda", txtventa.Text);
                
               
              
               

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_moneda from tbm_moneda where tipo_moneda='" + cmb_moneda.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["idtbm_moneda"] + "\n");

                }
                dict.Add("tbm_moneda_idtbm_moneda", stef);

                x.insertar("1", tabla, dict);
              
            
               
                MessageBox.Show("Datos ingresados en cabio moneda " + i3nRiqJson.RespuestaConexion.ToString());


                /*i3nRiqJson x2 = new i3nRiqJson();

                string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


                cmb_moneda.DataSource = ((x2.consulta_DataGridView(query2)));
              
                cmb_moneda.DisplayMember = "tipo_moneda";
                cmb_moneda.ValueMember = " idtbm_moneda";


               i3nRiqJson x3 = new i3nRiqJson();

                string query3 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


                cmb_eliminar.DataSource = ((x3.consulta_DataGridView(query3)));
                cmb_eliminar.ValueMember = "idtbm_moneda";
                cmb_eliminar.DisplayMember = "tipo_moneda";*/
                actualizar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresohistograma();
            txtcantidad.Text = "";
            txtventa.Text = "";

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtcantidad.ReadOnly = false;
            txtcantidad.Text = "";
            txtventa.ReadOnly = false;
            txtventa.Text = "";
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
            string query2 = "select id_histograma_monedacol from tbt_cambio_moneda where tbm_moneda_idtbm_moneda='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["id_histograma_monedacol"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_cambio_moneda";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("valor_compra_moneda", txtcantidad.Text);
            dict.Add("valor_venta_moneda", txtventa.Text);








            i3nRiqJson x5 = new i3nRiqJson();
            string query5 = "select idtbm_moneda from tbm_moneda where tipo_moneda='" + cmb_moneda.Text + "'";
            System.Collections.ArrayList array5 = x5.consultar(query5);



            foreach (Dictionary<string, string> dic in array5)
            {
                stef = (dic["idtbm_moneda"] + "\n");

            }
            dict.Add("tbm_moneda_idtbm_moneda", stef);





            string condicion = "id_histograma_monedacol=" + stef3;
            x.actualizar("3", tabla, dict, condicion);
            txtcantidad.Text = "";
            txtventa.Text = "";
            actualizar();

            MessageBox.Show("Datos editados en cambio de moneda",
        "Editar vehiculos",
        MessageBoxButtons.OK);

            actualizar();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
            string query2 = "select id_histograma_monedacol from tbt_cambio_moneda where tbm_moneda_idtbm_moneda='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["id_histograma_monedacol"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

            
            
            
            
         //   string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbt_cambio_moneda where id_histograma_monedacol =" + stef3 + ";");
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
            string query2 = "select id_histograma_monedacol from tbt_cambio_moneda where tbm_moneda_idtbm_moneda='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["id_histograma_monedacol"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;



            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_cambio_moneda";
            string condicion = "id_histograma_monedacol=" + stef3;

            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Dato eliminado en cambio moneda " + i3nRiqJson.RespuestaConexion.ToString());

            //ºº  x.eliminar("4", "tbt_bancos", condicion);


            actualizar();

            
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            editar = true;
            txtcantidad.ReadOnly = false;
            txtventa.ReadOnly = false;
        


            actualizar();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frm_cambio_activo frm = new frm_cambio_activo();
            frm.Show();
        }

 




    }
}
