using UnityEngine;
using Common;

namespace Enemies
{
    public class EnemyModel : MonoBehaviour, IEntityDamage
    {
        [SerializeField]
        private EnemyData data;

        private EnemyData _prevData;
        private EnemyData _nextData;

        private IEntityUpdate<EnemyData> _ctrl;
        private IEntityUpdate<EnemyData> _view;

        private void Awake()
        {
            _view = GetComponent<EnemyView>();
            _ctrl = GetComponent<EnemyCtrl>();
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