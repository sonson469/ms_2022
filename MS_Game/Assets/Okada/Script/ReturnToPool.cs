using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// This component returns the particle system to the pool when the OnParticleSystemStopped event is received.
namespace Effect
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ReturnToPool : MonoBehaviour
    {
        public IObjectPool<ParticleSystem> Pool;

        private ParticleSystem _system;

        private void Start()
        {
            _system = GetComponent<ParticleSystem>();
            var main = _system.main;
            main.stopAction = ParticleSystemStopAction.Callback;
        }

        private void OnParticleSystemStopped()
        {
            // Return to the pool
            Pool.Release(_system);
        }
    }
}