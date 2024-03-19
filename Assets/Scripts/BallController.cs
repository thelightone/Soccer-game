using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audio;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Invoke("Death", 20);
    }

    private void Death()
    {
        CancelInvoke();

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        BallSpawner.Instance.DespawnBall(this);
    }

    private IEnumerator PauseDeath()
    {
        yield return new WaitForSeconds(0.2f);
        Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audio.Play();
    }

    public void InWinZone()
    {
        StartCoroutine(PauseDeath());
    }

    public void GetHit(float power)
    {
        _rb.AddForce(transform.forward * power, ForceMode.Impulse);
    }
}
