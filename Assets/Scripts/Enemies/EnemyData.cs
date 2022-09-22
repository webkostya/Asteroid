using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Custom/Enemy Data", order = 150)]
    public class EnemyData : ScriptableObject
    {
        [Min(0)]
        public int health;

        [Min(0)]
        public float speedMove;

        [Min(0)]
        public float speedTurn;
    }
}