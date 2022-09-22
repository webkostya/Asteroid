namespace Common
{
    public interface IEntityUpdate<in T>
    {
        void OnUpdateEvent(T prevData, T nextData);
    }
}