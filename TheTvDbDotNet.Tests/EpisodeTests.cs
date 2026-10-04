using NSubstitute;
using TheTvdbDotNet.Http;

namespace TheTvDbDotNet.Tests
{
    public class EpisodeTests
    {
        [Fact]
        public void When_Updating_Show_It_Should_Refresh_All_Episodes()
        {
            var httpClient = Substitute.For<IAuthenticatedTvdbHttpClient>(); 
            
        }
    }
}
