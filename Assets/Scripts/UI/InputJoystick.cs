using UnityEngine;
using Handlers;

namespace UI
{
    public class InputJoystick : MonoBehaviour
    {
        [SerializeField]
        private Transform container;

        [SerializeField]
        private Transform pointer;

        private static InputHandler InputHandler => InputHandler.Instance;

        private void LateUpdate()
        {
            var isTouched = InputHandler.TouchBegan.magnitude > 0;

            container.gameObject.SetActive(isTouched);

            container.position = InputHandler.TouchBegan;

            var position = InputHandler.TouchMoved - InputHandler.TouchBegan;

            pointer.localPosition = Vector2.ClampMagnitude(position, 90f);
        }
    }
}