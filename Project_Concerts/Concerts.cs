using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Concerts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }



        private void buttonAdd_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 30; // Радиус закругления
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                // Создаем закругленный прямоугольник
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                // Применяем закругленную форму к кнопке
                button.Region = new Region(path);
            }
        }




        private void buttonEdit_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 30; // Радиус закругления
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                // Создаем закругленный прямоугольник
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                // Применяем закругленную форму к кнопке
                button.Region = new Region(path);
            }
        }

        private void buttonWatch_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 30; // Радиус закругления
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                // Создаем закругленный прямоугольник
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                // Применяем закругленную форму к кнопке
                button.Region = new Region(path);
            }
        }

        private void buttonDelete_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int cornerRadius = 30; // Радиус закругления
                GraphicsPath path = new GraphicsPath();
                int width = button.Width;
                int height = button.Height;

                // Создаем закругленный прямоугольник
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(width - cornerRadius * 2, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                // Применяем закругленную форму к кнопке
                button.Region = new Region(path);
            }
        }



        private void buttonWatch_Click(object sender, EventArgs e)
        {
            Watch watch = new Watch();
            watch.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ChooseEvent chooseevent = new ChooseEvent();
            chooseevent.Show();
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            delete.Show();
        }
    }
}

