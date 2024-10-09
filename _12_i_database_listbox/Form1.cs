using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_i_database_listbox
{
    public partial class Form1 : Form
    {
        dbHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start() {
            db = new dbHandler();
            readInfo();
            AddButton.Click += AddButtonClick;
            DeleteButton.Click += DeleteButtonClick;
            DeleteAll.Click += DeleteAllButtonClick;
        }
        void DeleteButtonClick(object s, EventArgs e) {
            int temp = listBox1.SelectedIndex;
            if (temp < 0) { return; }
            db.deleteOne(kolbasz.kolbaszok[temp]);
            kolbasz.kolbaszok.RemoveAt(temp);
            readInfo();
        }
        void DeleteAllButtonClick(object s, EventArgs e) {
            db.deleteAll();
            readInfo();
        }
        void AddButtonClick(object s, EventArgs e) {
            kolbasz oneNewKolbasz = new kolbasz();
            oneNewKolbasz.name = guna2TextBox1.Text;
            oneNewKolbasz.price = Convert.ToInt32(guna2TextBox2.Text);
            oneNewKolbasz.weight = Convert.ToInt32(guna2TextBox3.Text);
            db.insertOne(oneNewKolbasz);
            readInfo();
        }
        void readInfo() {
            
            listBox1.Items.Clear();
            db.readAll();
            foreach (kolbasz item in kolbasz.kolbaszok)
            {
                listBox1.Items.Add($"Kolbász: {item.name}, Ár: {item.price}, Súly: {item.weight}");
            }
        }
       
    }
}
