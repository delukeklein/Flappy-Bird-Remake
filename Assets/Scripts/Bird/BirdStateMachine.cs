using UnityEngine;

using Flappy.Bird.States;

namespace Flappy.Bird
{
    public interface IStateMachine<T0> where T0 : IState
    {
        void TransitionTo<T>() where T : T0;
    }

    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class BirdStateMachine : MonoBehaviour, IStateMachine<AbstractState>
    {
        private int currentIndex;

        [SerializeField] private float hoverSpeed;
        [SerializeField] private float hoverRange;

        [SerializeField] private Vector2 force;

        private IState[] states;

        void Start()
        {
            states = new IState[4];

            states[0] = new IdleState(hoverSpeed, hoverRange, this);
            states[1] = new PlayingState(force, this);
            states[2] = new PauseState(this);
            states[3] = new DeadState(this);

            currentIndex = 0;

            CurrentState.OnEnter();
        }

        void Update()
        {
            CurrentState.OnUpdate();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (CurrentState is IStateCollision stateRef)
            {
                stateRef.OnCollision(collision);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (CurrentState is IStateCollision currentState)
            {
                currentState.OnTrigger(collider);
            }
        }

        public void TransitionTo<T>() where T : AbstractState
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i].GetType() == typeof(T))
                {
                    CurrentState.OnExit();

                    currentIndex = i;

                    CurrentState.OnEnter();

                    break;
                }
            }
        }

        private IState CurrentState => states[currentIndex];
    }
}