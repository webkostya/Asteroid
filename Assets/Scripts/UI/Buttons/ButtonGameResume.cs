using Handlers.Common;
using UI.Common;
using Handlers;

namespace UI.Buttons
{
    public class ButtonGameResume : ButtonBaseWindow
    {
        private static GameHandler GameHandler => GameHandler.Instance;

        /// <summary>
        /// Invoke Action
        /// </summary>
        protected override void InvokeAction()
        {
            base.InvokeAction();

            GameHandler.SetState(GameState.Play);
        }
    }
}