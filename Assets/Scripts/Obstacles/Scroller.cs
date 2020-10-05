using UnityEngine;
using Flappy.Bird.States;
using Flappy.Events;

public class Scroller : MonoBehaviour, IStartEvent
{
    [SerializeField] protected ScrollerSpeed scrollerSpeed;

    [SerializeField] private float threshold;
    [SerializeField] private float repositionXAxis;

    private void Start()
    {
        EventSystem.Active.AddListener<IStartEvent>(this, (e) => e.OnStart());
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * scrollerSpeed.Value;

        if (transform.position.x < threshold)
        {
            Reposition();
        }
    }

    public void OnStart()
    {
        PixelSnap();
    }

    protected virtual void Reposition()
    {
        transform.position += Vector3.right * repositionXAxis;
    }

    private void PixelSnap()
    {
        float x = Mathf.Round(transform.position.x * 24) / 24f;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
