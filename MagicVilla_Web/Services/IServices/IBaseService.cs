using MagicVilla_Web.Models;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responsemodel { get; set; }
        public Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
