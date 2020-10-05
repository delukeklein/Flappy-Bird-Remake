using System;
using System.Collections.Generic;

namespace Flappy.Events
{
    public abstract class AbstractEvent
    {
        public Type Type { get; protected set; }
    }

    public class Event<T> : AbstractEvent where T : IEventHandler
    {
        private List<EventCallback> callbacks;

        public Event() : base()
        {
            callbacks = new List<EventCallback>();

            Type = typeof(T);
        }

        public void AddListener(T t, EventCallback<T> callback)
        {
            callbacks.Add(new EventCallback(t, callback));
        }

        public void Execute()
        {
            for (int i = 0; i < callbacks.Count; i++)
            {
                callbacks[i].Callback.Invoke(callbacks[i].EventType);
            }
        }

        private struct EventCallback
        {
            public EventCallback(T t, EventCallback<T> callback)
            {
                EventType = t;
                Callback = callback;
            }

            public T EventType { get; private set; }

            public EventCallback<T> Callback { get; private set; }
        }
    }
}