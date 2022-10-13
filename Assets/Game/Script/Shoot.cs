using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public UnityAction MissileBuildEvent;
    public static Shoot Instance;


    [SerializeField] UpgradeSO _upgradeSO;
    [SerializeField] Transform Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] private float Bullet_Forward_Force;
    [SerializeField] public Transform enemy;
    ShootingManager _shootingManager;
    ClosestEnemy _closestEnemy;
    [SerializeField] string _bulletType;

    [SerializeField] List<Transform> _missileList;

    GameManager gameManager;
    //public void Initiliaze(ShootingManager shootingManager)
    //{
    //    _shootingManager = shootingManager;
    //}
    private void Awake()
    {
        if (Instance == null) { Instance = this; }

        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();
        //AddMissile();
        //MissileBuildEvent += AddMissile;
        _closestEnemy = new ClosestEnemy();
        _shootingManager = new ShootingManager();

    }
    private void Update()
    {
        //if (_closestEnemy.nearestEnemy == null) return;
        //_closestEnemy.GetNearestEnemy(_shootingManager);

    }
    public void Fire(ShootingManager shootingManager, Transform target)
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();

        Bullet_Forward_Force = _upgradeSO.BulletForwardSpeed;

        GameObject Temporary_Bullet_Handler = PoolingManager.instance.SpawnFromPool(_bulletType, transform.position, Quaternion.Euler(0, 90, 90));

        //Rigidbody Temporary_RigidBody;
        //Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
        //transform.LookAt(target.position, Vector3.up);

        ////transform.localScale =new Vector3(0.369836152f, 4.86124659f, 0.379881471f);
        //Vector3 direction = (Vector3)target.position - Temporary_RigidBody.position;
        //direction.Normalize();
        //Vector3 rotateAmount = Vector3.Cross(direction, transform.forward);

        //Temporary_RigidBody.angularVelocity = -rotateAmount * 5 /** 5*/;
        //Temporary_RigidBody.velocity = transform.forward * Bullet_Forward_Force;

        //if (_closestEnemy.nearestEnemy == null) return;
        //_closestEnemy.GetNearestEnemy(_shootingManager);
        //Transform getclosestEnemy = _closestEnemy.nearestEnemy;
        ////transform.LookAt(getclosestEnemy);

    }
    //public void AddMissile()
    //{
    //    if (GameManager.Instance.gamestate != GameManager.GameState.InGame) return;

    //    for (int i = 0; i < _upgradeSO.MissileCount; i++)
    //    {
    //        _missileList[i].gameObject.SetActive(true);
    //    }
    //}

}
