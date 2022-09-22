using UI.Windows.Common;
using UnityEngine;

namespace UI.Windows
{
    public sealed class WindowBase : MonoBehaviour, IWindowEvents
    {
        [SerializeField]
        private WindowType windowType;

        public WindowType WindowType => windowType;

        /// <summary>
        /// Update Visibility
        /// </summary>
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}