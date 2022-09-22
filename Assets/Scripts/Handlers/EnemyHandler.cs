using System.Collections.Generic;
using System.Collections;
using Handlers.Common;
using System.Linq;
using UnityEngine;
using Enemies;
using Viewport;
using Common;
using Random = UnityEngine.Random;

namespace Handlers
{
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField]
        private EnemyView[] prefabs;

        private Transform _self;

        private Coroutine _coroutine;

        private readonly List<EnemyView> _storage = new();

        private static GameHandler GameHandler => GameHandler.Instance;
        private static ViewCamera ViewCamera => ViewCamera.Instance;

        private const float DelaySpawn = 0.75f;

        private void Awake()
        {
            _self = transform;
        }

        private void Start()
        {
            GameHandler.OnStateEvent += InvokeStateEvent;

            _coroutine = StartCoroutine(WaitForSpawning());
        }

        /// <summary>
        /// Change Game State Event
        /// </summary>
        /// <param name="state"></param>
        private void InvokeStateEvent(GameState state)
        {
            if (state == GameState.Play)
            {
                _coroutine = StartCoroutine(WaitForSpawning());
            }
            else
            {
                StopCoroutine(_coroutine);
            }
        }

        /// <summary>
        /// Spawn Nodes
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForSpawning()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(DelaySpawn);

                var node = InstantiateNode();

                node.SetVelocity(-_self.up);
            }
        }

        /// <summary>
        /// Get Random Position
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static Vector2 GetRandomPosition(IEntityData entity)
        {
            var screenSize = ViewCamera.GetScreenSize();
            var renderSize = entity.RenderSize;

            var maxSize = Mathf.Max(renderSize.x, renderSize.y);

            var coordX = screenSize.x;
            var coordY = screenSize.y + maxSize;

            var position = Vector2.zero;

            position.x = Random.Range(-coordX, coordX);
            position.y = coordY;

            return position;
        }

        /// <summary>
        /// Get Random Rotation
        /// </summary>
        /// <returns></returns>
        private static Quaternion GetRandomRotation()
        {
            var random = Random.Range(-180f, 180f);

            return Quaternion.Euler(0f, 0f, random);
        }

        /// <summary>
        /// Create/Get Node
        /// </summary>
        /// <returns></returns>
        private IEntityEvents InstantiateNode()
        {
            var instance = _storage.FirstOrDefault(node => !node.gameObject.activeSelf);

            if (instance is null)
            {
                var index = Random.Range(0, prefabs.Length);

                instance = Instantiate(prefabs[index]);

                _storage.Add(instance);
            }

            var position = GetRandomPosition(instance);
            var rotation = GetRandomRotation();

            instance.SetPosition(position);
            instance.SetRotation(rotation);

            instance.SetActive(true);

            return instance;
        }

        private void OnDestroy()
        {
            GameHandler.OnStateEvent -= InvokeStateEvent;
        }
    }
}