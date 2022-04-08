using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void ShowInList(List<string> list)
        {
            foreach (string item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        BooksFromSite booksFromSite;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string site = SiteToStringcs.GetSite
                    ("https://tululu.org/search/?q=" + textBox1.Text);
                booksFromSite = new BooksFromSite();
                booksFromSite.Refresh(site);//набор ссылок для скачивания
                ShowInList(booksFromSite.Names);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Текст|*.txt";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string url = "https://tululu.org/" + "/txt.php?id="
                        + booksFromSite.URLs[index].Remove(0,1);
                    //скачивание
                    WebClient client = new WebClient();
                    client.DownloadFile(url, saveFile.FileName);
                }
            }
        }

        /* private void button1_Click(object sender, EventArgs e)
         {
             richTextBox1.Text = SiteToStringcs.GetSite("https://tululu.org/");
         }*///проверка раюотоспособности
    }
}
