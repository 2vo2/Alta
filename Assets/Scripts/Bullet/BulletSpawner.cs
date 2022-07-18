using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Bullet _bulletPrefab;
    
    private List<Bullet> _bullets = new();
    private Vector3 _startScale;

    public ObjectPool<Bullet> Pool { get; set; }

    private void Awake()
    {
        Pool = new ObjectPool<Bullet>
            (SpawnBullet, OnTakeBulletFromPool, OnReturnBulletFromPool);

        _startScale = _bulletPrefab.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetBullet();
        }
    }

    private void OnDestroy()
    {
        foreach (var bullet in _bullets)
        {
            bullet.TriggerBullet -= BulletRelease;
        }
    }

    private void BulletRelease(Bullet bullet) => Pool.Release(bullet);

    private void GetBullet() => Pool.Get();

    private void OnReturnBulletFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.Rigidbody.isKinematic = true;
    }

    private void OnTakeBulletFromPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _spawnPoint.position;
        bullet.transform.localScale = _startScale;
        bullet.Rigidbody.isKinematic = false;
    }

    private Bullet SpawnBullet()
    {
        var newBullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity, transform);
        _bullets.Add(newBullet);
        newBullet.TriggerBullet += BulletRelease;
        return newBullet;
    }
}