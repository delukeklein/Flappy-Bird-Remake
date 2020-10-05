using UnityEngine;

public class PipesScroller : Scroller
{
    [SerializeField] private float[] verticalPositions;

    private void Awake()
    {
        RandomizeVertical();
    }

    protected override void Reposition()
    {
        base.Reposition();

        RandomizeVertical();
    }

    private void RandomizeVertical()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(0, verticalPositions.Length), transform.position.z);
    }
}
