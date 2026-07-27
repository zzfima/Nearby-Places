using StackExchange.Redis;

namespace NearbyPlaces.Redis
{
    public class RedisCrud
    {
        private const string DefaultConnection = "localhost:6379";
        private ConnectionMultiplexer _connection;
        private IDatabase _db;

        public async Task Connect(string? connectionString)
        {
            _connection = await ConnectionMultiplexer.ConnectAsync(connectionString ?? DefaultConnection);
            _db = _connection.GetDatabase();
        }

        public async Task<string> RetrieveValue(string key) => await _db.StringGetAsync(key);

        public async Task Disonnect() => await _connection.CloseAsync();
    }
}
