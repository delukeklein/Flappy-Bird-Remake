using UnityEngine;

using Flappy.Events;

namespace Flappy.Bird.States
{
    public interface IStartEvent : IEventHandler
    {
        void OnStart();
    }

    public class IdleState : AbstractState
    {
        private float speed;
        private float height;

        public IdleState(float speed, float height, BirdStateMachine stateMachine) : base(stateMachine)
        {
            this.speed = speed;
            this.height = height;
        }

        public override void OnEnter()
        {
            animator.speed = 0.75f;

            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public override void OnExit()
        {
            EventSystem.Active.Execute<IStartEvent>();
        }

        public override void OnUpdate()
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * height, transform.position.z);

            if (Input.GetMouseButtonDown(0))
            {
                TransitionTo<PlayingState>();
            }
        }
    }
}
