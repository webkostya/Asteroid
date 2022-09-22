using UnityEngine;

namespace Common
{
    public interface IEntityData
    {
        public Vector2 Velocity { get; }
        public Vector2 RenderSize { get; }
    }
}