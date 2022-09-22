using UnityEngine;

namespace Common
{
    public interface IEntityEvents
    {
        void SetVelocity(Vector2 velocity);

        void SetPosition(Vector2 position);
        void SetRotation(Quaternion rotation);

        void SetActive(bool isActive);
    }
}