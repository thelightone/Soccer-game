using UnityEngine;

public class Ticker : MonoBehaviour
{
    public delegate void TickDelegate();
    public static event TickDelegate OnTick;

    private void FixedUpdate()
    {
        OnTick?.Invoke();
    }
}
