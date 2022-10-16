using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ShootingManager : MonoBehaviour
{
     UnityAction<Transform> shootEvent;

    ClosestEnemy closestEnemy = new ClosestEnemy();
    //[SerializeField] Shoot shoot;
    [SerializeField] Shoot Shoot;
    //MissileShot missileShot;
    EnemyAl en;
    float elapsed = 1;

    private void Awake()
    {
       shootEvent += ShootReady;
        //closestEnemy.Initiliaze(this);
        //shoot.Initiliaze(this);
        en = new EnemyAl();
        //missileShot=new MissileShot();
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, closestEnemy.OverlapRadius);

    //}
    private void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        if (closestEnemy == null) return;
        closestEnemy.GetNearestEnemy(transform);
        var closest = closestEnemy.nearestEnemy;

        if ( Input.GetMouseButton(0) && elapsed >= 1f && closestEnemy.nearestEnemy != null && UIManager.Instance._panelCount < 30)
        {
            shootEvent?.Invoke(closest);

            elapsed = elapsed % 1f;

        }

    }

    void ShootReady(Transform transform)
    {
        Shoot.Fire(this, transform);
    }
 
}





