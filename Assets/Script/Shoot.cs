using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : SingletonPersistant<Shoot>
{
    public static UnityAction MissileBuildEvent;


    [SerializeField] UpgradeSO _upgradeSO;
    [SerializeField] Transform Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] private float Bullet_Forward_Force;
    [SerializeField] public Transform enemy;
    ShootingManager _shootingManager;
    [SerializeField] string _bulletType;

    [SerializeField] List<Transform> _missileList;
    public void Initiliaze(ShootingManager shootingManager)
    {
        _shootingManager = shootingManager;
    }
    private void OnEnable()
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();
        AddMissile();
        MissileBuildEvent += AddMissile;
    }
    public void Fire(ShootingManager shootingManager, Transform target)
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();

        Bullet_Forward_Force = _upgradeSO.BulletForwardSpeed;

        GameObject Temporary_Bullet_Handler = PoolingManager.instance.SpawnFromPool(_bulletType, Bullet_Emitter.transform.position, Quaternion.Euler(0, 90, 90));

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        transform.LookAt(target);
        Vector3 direction = (Vector3)target.position - Temporary_RigidBody.position;
        direction.Normalize();

        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);

        Temporary_RigidBody.angularVelocity = -rotateAmount * 5;

        Temporary_RigidBody.velocity = transform.forward * Bullet_Forward_Force;


    }
    void AddMissile()
    {
        for (int i = 0; i < _upgradeSO.MissileCount; i++)
        {
            _missileList[i].gameObject.SetActive(true);
        }
    }
}
