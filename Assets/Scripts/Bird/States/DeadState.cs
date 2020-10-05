using Flappy.Events;

using System.Collections;
using System;

using UnityEngine;

namespace Flappy.Bird.States
{
    public interface IDeathEvent : IEventHandler
    {
        void OnDeath();
    }

    public class DeadState : AbstractState
    {
        private static readonly Quaternion downAngle = Quaternion.Euler(0f, 0f, -90f);

        private Func<IEnumerator, Coroutine> rotateCallback;

        public DeadState(BirdStateMachine stateMachine) : base(stateMachine)
        {
            rotateCallback = stateMachine.StartCoroutine;
        }

        public override void OnEnter()
        {
            animator.speed = 0;

            rotateCallback.Invoke(RotateDown());

            EventSystem.Active.Execute<IDeathEvent>();
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {
           
        }

        private IEnumerator RotateDown()
        {
            while (transform.rotation.z != -90f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, downAngle, Time.deltaTime * 333);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}