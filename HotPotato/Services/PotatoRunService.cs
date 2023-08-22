using System.Threading.Tasks;

namespace HotPotato.Services;

public class PotatoRunService
{
    public PotatoRunService() { }

    public async Task RunPotato(int potatoKey)
    {
        await Task.FromResult(0);
    }
}
