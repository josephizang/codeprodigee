using CodeProdigee.API.Abstractions;
using System.Threading.Tasks;

namespace CodeProdigee.API.Domain_Services
{
    public class ContentFilter : IContentFilter
    {
        public ContentFilter()
        {

        }
        public Task<bool> CheckContent(string stringContent)
        {
            throw new System.NotImplementedException();
        }
    }
}
