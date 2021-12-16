using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Effect;


namespace Sample
{
    public class EffectPool : MonoBehaviour
    {


        public enum PoolType
        {
            Stack,
            LinkedList
        }

        public PoolType poolType;

        // Collection checks will throw errors if we try to release an item that is already in the pool.
        public bool collectionChecks = true;

        public int maxPoolSize = 10;

        public ParticleSystem original;
        private IObjectPool<ParticleSystem> _pool;

        private IObjectPool<ParticleSystem> Pool
        {
            get
            {
                if (_pool == null)
                {
                    if (poolType == PoolType.Stack)
                        _pool = new ObjectPool<ParticleSystem>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        _pool = new LinkedPool<ParticleSystem>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return _pool;
            }
        }

        private ParticleSystem CreatePooledItem()
        {
            var ps = Instantiate(original, transform, false);
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // This is used to return ParticleSystems to the pool when they have stopped.
            var returnToPool = ps.gameObject.AddComponent<ReturnToPool>();
            returnToPool.Pool = Pool;

            return ps;
        }

        // Called when an item is returned to the pool using Release
        private void OnReturnedToPool(ParticleSystem system)
        {
            system.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        private void OnTakeFromPool(ParticleSystem system)
        {
            system.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        private void OnDestroyPoolObject(ParticleSystem system)
        {
            Destroy(system.gameObject);
        }

        public void EffectPlay(Vector3 CreatePos)
        {
            var ps = Pool.Get();
            ps.transform.position = CreatePos;
            ps.Play();
        }
    }
}

