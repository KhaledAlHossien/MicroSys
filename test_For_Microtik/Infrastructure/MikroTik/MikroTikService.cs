namespace test_For_Microtik.Infrastructure.MikroTik
{
    using test_For_Microtik.Application.Interfaces;
    using tik4net;
    using tik4net.Objects;
    using tik4net.Objects.Ip.Hotspot;

    public class MikroTikService : IMikroTikService
    {
        private readonly string _host = "192.168.1.254";
        private readonly string _user = "it";
        private readonly string _password = "it@123456";

        public async Task<Task<IEnumerable<HotspotUser>>> GetHotspotUsersAsync()
        {
            try
            {
                using var connection = ConnectionFactory.CreateConnection(TikConnectionType.Api);

                connection.Open(_host, _user, _password);

                var users = connection.LoadList<HotspotUser>();

                return Task.FromResult(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to MikroTik: " + ex.Message);
            }
        }

        public Task<IEnumerable<HotspotUserProfile>> GetHotspotUsersProfileAsync()
        {
            try
            {
                using var connection = ConnectionFactory.CreateConnection(TikConnectionType.Api);

                connection.Open(_host, _user, _password);

                var profiles = connection.LoadList<HotspotUserProfile>();

                return Task.FromResult(profiles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to MikroTik: " + ex.Message);
            }
        }
    }
}
    
