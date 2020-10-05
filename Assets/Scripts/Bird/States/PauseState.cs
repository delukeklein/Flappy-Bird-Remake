using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flappy.Events;

namespace Flappy.Bird.States
{
    public interface IPauseEvent : IEventHandler
    {
        void OnPause();
    }

    public interface IResumeEvent : IEventHandler
    {
        void OnResume();
    }

    public class PauseState : AbstractState
    {
        public PauseState(BirdStateMachine stateMachine) : base(stateMachine) { }

        public override void OnEnter()
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.speed = 0;

            EventSystem.Active.Execute<IPauseEvent>();
        }

        public override void OnExit()
        {
            EventSystem.Active.Execute<IResumeEvent>();
        }

        public override void OnUpdate()
        {
            
        }
    }
}
