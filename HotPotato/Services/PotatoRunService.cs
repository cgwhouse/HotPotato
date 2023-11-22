using System.Collections.Immutable;
using System.Threading.Tasks;

namespace HotPotato.Services
{
    public class PotatoRunService
    {
        public static readonly ImmutableDictionary<int, string> potatoMenuOptions =
            ImmutableDictionary<int, string>.Empty.Add(1, "Sample");

        public PotatoRunService() { }

        public async Task RunPotato(int potatoKey)
        {
            await Task.FromResult(0);
        }
    }
}
