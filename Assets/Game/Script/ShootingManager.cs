using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootingManager : MonoBehaviour
{
    ClosestEnemy closestEnemy = new ClosestEnemy();
    //[SerializeField] Shoot shoot;
    [SerializeField] Shoot Shoot;
    //MissileShot missileShot;
    EnemyAl en;
    private void Awake()
    {
        //closestEnemy.Initiliaze(this);
        //shoot.Initiliaze(this);
        en = new EnemyAl();
        //missileShot=new MissileShot();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closestEnemy.OverlapRadius);

    }
    private void Update()
    {
        if (closestEnemy == null) return;
        closestEnemy.GetNearestEnemy(this);
        if (Input.GetKeyDown(KeyCode.X) && closestEnemy.nearestEnemy != null && UIManager.Instance._panelCount < 30)
        {
            Shoot.Fire(this, closestEnemy.nearestEnemy);

        }


        //if (closestEnemy == null) return;
        //closestEnemy.GetNearestEnemy(this);
        //if (Input.GetKeyDown(KeyCode.Space) && closestEnemy.nearestEnemy != null && UIManager.Instance._panelCount < 30)
        //{
        //    shoot.Fire(this, closestEnemy.nearestEnemy);
        //}

    }
}




