using Ninject.Modules;
using TicTacToe.Core.ExternalSystem;

namespace TicTacToe.Core
{
    public class TicTacToeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommonGameNetworkControl>()
                .To<BlamoNetNetworkControlIntegrationTestStub>();
        }
    }
}
