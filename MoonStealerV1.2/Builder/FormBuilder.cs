using AzuriteRAT.Helper;
using AzuriteRAT.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzuriteRAT
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        public static class ListviewDoubleBuffer
        {
            public static void Enable(ListView listView)
            {
                PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                property.SetValue(listView, true, null);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListviewDoubleBuffer.Enable(this.listView1);
            Style.Render(this);
            Style.ListViewStyle(listView1);
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Style.Draggable(this,e);
        }
    }
}
