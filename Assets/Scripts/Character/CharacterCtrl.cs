using UnityEngine;
using Handlers;
using Common;

namespace Character
{
    public class CharacterCtrl : MonoBehaviour, IEntityUpdate<CharacterData>
    {
        private IEntityDamage _model;

        private static GameHandler GameHandler => GameHandler.Instance;

        private void Awake()
        {
            _model = GetComponent<CharacterModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prevData"></param>
        /// <param name="nextData"></param>
        public void OnUpdateEvent(CharacterData prevData, CharacterData nextData)
        {
            if (nextData.health > 0)
            {
                return;
            }

            GameHandler.OnGameComplete();

            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var layerMask = other.gameObject.layer;

            if (layerMask == LayerMask.NameToLayer("Enemy"))
            {
                _model.OnDamageEvent(10);
            }
        }
    }
}