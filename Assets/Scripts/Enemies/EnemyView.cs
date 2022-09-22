using UnityEngine;
using Common;

namespace Enemies
{
    public class EnemyView : MonoBehaviour, IEntityData, IEntityEvents, IEntityUpdate<EnemyData>
    {
        public Vector2 Velocity { get; private set; }
        public Vector2 RenderSize { get; private set; }

        private bool _isVisible;

        private Transform _self;
        private Rigidbody2D _body;

        private SpriteRenderer _render;

        private EnemyData _prevData;
        private EnemyData _nextData;

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
            RotationByAngle();
        }

        /// <summary>
        /// Move To Direction
        /// </summary>
        private void MoveToDirection()
        {
            _body.velocity = Velocity * _nextData.speedMove;
        }

        /// <summary>
        /// Rotation Around
        /// </summary>
        private void RotationByAngle()
        {
            _self.RotateAround(_self.position, Vector3.forward, _nextData.speedTurn * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="prevData"></param>
        /// <param name="nextData"></param>
        public void OnUpdateEvent(EnemyData prevData, EnemyData nextData)
        {
            (_prevData, _nextData) = (prevData, nextData);

            // Percent Health: 0-1
            // var amount = _nextData.health / (float)_prevData.health;
        }

        /// <summary>
        /// Set Velocity
        /// </summary>
        /// <param name="direction"></param>
        public void SetVelocity(Vector2 direction)
        {
            Velocity = direction;
        }

        /// <summary>
        /// Set Position
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            _self.position = position;
        }

        /// <summary>
        /// Set Rotation
        /// </summary>
        /// <param name="rotation"></param>
        public void SetRotation(Quaternion rotation)
        {
            _self.rotation = rotation;
        }

        /// <summary>
        /// Update Visibility
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void OnBecameInvisible()
        {
            SetActive(!_isVisible);
        }

        private void OnBecameVisible()
        {
            _isVisible = true;
        }

        private void OnDisable()
        {
            Velocity = Vector2.zero;
        }
    }
}