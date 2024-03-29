﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace ProyectoSO
{
    public partial class Form1 : Form
    {
        Socket server;
        bool conn = false;
        public Form1()
        {
            InitializeComponent();
            groupBox3.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9075);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                conn = true;
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            groupBox3.Visible = true;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Edad.Checked)
            {
                string mensaje = "1/" + nombreConsulta.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("La edad de tu jugador es: " + mensaje);
            }
            else if (anoGanado.Checked)
            {
                string mensaje = "2/" + nombreConsulta.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                MessageBox.Show("Las fechas que ha ganado: "+ mensaje);

            }
            else
            {
                // Enviamos nombre 
                string mensaje = "3/" + nombreConsulta.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("La contraseña del jugador es: "+mensaje);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nombreRegister != null && edadRegister != null && contrasenaRegister != null)
            {
                string mensaje = "4/" + nombreRegister.Text + "/" + edadRegister.Text+ "/"+ contrasenaRegister.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "Si")
                    MessageBox.Show("Registrado con exito");
                else
                    MessageBox.Show("Error al registrarse");
            }
            else
                MessageBox.Show("Introduce todos los datos antes de enviar");



        }

        private void Butt_Login_Click(object sender, EventArgs e)
        {
            if(conn == true)
            {
                string mensaje = "5/" + NombreLogin.Text + "/" + ContrasenaLogin.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "Si es el usuario")
                    groupBox3.Visible = false;
                else
                    MessageBox.Show("Igual si pones bien la contraseña. ¿Has puesto las mayusculas bien?. Si no create otra cuenta crack.");

            }
            else
                MessageBox.Show("No ha sido posible la conexion entre usted (cliente) y nuestros servicios (Servidor) le pedimos disculpas de antemano por dicho suceso, disculpa las molestias y con Dios.","Sentimos las molestias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
