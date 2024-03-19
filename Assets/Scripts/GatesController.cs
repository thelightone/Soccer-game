using UnityEngine;

public class GatesController : MonoBehaviour
{
    private const int _leftBorder = -4;
    private const int _rightBorder = 2;
    private bool _goLeft;

    private void OnEnable()
    {
        Ticker.OnTick += UpdateLogic;
    }

    private void OnDisable()
    {
        Ticker.OnTick -= UpdateLogic;
    }

    private void UpdateLogic()
    {
        if (transform.position.z <= _leftBorder || transform.position.z >= _rightBorder)
        {
            _goLeft = !_goLeft;
        }

        if (!_goLeft)
        {
            transform.Translate(Time.deltaTime / 2, 0, 0);
        }
        else
        {
            transform.Translate(-Time.deltaTime / 2, 0, 0);
        }
    }
}
