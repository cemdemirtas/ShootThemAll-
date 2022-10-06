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
    public void Initiliaze(ShootingManager shootingManager)
    {
        _shootingManager = shootingManager;
    }
    void Update()
    {

    }
    public void Fire(ShootingManager shootingManager,Transform target)
    {
        Bullet_Forward_Force = _upgradeSO.BulletForwardSpeed;
        GameObject Temporary_Bullet_Handler = PoolingManager.instance.SpawnFromPool("Bullet", Bullet_Emitter.transform.position, Quaternion.identity);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        //Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
        //transform.LookAt(enemy);
        //Temporary_Bullet_Handler.transform.position = Vector3.Lerp(Bullet_Emitter.position, enemy.position, 5);
        transform.LookAt(target);
        Vector3 direction = (Vector3)target.position - Temporary_RigidBody.position;

        direction.Normalize();

        Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);

        Temporary_RigidBody.angularVelocity = -rotateAmount * 5;

        Temporary_RigidBody.velocity = transform.forward * Bullet_Forward_Force;


    }

}
