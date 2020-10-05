using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Flappy.Events;
using Flappy.Bird.States;

[RequireComponent(typeof(Image))]
public class PauseOverlay : MonoBehaviour, IPauseEvent, IResumeEvent
{
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        EventSystem.Active.AddListener<IPauseEvent>(this, (e) => e.OnPause());
        EventSystem.Active.AddListener<IResumeEvent>(this, (e) => e.OnResume());
    }

    public void OnPause()
    {
        image.color = new Color(1f, 1f, 1f, 0.4f);
    }

    public void OnResume()
    {
        image.color = Color.clear;
    }

}
