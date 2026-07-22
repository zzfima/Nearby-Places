using StackExchange.Redis;

namespace NearbyPlaces.Redis
{
    public class RedisCrud
    {
        private ConnectionMultiplexer _connection;
        IDatabase _db;
        public async Task Connect()
        {
            string connectionString = "localhost:6379";
            _connection = await ConnectionMultiplexer.ConnectAsync(connectionString);
            _db = _connection.GetDatabase();
        }

        public async Task<string> RetrieveValue(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task Disonnect()
        {
            await _connection.CloseAsync();
        }
    }
}
