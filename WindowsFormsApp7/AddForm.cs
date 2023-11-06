using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class AddForm : Form
    {
        private bool guest;

        public AddForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Получаем данные о смене из элементов управления
            string employeeName = textBox1.Text;
            DateTime startTime = dateTimePicker1.Value;
            DateTime endTime = dateTimePicker2.Value;

            // Формируем строку с данными о смене
            string workShiftData = $"{employeeName};{startTime};{endTime}";

            try
            {
                // Задайте путь к файлу для сохранения данных о сменах
                string dataFilePath = @"C:\user\work_shifts.txt";

                // Записываем данные в файл
                using (StreamWriter writer = new StreamWriter(dataFilePath, true))
                {
                    writer.WriteLine(workShiftData);
                    writer.Flush();
                }

                // Очищаем поля ввода после сохранения
                textBox1.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;

                // Оповещаем пользователя об успешном сохранении данных
                MessageBox.Show("Данные о смене успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных о смене: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm addForm = new MainForm(guest);
            addForm.Show();
            this.Hide();
        }
    }
}
