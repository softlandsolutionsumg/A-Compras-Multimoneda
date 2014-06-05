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
    public partial class frm_cambio_activo : Form
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
        public frm_cambio_activo()
        {
            X = Propp.X;
            Y = Propp.Y;
           
            InitializeComponent();
        }

        private void frm_cambio_activo_Load(object sender, EventArgs e)
        {
            
            
            this.Location = new Point(250, 56);
            actualizar();

            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select idtbm_moneda, tipo_moneda from tbm_moneda";


            cmb_moneda.DataSource = ((x2.consulta_DataGridView(query2)));
            cmb_moneda.ValueMember = "idtbm_moneda";
            cmb_moneda.DisplayMember = "tipo_moneda";






            



        }


        public void actualizar()
        {

            i3nRiqJson x = new i3nRiqJson();

          //  string query = " SELECT tbm_moneda.tipo_moneda as Moneda from tbm_moneda";
            // string query2 = "SELECT tbm_compra.fecha_compra as Fecha,tbm_compra.Cantidad_compra as Cantidad,tbm_empleado.nombre_empleado as Empleado,tbt_detalle_proveedor.producto_detalle_proveedorcol as Producto,tbt_detalle_proveedor.precio_compra as Precio, tbm_almacen.nombre_bodega as Almacen from tbm_compra,tbm_empleado,tbt_detalle_proveedor,tbm_almacen where tbm_empleado.idtbm_empleado = tbm_compra.tbm_empleado_idtbm_empleado and tbm_compra.tbm_almacen_idtbm_bodega=tbm_almacen.idtbm_bodega";
          //  dataGridView1.DataSource = ((x.consulta_DataGridView(query)));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



            i3nRiqJson x2 = new i3nRiqJson();

            string query2 = "select * from tbt_cambio_moneda where id_histograma_monedacol=(select MAX(id_histograma_monedacol)as ID from tbt_cambio_moneda where tbt_cambio_moneda.tbm_moneda_idtbm_moneda='" + cmb_moneda.Text + "')";
            dataGridView1.DataSource = ((x2.consulta_DataGridView(query2)));


         /*   i3nRiqJson x3 = new i3nRiqJson();
            string query = "select * from tbt_cambio_moneda where id_histograma_monedacol=(select MAX(id_histograma_monedacol)as ID from tbt_cambio_moneda where tbt_cambio_moneda.tbm_moneda_idtbm_moneda='" + cmb_moneda.Text + "')";
            System.Collections.ArrayList array = x3.consultar(query);

            foreach (Dictionary<string, string> dic in array)
            {
                stef2 = (dic[" tbm_moneda_idtbm_moneda"] + "\n");
                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }



            textBox1.Text = stef2;*/

           /* i3nRiqJson x4 = new i3nRiqJson();
            string query3 = "select id_histograma_monedacol from tbt_cambio_moneda where tbm_moneda_idtbm_moneda='" + textBox1.Text + "'";
            System.Collections.ArrayList array2 = x4.consultar(query3);

            foreach (Dictionary<string, string> dic in array2)
            {
                stef3 = (dic["id_histograma_monedacol"] + "\n");

                // txtR.AppendText(dic["employee_name"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }


            textBox2.Text = stef3;*/
            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbt_cambio_moneda";
            string condicion = "id_histograma_monedacol=" + stef3;

            //string condicion = "idtbt_ingreso_vehiculo=" + id;
      
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            i3nRiqJson x2 = new i3nRiqJson();

           // string query2 = "select * from tbt_cambio_moneda where id_histograma_monedacol=(select MAX(id_histograma_monedacol)as ID from tbt_cambio_moneda where tbt_cambio_moneda.tbm_moneda_idtbm_moneda='" + cmb_moneda.Text + "')";
            string query2 = " SELECT tbt_cambio_moneda.fecha_cambio as Fecha,tbt_cambio_moneda.valor_compra_moneda as CompraMoneda,tbt_cambio_moneda.valor_venta_moneda as VentaMoneda from tbt_cambio_moneda where id_histograma_monedacol=(select MAX(id_histograma_monedacol)as ID from tbt_cambio_moneda where tbt_cambio_moneda.tbm_moneda_idtbm_moneda='" + cmb_moneda.Text + "')";
            dataGridView1.DataSource = ((x2.consulta_DataGridView(query2)));

        }
    }
}
