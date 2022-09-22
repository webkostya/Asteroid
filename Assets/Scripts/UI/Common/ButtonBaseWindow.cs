using UI.Windows.Common;
using UnityEngine;
using UI.Windows;

namespace UI.Common
{
    public class ButtonBaseWindow : ButtonBase
    {
        [SerializeField]
        protected WindowType windowType;

        [SerializeField]
        protected WindowState windowState;

        private static WindowBehaviour WindowBehaviour => WindowBehaviour.Instance;

        /// <summary>
        /// Invoke Action
        /// </summary>
        protected override void InvokeAction()
        {
            WindowBehaviour.FadeWindow(windowType, windowState == WindowState.Show);
        }
    }
}