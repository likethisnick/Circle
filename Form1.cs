// Creator:          Fedorovskiy Roman 
// Creation time:    14.06.2016 at 15:23

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YellowRoundForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Скрытие элементов при инициализации, отображаемых при переключении CheckBox1

            label1.Hide();
            strDiametr.Hide();
            label2.Hide();
            label3.Hide();
            panel1.Hide();
            button1.Hide();
            button3.Hide();
        }

        // Изменение рабочего поля при изменении размера окна программы

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            picture.Width = this.Width;
            picture.Height = this.Height;
        }

        // При нажатии кнопки button1 к событию "нажатие ЛКМ" подключается handler с
        // методом определения координат мыши относительно окна программы

        private void button1_Click(object sender, EventArgs e)
        {
            picture.Click += new System.EventHandler(picture_Click);
        }

        // Функция, определяющая координаты мыши при нажатии на pictureboxе с названием "picture"

        private void picture_Click(object sender, EventArgs e)
        {
            int captionHeight = SystemInformation.CaptionHeight;
            int StartX = MousePosition.X - this.Location.X;
            int StartY = MousePosition.Y - this.Location.Y - captionHeight;
            Draw(StartX, StartY);
            picture.Click -= new System.EventHandler(picture_Click); // отключаем от события "нажатие ЛКМ" определение координат мыши
        }

        // Функция, рисуящая круг

        private void Draw(int StartX, int StartY)
        {

            int Diametr = 500;          // дефолтный диаметр

            if (strDiametr.Text != "")
            {
                Int32.TryParse(strDiametr.Text, out Diametr); // преобразование введенного диаметра в инт
            }

            // создание битмапа для рисунка
            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics graph = Graphics.FromImage(bmp);

            // создание стандартной кисти для закраски круга
            SolidBrush myBrush = new SolidBrush(Color.Yellow);

            // при включенной галке checkboxa, цвет кисти определяется colordialogом
            if (checkBox1.Checked == true)
            {
               myBrush = new SolidBrush(colorDialog1.Color);
            }
            // Для дефолтного расположения круга (по центру окна)
            if (checkBox1.Checked == false)
            {
                StartX = this.Width / 2;
                StartY = this.Height / 2;
            }
            // Отображение круга посредством Элипса, ограниченного прямоугольником с равными сторонами (квадратом), 
            // с указанием левого верхнего угла квадрата
            graph.FillEllipse(myBrush, new Rectangle(StartX - Diametr/2, StartY - Diametr/2, Diametr, Diametr));
            picture.Image = bmp;
        }

       
        // Переключение между режимами постройки дефолтного круга и круга с дополнительными настройками

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label1.Show();
                strDiametr.Show();
                label2.Show();
                label3.Show();
                panel1.Show();
                button1.Show();
                button3.Show();
                button2.Hide();
            }
            if (checkBox1.Checked == false)
            {
                label1.Hide();
                strDiametr.Hide();
                label2.Hide();
                label3.Hide();
                panel1.Hide();
                button1.Hide();
                button3.Hide();
                button2.Show();
            }
            panel1.BackColor = colorDialog1.Color;
        }

        // Кнопка для постройки дефолтного круга

        private void button2_Click(object sender, EventArgs e)
        {
            int captionHeight = SystemInformation.CaptionHeight;
            Draw(0,0);
        }

        
        // Кнопка для выбора цвета круга
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ColorResult = colorDialog1.ShowDialog();
            panel1.BackColor = colorDialog1.Color; // Отображение выбраного цвета в colordialoge
        }

   


     
       
       

      
 
       
    }
}
