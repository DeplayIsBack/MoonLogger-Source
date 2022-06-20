using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AzuriteRAT.Helper
{
    internal class Style
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public static void ListViewStyle(ListView ListStyle)
        {
            ListStyle.View = View.Details;
            ListStyle.HideSelection = false;
            ListStyle.OwnerDraw = true;
            ListStyle.BackColor = Color.FromArgb(24, 24, 24);
            ListStyle.DrawColumnHeader += delegate (object sender1, DrawListViewColumnHeaderEventArgs args)
            {
                Brush brush = new SolidBrush(Color.FromArgb(159, 113, 208));
                args.Graphics.FillRectangle(brush, args.Bounds);
                TextRenderer.DrawText(args.Graphics, args.Header.Text, args.Font, args.Bounds, Color.WhiteSmoke);
            };
            ListStyle.DrawItem += delegate (object sender1, DrawListViewItemEventArgs args)
            {
                args.DrawDefault = true;
            };
            ListStyle.DrawSubItem += delegate (object sender1, DrawListViewSubItemEventArgs args)
            {
                args.DrawDefault = true;
            };
        }

        public static void Render(Form form)
        {
            new Guna.UI2.WinForms.Guna2ShadowForm(form)
            {
                ShadowColor = Color.FromArgb(159, 113, 208)
        };
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, 7, 7));
        }



        public static void Draggable(Form form,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                form.Opacity = 0.8;
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                form.Opacity = 1;
            }
        }

    }
}
