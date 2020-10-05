using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI
{
    public enum Fade
    {
        Out = 0,
        In = 1
    }

    public abstract class Fader : MonoBehaviour
    {
        [SerializeField] private float fadeDuration;

        [SerializeField] private Fade fade;

        private Graphic graphic;
        private Collider2D collider;
        private Button button;

        protected void Start()
        {
            graphic = GetComponent<Graphic>();

            graphic.canvasRenderer.SetAlpha((fade == Fade.In) ? 0 : 1);
        }

        protected IEnumerator FadeCoroutine()
        {
            Enable();

            while (Mathf.Abs(graphic.canvasRenderer.GetAlpha() - (int)fade) > 0.01f)
            {
                graphic.CrossFadeAlpha((int)fade, fadeDuration, false);

                yield return new WaitForEndOfFrame();
            }

            if(fade == Fade.Out)
            {
                if(TryGetComponent(out collider))
                {
                    collider.enabled = false;
                }
            }

            yield break;
        }

        private void Enable()
        {
            graphic.enabled = true;

            if (TryGetComponent(out button))
            {
                button.enabled = true;
            }
            if (TryGetComponent(out collider))
            {
                collider.enabled = true;
            }
        }
    }

}
