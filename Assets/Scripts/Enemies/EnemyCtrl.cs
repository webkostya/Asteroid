using UnityEngine;
using Common;

namespace Enemies
{
    public class EnemyCtrl : MonoBehaviour, IEntityUpdate<EnemyData>
    {
        private IEntityDamage _model;

        private void Awake()
        {
            _model = GetComponent<EnemyModel>();
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="prevData"></param>
        /// <param name="nextData"></param>
        public void OnUpdateEvent(EnemyData prevData, EnemyData nextData)
        {
            if (nextData.health <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var layerMask = other.gameObject.layer;

            if (layerMask == LayerMask.NameToLayer("Bullet"))
            {
                _model.OnDamageEvent(10);
            }

            if (layerMask == LayerMask.NameToLayer("Character"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}