using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace pupitka2GARMUH
{
    public partial class ReadersForm : Form
    {
    void RefreshGrid()
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = Storage.Readers;
        
        // Опционально: настраиваем отображение колонок
        if (dataGridView1.Columns.Count > 0)
        {
            dataGridView1.Columns["FullName"].HeaderText = "ФИО";
            dataGridView1.Columns["Phone"].HeaderText = "Телефон";
            dataGridView1.Columns["Ticket"].HeaderText = "Билет";
        }
    }

    public ReadersForm()
    {
        InitializeComponent();
        RefreshGrid();
        
        // Разрешаем выделение всей строки
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        // Разрешаем множественное выделение (опционально)
        dataGridView1.MultiSelect = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text))
        {
            MessageBox.Show("Введите ФИО читателя!");
            return;
        }
        
        Reader newReader = new Reader
        {
            FullName = textBox1.Text,
            Phone = textBox2.Text,
            Ticket = "№" + (Storage.Readers.Count + 1)
        };
        Storage.Readers.Add(newReader);
        RefreshGrid();
        
        // Очищаем поля после добавления
        textBox1.Text = "";
        textBox2.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
        // Проверяем, есть ли выделенные строки
        if (dataGridView1.SelectedRows.Count > 0)
        {
            // Получаем индекс первой выделенной строки
            int index = dataGridView1.SelectedRows[0].Index;
            
            if (index >= 0 && index < Storage.Readers.Count)
            {
                // Подтверждение удаления
                DialogResult result = MessageBox.Show(
                    $"Вы действительно хотите удалить читателя \"{Storage.Readers[index].FullName}\"?", 
                    "Подтверждение удаления", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    Storage.Readers.RemoveAt(index);
                    RefreshGrid();
                   
                }
            }
        }
        else if (dataGridView1.CurrentRow != null)
        {
            // Альтернативный способ через CurrentRow
            int index = dataGridView1.CurrentRow.Index;
            
            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить читателя \"{Storage.Readers[index].FullName}\"?", 
                "Подтверждение удаления", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Storage.Readers.RemoveAt(index);
                RefreshGrid();
            }
        }
        else
        {
            MessageBox.Show("Пожалуйста, выделите читателя в таблице для удаления!", 
                          "Ошибка", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Warning);
        }
    }
}

}
