using MongoDB.Driver;
using MyCustomMongoQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInformation;

namespace UserLoginPage
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public connection conn = new connection();

        private void login_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = conn.database();
            var collection = db.GetCollection<UserClass>(conn.CollectionName);

            var filter1 = Builders<UserClass>.Filter.Eq("username", textBox1.Text);         
            var exist1 = collection.Find(filter1).FirstOrDefault();

            var filter2 = Builders<UserClass>.Filter.Eq("username", textBox1.Text) &
                         Builders<UserClass>.Filter.Eq("password", textBox2.Text);
            var exist2 = collection.Find(filter2).FirstOrDefault();
   
            if(exist2 != null)
            {
                MessageBox.Show("Login Successful");
            }
            else if (exist1 != null)
            {
                MessageBox.Show("Wrong Password");
                textBox2.Clear();
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Please make a account if you are new");
                textBox1.Clear();
                textBox1.Focus();
                textBox2.Clear();
            }
        }
    }
}
