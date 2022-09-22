using UnityEngine.UI;
using UnityEngine;
using Viewport;
using Handlers;
using Common;

namespace Character
{
    public class CharacterView : MonoBehaviour, IEntityData, IEntityUpdate<CharacterData>
    {
        [SerializeField]
        private Image healthUI;

        public Vector2 Velocity => default;
        public Vector2 RenderSize { get; private set; }

        private Transform _self;
        private Rigidbody2D _body;

        private SpriteRenderer _render;

        private CharacterData _prevData;
        private CharacterData _nextData;

        private static InputHandler InputHandler => InputHandler.Instance;
        private static ViewCamera ViewCamera => ViewCamera.Instance;

        private void Awake()
        {
            _self = transform;

            _body = GetComponent<Rigidbody2D>();
            _render = GetComponent<SpriteRenderer>();

            RenderSize = _render.bounds.size;
        }

        private void FixedUpdate()
        {
            MoveToDirection();
        }

        private void Update()
        {
            HasMovePosition();
        }

        /// <summary>
        /// Move To Direction
        /// </summary>
        private void MoveToDirection()
        {
            _body.velocity = InputHandler.Normalized * (_nextData.speedMove * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Bounds Move Position
        /// </summary>
        private void HasMovePosition()
        {
            var position = _self.position;

            var screenSize = ViewCamera.GetScreenSize();

            var offsetMaxX = position.x + RenderSize.x / 2f;
            var offsetMinX = position.x - RenderSize.x / 2f;

            var offsetMaxY = position.y + RenderSize.y / 2f;
            var offsetMinY = position.y - RenderSize.y / 2f;

            if (offsetMaxX > screenSize.x)
            {
                position.x -= offsetMaxX - screenSize.x;
            }
            else if (offsetMinX < -screenSize.x)
            {
                position.x -= offsetMinX + screenSize.x;
            }

            if (offsetMaxY > screenSize.y)
            {
                position.y -= offsetMaxY - screenSize.y;
            }
            else if (offsetMinY < -screenSize.y)
            {
                position.y -= offsetMinY + screenSize.y;
            }

            _self.position = position;
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="prevData"></param>
        /// <param name="nextData"></param>
        public void OnUpdateEvent(CharacterData prevData, CharacterData nextData)
        {
            (_prevData, _nextData) = (prevData, nextData);

            var amount = _nextData.health / (float)_prevData.health;

            healthUI.fillAmount = amount;
        }
    }
}