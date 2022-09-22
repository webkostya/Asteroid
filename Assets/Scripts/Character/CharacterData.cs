using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Custom/Character Data", order = 150)]
    public class CharacterData : ScriptableObject
    {
        [Min(0)]
        public int health;

        [Min(0)]
        public float speedMove;
    }
}