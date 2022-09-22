using System;
using System.Collections.Generic;
using System.Collections;
using Handlers.Common;
using UnityEngine;
using System.Linq;
using Handlers;
using Common;

namespace Weapon
{
    public class WeaponBehaviour : MonoBehaviour
    {
        [SerializeField]
        private WeaponBullet prefab;

        [SerializeField]
        private float delayShoot = 0.15f;

        private Transform _self;

        private Coroutine _coroutine;

        private readonly List<WeaponBullet> _storage = new();

        private static GameHandler GameHandler => GameHandler.Instance;

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
                yield return new WaitForSeconds(delayShoot);

                var node = InstantiateNode(_self.position, Quaternion.identity);

                node.SetVelocity(_self.up);
            }
        }

        /// <summary>
        /// Create/Get Node
        /// </summary>
        /// <returns></returns>
        private IEntityEvents InstantiateNode(Vector3 position, Quaternion rotation)
        {
            var instance = _storage.FirstOrDefault(node => !node.gameObject.activeSelf);

            if (instance is null)
            {
                instance = Instantiate(prefab);

                _storage.Add(instance);
            }

            instance.SetPosition(position);
            instance.SetRotation(rotation);

            instance.SetActive(true);

            return instance;
        }

        private void OnDestroy()
        {
            GameHandler.OnStateEvent -= InvokeStateEvent;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}