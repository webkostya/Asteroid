using UnityEngine;
using Common;

namespace Character
{
    public class CharacterModel : MonoBehaviour, IEntityDamage
    {
        [SerializeField]
        private CharacterData data;

        private CharacterData _prevData;
        private CharacterData _nextData;

        private IEntityUpdate<CharacterData> _ctrl;
        private IEntityUpdate<CharacterData> _view;

        private void Awake()
        {
            _view = GetComponent<CharacterView>();
            _ctrl = GetComponent<CharacterCtrl>();
        }

        private void OnEnable()
        {
            _prevData = Instantiate(data);
            _nextData = Instantiate(data);

            _view.OnUpdateEvent(_prevData, _nextData);
        }

        /// <summary>
        /// Damage Event
        /// </summary>
        /// <param name="value"></param>
        public void OnDamageEvent(int value)
        {
            _nextData.health -= value;

            _view.OnUpdateEvent(_prevData, _nextData);
            _ctrl.OnUpdateEvent(_prevData, _nextData);
        }
    }
}