using UnityEngine;

[RequireComponent(typeof(TwinStickShooter.Rebound))]
[RequireComponent(typeof(TwinStickShooter.MoveForward))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _speed = 1f;

    private void Awake()
    {
        _moveForward = GetComponent<TwinStickShooter.MoveForward>();
        _rebound = GetComponent<TwinStickShooter.Rebound>();
    }


    public float Damage {
        get => _damage;
    }


    public void ChangeSpeed(float speed)
    {
        _speed = speed;
        _moveForward.ChangeSpeed(_speed);
    }


    public void DestroyWithDelay(float delay)
    {
         Destroy(gameObject, delay);
    }


    public void SetBounces(int count)
    {
        _rebound.SetBounce(count);
    }

    private TwinStickShooter.Rebound _rebound;
    private TwinStickShooter.MoveForward _moveForward;
}
