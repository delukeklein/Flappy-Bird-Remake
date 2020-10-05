using Flappy.Events;
using UnityEngine;

namespace Flappy.Bird
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }

    public interface IStateCollision
    {
        void OnCollision(Collision2D collision);
        void OnTrigger(Collider2D collider);
    }

    public abstract class AbstractState : IState
    {
        protected readonly Transform transform;
        protected readonly Rigidbody2D rigidbody2D;
        protected readonly Animator animator;

        private readonly BirdStateMachine stateMachine;

        public AbstractState(BirdStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;

            transform = stateMachine.transform;

            rigidbody2D = stateMachine.GetComponent<Rigidbody2D>();
            animator = stateMachine.GetComponent<Animator>();
        }

        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate();

        protected void TransitionTo<T>() where T : AbstractState => stateMachine.TransitionTo<T>();
    }
}
