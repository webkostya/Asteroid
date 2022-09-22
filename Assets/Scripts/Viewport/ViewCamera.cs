using UnityEngine;

namespace Viewport
{
    public class ViewCamera : MonoBehaviour
    {
        public static ViewCamera Instance { get; private set; }

        private Camera _camera;
        private Vector2 _size;

        private void Awake()
        {
            Instance = this;

            _camera = Camera.main;
        }

        /// <summary>
        /// Get Orthographic Size
        /// </summary>
        /// <returns></returns>
        public Vector2 GetScreenSize()
        {
            var screenAspect = Screen.width / (float)Screen.height;
            var cameraHeight = _camera.orthographicSize;

            _size.x = cameraHeight * screenAspect;
            _size.y = cameraHeight;

            return _size;
        }
    }
}