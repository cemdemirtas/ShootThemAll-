using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public UnityAction MissileBuildEvent;
    public static Shoot Instance;


    [SerializeField] UpgradeSO _upgradeSO;
    //[SerializeField] Transform Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] private float Bullet_Forward_Force;
    //[SerializeField] public Transform enemy;
    ShootingManager _shootingManager;
    ClosestEnemy _closestEnemy;
    [SerializeField] string _bulletType;

    [SerializeField] List<Transform> _missileList;

    GameManager gameManager;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }

        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();
        AddMissile();
        MissileBuildEvent += AddMissile;
        _shootingManager = GetComponent<ShootingManager>();

    }
    public void Fire(ShootingManager shootingManager, Transform target)
    {
        _bulletType = ((UpgradeSO.bulletTypeEnum)_upgradeSO.BulletCount).ToString();
        Bullet_Forward_Force = _upgradeSO.BulletForwardSpeed;
        GameObject Temporary_Bullet_Handler = PoolingManager.instance.SpawnFromPool(_bulletType, transform.position, Quaternion.Euler(0, 90, 90));
    }
    public void AddMissile()
    {
        if (GameManager.Instance.gamestate != GameManager.GameState.InGame) return;

        for (int i = 0; i < _upgradeSO.MissileCount; i++)
        {
            _missileList[i].gameObject.SetActive(true);
        }
    }

}
