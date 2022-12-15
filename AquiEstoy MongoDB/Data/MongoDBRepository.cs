using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace AquiEstoy_MongoDB.Data
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://AquiEstoyApp:aquiestoy@cluster0.hw067lh.mongodb.net/?retryWrites=true&w=majority");

            db = client.GetDatabase("AquiEstoyDB");
        }
    }
}
