using System.Threading.Tasks;

namespace CodeProdigee.API.Abstractions
{
    public interface IContentFilter
    {
        Task<bool> CheckContent(string stringContent);
    }
}
