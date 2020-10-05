using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flappy.Bird;
using UnityEngine.UI;
using Flappy.Bird.States;

[RequireComponent(typeof(Image))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private BirdStateMachine birdStateMachine;

    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite toggledSprite;

    private bool isToggled = false;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();    
    }

    void OnMouseDown()
    {
        if(isToggled)
        {
            image.sprite = toggledSprite;
            birdStateMachine.TransitionTo<PauseState>();
        }
        else
        {
            image.sprite = sprite;
            birdStateMachine.TransitionTo<PlayingState>();
        }

        isToggled = !isToggled;
    }
}
