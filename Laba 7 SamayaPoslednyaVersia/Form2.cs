using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_7_SamayaPoslednyaVersia
{
    public partial class Form2 : Form
    {
        #region ФУНКЦИЯ №3 Создание одномерного массива с помощью датчика случайных чисел

        static public int[] Create_Random_One_Dem_Mas()/////////////Создание одномерного массива с помощью датчика случайных чисел [ДСЧ] (Create_Random_One_Dem_Mas)
        {


            Random n = new Random();
            int[] OneDemMas = new int[n.Next(3, 10)];
            for (int i = 0; i < OneDemMas.Length; i++)
            {
                OneDemMas[i] = n.Next(-100, 100);
            }

            return OneDemMas;
        }

        #endregion

        int[] mas = Create_Random_One_Dem_Mas();
        public Form2()
        {
            InitializeComponent();
        }
       
        //Подсказки
        private void Form2_Load(object sender, EventArgs e)
        {

            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(textBox1, "Ваш\nмассив");

            toolTip2.IsBalloon = true;
            toolTip2.SetToolTip(textBox3, "Введите\nчисло");

            toolTip3.IsBalloon = true;
            toolTip3.SetToolTip(textBox2, "Ваш изменённый\nмассив");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";

            string[] New_mas = new string[mas.Length];

            for (int i = 0; i < mas.Length; i++)
            {
                New_mas[i] = Convert.ToString(mas[i]);
            }
            textBox1.Text += "[";
            for (int i = 0; i < New_mas.Length; i++)
            {

                textBox1.Text += New_mas[i] + "  ";

            }
            textBox1.Text += "]";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int AddNumber;
            bool ok = int.TryParse(textBox3.Text, out AddNumber);
            if (ok)
            {
                int[] New_mas_int = new int[mas.Length + 1];
                string[] New_mas_string = new string[New_mas_int.Length];
                New_mas_int[0] = AddNumber;
                for (int i = 1; i < New_mas_int.Length; i++)
                {
                    New_mas_int[i] = mas[i - 1];

                }

                for (int i = 0; i < New_mas_string.Length; i++)
                {
                    New_mas_string[i] = Convert.ToString(New_mas_int[i]);
                }
                textBox2.Text += "[";
                for (int i = 0; i < New_mas_string.Length; i++)
                {

                    textBox2.Text += New_mas_string[i] + "  ";

                }
                textBox2.Text += "]";
            }
            else
                MessageBox.Show("Вы ввели \n недопустимое значение!", "Fatal ERROR!",
            MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }
    }
}
