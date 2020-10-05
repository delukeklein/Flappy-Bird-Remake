using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Flappy.UI.Scoreboard.Buttons
{    
    [RequireComponent(typeof(Image), typeof(Collider2D))]
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private Sprite pressedSprite;

        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        void OnMouseDown()
        {
            LoadPlayScene();
        }

        void OnMouseOver()
        {
            image.sprite = pressedSprite;
        }

        void OnMouseExit()
        {
            image.sprite = sprite;
        }

        public void Active(bool boolean)
        {
            GetComponent<Collider2D>().enabled = boolean;
            enabled = boolean;
        }

        private void LoadPlayScene()
        {
            SceneManager.LoadScene("Play Scene");
        }
    }
}