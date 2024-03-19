using System.Linq;
using UnityEngine;

public class NetManager : MonoBehaviour
{
    private Cloth _cloth;

    void Start()
    {
        _cloth = GetComponent<Cloth>();
    }

    public void AddBall(GameObject ball)
    {
        var collider = ball.GetComponent<CapsuleCollider>();
        var _tempList = _cloth.capsuleColliders.ToList<CapsuleCollider>();

        if (!_tempList.Contains(collider))
        {
            _tempList.Add(collider);
        }
        _cloth.capsuleColliders = _tempList.ToArray();
    }
}
