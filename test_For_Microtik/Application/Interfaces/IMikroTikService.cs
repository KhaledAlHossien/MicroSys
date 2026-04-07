using tik4net.Objects.Ip.Hotspot;

namespace test_For_Microtik.Application.Interfaces
{
    public interface IMikroTikService
    {
        Task<Task<IEnumerable<HotspotUser>>> GetHotspotUsersAsync();
        Task<IEnumerable<HotspotUserProfile>> GetHotspotUsersProfileAsync();
    }
}
