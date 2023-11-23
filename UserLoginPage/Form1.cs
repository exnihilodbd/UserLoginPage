using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;
using UserInformation;
using MyCustomMongoQuery;
namespace UserLoginPage
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public connection conn = new connection();

        private async void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            var db = conn.database();
            var collection = db.GetCollection<UserClass>(conn.CollectionName);
            var res = await collection.FindAsync(_ => true);
            foreach (var i in res.ToList())
            {
                listBox1.Items.Add(i.username);
            }
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login lg = new login();
            lg.Show();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm form = new RegistrationForm();
            form.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

    }
}
