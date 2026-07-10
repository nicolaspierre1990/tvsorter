using System.Threading;
using System.Threading.Tasks;

namespace TheTvdbDotNet.Authentication;

public interface IAuthenticator
{
    Task AuthenticateIfNecessaryAsync(CancellationToken cancellationToken = default);
}
