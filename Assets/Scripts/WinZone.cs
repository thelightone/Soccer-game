using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private CannonController _controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BallController>(out BallController ball))
        {
            _controller.AddScore();
            ball.InWinZone();
        }
    }
}
