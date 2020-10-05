using System.Collections.Generic;

using UnityEngine;

namespace Flappy.Events
{
    public delegate void EventCallback<T>(T t) where T : IEventHandler;

    public class EventSystem : MonoBehaviour, IEventSystem
    {
        private static EventSystem instance;

        private List<AbstractEvent> events = new List<AbstractEvent>();

        public static IEventSystem Active => instance;

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        public void AddListener<T>(T t, EventCallback<T> callback) where T : IEventHandler
        {
            if (!Contains(t))
            {
                events.Add(new Event<T>());
            }

            ((Event<T>)GetEvent<T>())?.AddListener(t, callback);
        }

        public void Execute<T>() where T : IEventHandler
        {
            ((Event<T>)GetEvent<T>())?.Execute();
        }

        public bool Contains<T>(T t) => events.Exists(e => e.Type == typeof(T));

        private AbstractEvent GetEvent<T>() => events.Find(e => e.Type == typeof(T));
    }
}
