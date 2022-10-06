using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] UpgradeSO _upgradeSO;
    [SerializeField] Transform Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] private float Bullet_Forward_Force;
    [SerializeField] public Transform enemy;
    ShootingManager _shootingManager;
    [SerializeField] string _bulletType;
    public void Initiliaze(ShootingManager shootingManager)
    {
        _shootingManager = shootingManager;
    }
    private void Awake()
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();
    }
    public void Fire(ShootingManager shootingManager,Transform target)
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();

        Bullet_Forward_Force = _upgradeSO.BulletForwardSpeed;

        GameObject Temporary_Bullet_Handler = PoolingManager.instance.SpawnFromPool(_bulletType, Bullet_Emitter.transform.position, Quaternion.identity);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        transform.LookAt(target);
        Vector3 direction = (Vector3)target.position - Temporary_RigidBody.position;

        direction.Normalize();

        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);

        Temporary_RigidBody.angularVelocity = -rotateAmount * 5;

        Temporary_RigidBody.velocity = transform.forward * Bullet_Forward_Force;


    }

}
