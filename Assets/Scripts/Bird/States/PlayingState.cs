using UnityEngine;
using Flappy.Events;


namespace Flappy.Bird.States
{
    public interface IScoreHitBoxEvent : IEventHandler
    {
        void OnScore();
    }

    public class PlayingState : AbstractState, IStateCollision
    {

        private const float curve = 3f;

        private float angle;

        private Vector2 force;

        public PlayingState(Vector2 force, BirdStateMachine stateMachine) : base(stateMachine)
        {
            this.force = force;
        }

        public override void OnEnter()
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            rigidbody2D.velocity = force;

            animator.speed = 2;
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidbody2D.velocity = force;
            }

            angle = (Mathf.Clamp(rigidbody2D.velocity.y, -7.2f - curve, 2f - curve) + curve) * 12.5f;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void OnCollision(Collision2D collision)
        {
            if (collision.transform.CompareTag("Pipe") || collision.transform.CompareTag("Landscape"))
            {
                TransitionTo<DeadState>();
            }
        }

        public void OnTrigger(Collider2D collider)
        {
            if (collider.CompareTag("Score Hit Box"))
            {
                EventSystem.Active.Execute<IScoreHitBoxEvent>();
            }
        }
    }
}
