using Handlers.Common;
using Handlers;
using UI.Common;

namespace UI.Buttons
{
    public class ButtonGamePause : ButtonBaseWindow
    {
        private static GameHandler GameHandler => GameHandler.Instance;

        /// <summary>
        /// Invoke Action
        /// </summary>
        protected override void InvokeAction()
        {
            base.InvokeAction();

            GameHandler.SetState(GameState.Stop);
        }
    }
}