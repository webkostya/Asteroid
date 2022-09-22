using Handlers.Common;
using UnityEngine;
using Handlers;

namespace UI.Common
{
    public class ButtonBaseScene : ButtonBase
    {
        [SerializeField]
        private GameScene gameScene;

        /// <summary>
        /// Invoke Action
        /// </summary>
        protected override void InvokeAction()
        {
            SceneHandler.LoadScene(gameScene);
        }
    }
}