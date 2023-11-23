using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using UserInformation;
using System.Diagnostics;
using MyCustomMongoQuery;

namespace UserLoginPage
{
    public partial class RegistrationForm : Form
    {
        MongoClient _client;
        string DatabaseName = "UserInfo";
        string CollectionName = "User";
        public RegistrationForm()
        {
            InitializeComponent();
            
        }
        public connection conn = new connection();
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        

        private async void button1_Click(object sender, EventArgs e)
        {
            var db = conn.database();
            var collection = db.GetCollection<UserClass>(conn.CollectionName);
            var filter = Builders<UserClass>.Filter.Eq("username", textBox1.Text);
            var exist = collection.Find(filter).FirstOrDefault();
            UserClass usr = new UserClass();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Fillup completely");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please Fillup completely");
                textBox2.Focus();
            }
            
            else if(exist != null)
            {
                textBox1.Clear();
                textBox1.Focus();
                MessageBox.Show("username unavailable");
            }
            else
            {
                usr.username = textBox1.Text;
                usr.password = textBox2.Text;
                await collection.InsertOneAsync(usr);
                MessageBox.Show("Registration done");
                textBox1.Clear() ;
                textBox2 .Clear() ;
            }

        }

        private void buttonUserlog_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            login lg = new login();
            lg.Show();
        }
    }
}
