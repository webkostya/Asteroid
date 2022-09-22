using UnityEngine;
using Common;

namespace Weapon
{
    public class WeaponBullet : MonoBehaviour, IEntityData, IEntityEvents
    {
        [SerializeField]
        private float speedMove = 50f;

        public Vector2 Velocity { get; private set; }
        public Vector2 RenderSize => default;

        private Transform _self;
        private Rigidbody2D _body;

        private void Awake()
        {
            _self = transform;
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _body.velocity = Velocity * speedMove;
        }

        /// <summary>
        /// Set Velocity
        /// </summary>
        /// <param name="velocity"></param>
        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            var layerMask = other.gameObject.layer;

            if (layerMask == LayerMask.NameToLayer("Enemy"))
            {
                SetActive(false);
            }
        }

        private void OnBecameInvisible()
        {
            SetActive(false);
        }

        private void OnDisable()
        {
            Velocity = Vector2.zero;
        }
    }
}