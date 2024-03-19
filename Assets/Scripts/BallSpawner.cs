using UnityEngine.Pool;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _poolParent;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BallController _ballTemplate;
    [SerializeField] private NetManager _netManager;

    private ObjectPool<BallController> _ballsPool;
    private BallController _tempBall;

    public static BallSpawner Instance;

    private void Start()
    {
        Instance = this;

        _ballsPool = new ObjectPool<BallController>(
         createFunc: () => Instantiate(_ballTemplate, _poolParent),
         actionOnGet: (obj) =>
         {
             _netManager.AddBall(obj.gameObject);
             obj.transform.position = _spawnPoint.position;
             obj.transform.rotation = _spawnPoint.rotation;
             obj.gameObject.SetActive(true);
         }
         ,
         actionOnRelease: (obj) => obj.gameObject.SetActive(false),
         actionOnDestroy: (obj) => Destroy(obj),
         collectionCheck: false,
         defaultCapacity: 20,
         maxSize: 50
        );
    }

    public BallController SpawnBall()
    {
        _tempBall = _ballsPool.Get();
        return _tempBall;
    }

    public void DespawnBall(BallController ball)
    {
        ball.transform.position = transform.position;
        _ballsPool.Release(ball);
    }
}