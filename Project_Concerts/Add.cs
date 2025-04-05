using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Concerts
{
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddParticipant_Click(object sender, EventArgs e)
        {
            string inputText = textBoxParticipants.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                checkedListBoxParticipants.Items.Add(inputText);
                textBoxParticipants.Clear();
            }
            else
            {
                MessageBox.Show("Введите текст перед добавлением!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteParticipant_Click(object sender, EventArgs e)
        {
            if (checkedListBoxParticipants.SelectedIndex != -1)
            {
                checkedListBoxParticipants.Items.RemoveAt(checkedListBoxParticipants.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 

        }
    }
}
