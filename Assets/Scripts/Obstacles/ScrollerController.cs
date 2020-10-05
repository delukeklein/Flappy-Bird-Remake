using Flappy.Events;
using Flappy.Bird.States;

using UnityEngine;

public class ScrollerController : MonoBehaviour, IStartEvent, IDeathEvent, IResumeEvent, IPauseEvent
{
    [SerializeField] private ScrollerSpeed pipeSpeed;
    [SerializeField] private ScrollerSpeed landscapeSpeed;

    void Start()
    {
        EventSystem.Active.AddListener<IStartEvent>(this, (e) => e.OnStart());
        EventSystem.Active.AddListener<IDeathEvent>(this, (e) => e.OnDeath());
        EventSystem.Active.AddListener<IResumeEvent>(this, (e) => e.OnResume());
        EventSystem.Active.AddListener<IPauseEvent>(this, (e) => e.OnPause());

        pipeSpeed.Value = 0;
        landscapeSpeed.Value = 2.25f;
    }

    public void OnStart()
    {
        pipeSpeed.Value = 2.25f;
        landscapeSpeed.Value = 2.25f;
    }

    public void OnDeath()
    {
        pipeSpeed.Value = 0f;
        landscapeSpeed.Value = 0f;
    }

    public void OnPause()
    {
        pipeSpeed.Value = 0f;
        landscapeSpeed.Value = 0f;
    }

    public void OnResume()
    {
        pipeSpeed.Value = 2.25f;
        landscapeSpeed.Value = 2.25f;
    }
}
