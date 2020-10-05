using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.Events
{
    public interface IEventHandler { }

    public interface IEventSystem
    {
        void AddListener<T>(T t, EventCallback<T> callback) where T : IEventHandler;

        void Execute<T>() where T : IEventHandler;
    }
}