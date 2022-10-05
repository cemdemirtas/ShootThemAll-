using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
   ClosestEnemy closestEnemy=new ClosestEnemy();
    [SerializeField] Shoot shoot;
    EnemyAl en;
    private void Awake()
    {
        //closestEnemy.Initiliaze(this);
        //shoot.Initiliaze(this);
        en = new EnemyAl();

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
        if (Input.GetKeyDown(KeyCode.Space) && closestEnemy.nearestEnemy!=null)
        {
            shoot.Fire(this, closestEnemy.nearestEnemy);

        }
    }

  
}
