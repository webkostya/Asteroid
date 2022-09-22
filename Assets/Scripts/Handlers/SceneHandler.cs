using Handlers.Common;
using UnityEngine.SceneManagement;

namespace Handlers
{
    public static class SceneHandler
    {
        /// <summary>
        /// Load Scene By Name
        /// </summary>
        /// <param name="gameScene"></param>
        public static void LoadScene(GameScene gameScene)
        {
            SceneManager.LoadScene(gameScene.ToString());
        }
    }
}