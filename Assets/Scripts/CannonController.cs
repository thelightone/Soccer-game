using UnityEngine;

public class CannonController : MonoBehaviour
{
    //CAMERA
    private Vector2 _mousePos;
    private const string _mouseX = "Mouse X";
    private const string _mouseY = "Mouse Y";
    private float _sens = 2;

    [SerializeField] private Transform _muzzle;

    //SHOOT
    private BallSpawner _ballSpawner;
    private BallController _curBall;
    private float _shootForce;
    private float _minForce = 0;
    private float _maxForce = 10;
    private float _forceModif = 10;
    private bool _firePressed;

    //SCORES
    private float _scores;

    [SerializeField] private UIManager _uiManager;

    private void Start()
    {
        _ballSpawner = GetComponent<BallSpawner>();
        _shootForce = _minForce;
    }

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
        _mousePos.x += Input.GetAxis(_mouseX) * _sens;
        _mousePos.y += Input.GetAxis(_mouseY) * _sens;

        _mousePos.y = Mathf.Clamp(_mousePos.y, -10, 10);

        _muzzle.localRotation = Quaternion.Euler(0, _mousePos.y, 0);
        transform.localRotation = Quaternion.Euler(0, _mousePos.x, 0);

        FireCheck();
    }

    private void FireCheck()
    {
        if (_firePressed && _shootForce < _maxForce)
        {
            _shootForce += Time.deltaTime * _forceModif;
            _uiManager.UpdateCharge(_shootForce);
        }
    }

    private void OnMouseDown()
    {
        _firePressed = true;
    }

    private void OnMouseUp()
    {
        _firePressed = false;
        _curBall = _ballSpawner.SpawnBall();
        _curBall.GetHit(_shootForce);
        _shootForce = _minForce;
        _uiManager.UpdateCharge(_shootForce);
    }

    public void AddScore()
    {
        _scores++;
        _uiManager.UpdateScores(_scores);
    }
}
