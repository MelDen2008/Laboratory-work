using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pupitka2GARMUH
{
    public partial class FundForm : Form
    {
        public FundForm()
        {
            InitializeComponent();
            RefreshGrid();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        // Метод для обновления таблицы
        void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Storage.Books;
        }

        private void FundForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book newBook = new Book
            {
                Title = textBox2.Text,
                Author = textBox1.Text,
                Year = textBox4.Text,
                Status = "В фонде"
            };
            Storage.Books.Add(newBook); // Добавляем в массив
            RefreshGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;

                if (index >= 0 && index < Storage.Books.Count)
                {
                        Storage.Books.RemoveAt(index);
                        RefreshGrid();
                        
                }
            }
        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            string path = "books_report.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("СПИСОК КНИГ:");
                foreach (var book in Storage.Books)
                {
                    sw.WriteLine($"{book.Title} | {book.Author} | {book.Year}");
                }
            }
            MessageBox.Show("Данные сохранены в файл books_report.txt");
        }
    }
}
