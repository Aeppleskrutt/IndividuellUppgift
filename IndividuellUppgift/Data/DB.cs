using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace IndividuellUppgift.Data
{
    internal class DB
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://antonbubicic:ZthOqwNTYmaObGUc@cluster0.na4e9kk.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() {EnabledSslProtocols=SslProtocols.Tls12};

            var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        public static IMongoCollection<Models.Speedups> UniversalCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("mySpeedupDb");

            var universalCollection = database.GetCollection<Models.Speedups>("MySpeedups");

            return universalCollection;
        }

        public static IMongoCollection<Models.Resources> ResourceCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("mySpeedupDb");

            var resourceCollection = database.GetCollection<Models.Resources>("MyResources");

            return resourceCollection;
        }


    }
}
