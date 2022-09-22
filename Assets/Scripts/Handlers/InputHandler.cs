using System.Linq;
using UnityEngine;

namespace Handlers
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 TouchBegan { get; private set; }
        public Vector2 TouchMoved { get; private set; }
        public Vector2 Normalized { get; private set; }

        public static InputHandler Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            TouchBegan = GetTouchPosition(TouchBegan, TouchPhase.Began);
            TouchMoved = GetTouchPosition(TouchMoved, TouchPhase.Began, TouchPhase.Moved);

            var distance = Vector2.Distance(TouchBegan, TouchMoved) / 100f;
            distance = Mathf.Clamp(distance, 0f, 1f);

            Normalized = (TouchMoved - TouchBegan).normalized * distance;
            Normalized += GetInputDirection(Normalized);
        }

        /// <summary>
        /// Get Touch Position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="phases"></param>
        /// <returns></returns>
        private static Vector2 GetTouchPosition(Vector2 position, params TouchPhase[] phases)
        {
            if (Input.touchCount == 0)
            {
                return position;
            }

            var touch = Input.GetTouch(0);

            if (touch.phase is TouchPhase.Canceled or TouchPhase.Ended)
            {
                return Vector2.zero;
            }

            return phases.Any(phase => touch.phase == phase)
                ? touch.position
                : position;
        }

        /// <summary>
        /// Get Input Direction
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private static Vector2 GetInputDirection(Vector2 position)
        {
            var axisX = Input.GetAxisRaw("Horizontal");
            var axisY = Input.GetAxisRaw("Vertical");

            position.x = axisX;
            position.y = axisY;

            return position;
        }
    }
}