using UnityEngine;

namespace TwinStickShooter
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnTransform;
        [SerializeField] private float bulletSpeed = 1f;
        [SerializeField] private float interval = 0f;
        [SerializeField] private float bulletLifetime = 1f;

        private float _nextShotTime;

        private void Awake()
        {
            _nextShotTime = Time.time;

        }

        public void Fire(AttackerData attacker)
        {
            if (Time.time >= _nextShotTime)
            {
                _nextShotTime = Time.time + interval;
                SendProjectile(attacker);
            }
        }

        private void SendProjectile(AttackerData attacker)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawnTransform.position, _bulletSpawnTransform.rotation);
            bullet.ChangeSpeed(bulletSpeed);
            bullet.DestroyWithDelay(bulletLifetime);

            AttackProjectileSetter attackerProjectilSetter = bullet.GetComponent<AttackProjectileSetter>();
            if (!attackerProjectilSetter) return;

            attackerProjectilSetter.SetAttacker(attacker);
        }
    }
}