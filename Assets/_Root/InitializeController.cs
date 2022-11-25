using _Root.Enemies.Cannon;
using _Root.Player.Movement;
using Game;
using Game.PlayerFactory;

namespace _Root
{
    public class InitializeController
    {
        public InitializeController(EntryPoint entryPoint, ExecutableController executableController)
        {
            var playerInput = new PlayerInput();
            var playerFactory = new PlayerFactory(entryPoint.PlayerConfiguration, playerInput.PlayerMovement,
                executableController);
            var playerController = playerFactory.CreatePlayer();
            var cannonFactory = new CannonFactory(playerFactory.PlayerView.transform, entryPoint.CannonConfiguration, executableController);
            var cannonController = cannonFactory.CreateCannon();
        }
    }
}