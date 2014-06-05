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
    public partial class frm_cliente : Form
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
        public frm_cliente()
        {
            X = Propp.X;
            Y = Propp.Y;
           
            InitializeComponent();
        }

        private void frm_cliente_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            actualizar();


            i3nRiqJson x = new i3nRiqJson();

            string query = "select idtbm_municipio, nombre  from tbm_municipio";


            cmb_departamento.DataSource = ((x.consulta_DataGridView(query)));
            cmb_departamento.ValueMember = "idtbm_municipio";
            cmb_departamento.DisplayMember = "nombre";


            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_descuento, descuento from tbm_descuento";


            cmb_moneda.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_moneda.ValueMember = "idtbm_descuento";
            cmb_moneda.DisplayMember = "descuento";




            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_cliente, nombre_cliente from tbm_cliente";


            cmb_eliminar.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_eliminar.ValueMember = "idtbm_cliente";
            cmb_eliminar.DisplayMember = "nombre_cliente";


        }

        public void actualizar()
        {

            i3nRiqJson x = new i3nRiqJson();

            string query = "SELECT tbm_cliente.nombre_cliente as Nombre,tbm_cliente.nit_cliente as Nit,tbm_cliente.direccion_cliente as Direccion,tbm_descuento.descuento as Descuento from tbm_cliente, tbm_descuento where tbm_cliente.tbm_descuento_idtbm_descuento = tbm_descuento.idtbm_descuento";
            // string query2 = "SELECT tbm_compra.fecha_compra as Fecha,tbm_compra.Cantidad_compra as Cantidad,tbm_empleado.nombre_empleado as Empleado,tbt_detalle_proveedor.producto_detalle_proveedorcol as Producto,tbt_detalle_proveedor.precio_compra as Precio, tbm_almacen.nombre_bodega as Almacen from tbm_compra,tbm_empleado,tbt_detalle_proveedor,tbm_almacen where tbm_empleado.idtbm_empleado = tbm_compra.tbm_empleado_idtbm_empleado and tbm_compra.tbm_almacen_idtbm_bodega=tbm_almacen.idtbm_bodega";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query)));

        }



          public void ingresocliente()
        {

           
            if ((txtcantidad.Text.Equals("")) || (txtventa.Text.Equals("")))
            {

                MessageBox.Show("Algun campo esta vacio");
            }
            else
            {

                string tabla = "tbm_cliente";
                Dictionary<string, string> dict = new Dictionary<string, string>();

              

          

             i3nRiqJson x = new i3nRiqJson();
            
                dict.Add("valor_compra_moneda", txtcantidad.Text);
                dict.Add("valor_venta_moneda", txtventa.Text);
                dict.Add("direccion_cliente", textBox3.Text);
               
              
               //DESCUENTO

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_descuento from tbm_descuento where descuento='" + cmb_moneda.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);



                foreach (Dictionary<string, string> dic in array)
                {
                    stef = (dic["idtbm_descuento"] + "\n");

                }
                dict.Add("tbm_descuento_idtbm_descuento", stef);

                //DEPARTAMENTO

                i3nRiqJson x2 = new i3nRiqJson();
                string query2 = "select idtbm_departamentos, nombre from  tbm_departamentos where nombre='" + cmb_departamento + "'";
                System.Collections.ArrayList array2 = x2.consultar(query2);
                foreach (Dictionary<string, string> dic in array2)
                {
                    stef2 = (dic["idtbm_departamento"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
                }


                textBox1.Text = stef2;


                i3nRiqJson x3 = new i3nRiqJson();

                string query3 = "select idtbm_municipio, nombre  from tbm_municipio where idtbm_departamentos ='" + stef2 + "' ";


                cmb_municipio.DataSource = ((x3.consulta_DataGridView(query3)));
                cmb_municipio.ValueMember = "idtbm_municipio";
                cmb_municipio.DisplayMember = "nombre ";
                dict.Add("idtbm_departamentos", stef2);





                x.insertar("1", tabla, dict);
              
            
               
                MessageBox.Show("Datos ingresados en cabio moneda " + i3nRiqJson.RespuestaConexion.ToString());
               
               

                actualizar();
            }

        }







        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtcantidad.ReadOnly = false;
            txtcantidad.Text = "";
            txtventa.ReadOnly = false;
            txtventa.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

           /* i3nRiqJson x3 = new i3nRiqJson();
            string query = "select idtbm_descuento from tbm_descuento where descuento='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic["idtbm_descuento"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;

            i3nRiqJson x4 = new i3nRiqJson();
            string query2 = "select idtbm_cliente from tbm_cliente where tbm_descuento_idtbm_descuento='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query2);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["idtbm_cliente"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }





            //   string busca = cmb_eliminar.SelectedValue.ToString();
            dataGridView1.DataSource = db.consulta_DataGridView("select *from tbm_cliente where idtbm_cliente =" + stef3 + ";");*/



            string busca = cmb_eliminar.SelectedValue.ToString();
          //  dataGridView1.DataSource = db.consulta_DataGridView("SELECT tbm_cliente.nombre_cliente as Nombre,tbm_cliente.nit_cliente as Nit,tbm_cliente.direccion_cliente as Direccion from tbm_cliente   where tbm_descuento_idtbm_descuento =" + busca + ";");
            dataGridView1.DataSource = db.consulta_DataGridView("SELECT tbm_cliente.nombre_cliente as Nombre,tbm_cliente.nit_cliente as Nit,tbm_cliente.direccion_cliente as Direccion, tbm_descuento.descuento as Descuento from tbm_cliente ,tbm_descuento   where  tbm_cliente.tbm_descuento_idtbm_descuento = tbm_descuento .idtbm_descuento=" + busca + ";   ");
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select idtbm_cliente, nombre_cliente from tbm_cliente where nombre_cliente='" + cmb_eliminar.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);
            foreach (Dictionary<string, string> dic in array)
            {
                stef = (dic["idtbm_cliente"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbm_cliente";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("nombre_cliente", txtcantidad.Text);
            dict.Add("nit_cliente", txtventa.Text);

            i3nRiqJson x3 = new i3nRiqJson();
            string query3 = "select idtbm_descuento from tbm_descuento where descuento='" + cmb_moneda.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query3);



            foreach (Dictionary<string, string> dic in array2)
            {
                stef = (dic["idtbm_descuento"] + "\n");

            }
            dict.Add("tbm_descuento_idtbm_descuento", stef);




            string condicion = "idtbm_cliente= " + stef;
            x.actualizar("3", tabla, dict, condicion);
            actualizar();

            MessageBox.Show("Datos Actualizados de histograma",
        "Editar Transaccion",
        MessageBoxButtons.OK);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
       




            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbm_cliente";
            string condicion = "idtbm_cliente=" + cmb_eliminar.SelectedValue;


            //string condicion = "idtbt_ingreso_vehiculo=" + id;
            x.eliminar("4", tabla, condicion);
            MessageBox.Show("Datos eliminados de vehiculo " + i3nRiqJson.RespuestaConexion.ToString());


            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_cliente, nombre_cliente from tbm_cliente";


            cmb_eliminar.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_eliminar.ValueMember = "idtbm_cliente";
            cmb_eliminar.DisplayMember = "nombre_cliente";

            actualizar();
       


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresocliente();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_departamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select idtbm_departamentos, nombre from  tbm_departamentos where nombre='" + cmb_departamento + "'";
            System.Collections.ArrayList array = x4.consultar(query4);
            foreach (Dictionary<string, string> dic in array)
            {
                stef = (dic["idtbm_departamento"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }


            textBox1.Text = stef;


            i3nRiqJson x3 = new i3nRiqJson();

            string query3 = "select idtbm_municipio, nombre  from tbm_municipio where idtbm_departamentos ='" + stef + "' ";


            cmb_municipio.DataSource = ((x3.consulta_DataGridView(query3)));
            cmb_municipio.ValueMember = "idtbm_municipio";
            cmb_municipio.DisplayMember = "nombre ";
           

        }











    }
}
