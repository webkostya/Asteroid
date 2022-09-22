using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            _button.onClick.AddListener(InvokeAction);
        }

        /// <summary>
        /// Invoke Action
        /// </summary>
        protected abstract void InvokeAction();

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}