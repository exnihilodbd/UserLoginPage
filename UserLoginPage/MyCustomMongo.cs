using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;
using UserInformation;
using System.Windows.Forms;

namespace MyCustomMongoQuery
{
    public class ex_nihilo
    {
    }

    public class connection
    {
        MongoClient _client;
       public string DatabaseName = "UserInfo";
       public string CollectionName = "User";
        public void Open()
        {
            try
            {
                const string connectionUri = "mongodb+srv://ex_nihilo:000006rS%40md@loginpage.thfc1pi.mongodb.net/?retryWrites=true&w=majority";
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                _client = new MongoClient(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database is not connected. Make sure You have internet access.");
                Application.Exit();
            }
        }
        public  IMongoDatabase database()
        {
            return _client.GetDatabase(DatabaseName);
        }

    }
}
