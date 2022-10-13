using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour, IInterract
{
    EnemyAl _enemyAl;
    ClosestEnemy _closestEnemy;
    [SerializeField] Transform _missile;
    private void Awake()
    {
        _enemyAl = new EnemyAl();
        _closestEnemy = new ClosestEnemy();
    }
    //ShootingManager _shootingManager;
    //public BulletHit(ShootingManager shootingManager)
    //{
    //    _shootingManager = shootingManager; 
    //}
    public void interract()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        setFalse();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IInterract intr)) //require enemy components
        {
            StartCoroutine(SpawnObject());
        }
      
        IEnumerator SpawnObject()
        {
            float rndmpos= Random.Range(-2f, 2f);
            Vector3 variousPos = new Vector3(rndmpos,1f, rndmpos);
            yield return new WaitForSeconds(2f);
            GameObject pooledGameobject = PoolingManager.instance.SpawnFromPool("Enemy", transform.position+ variousPos, Quaternion.identity);
            GameObject Money = PoolingManager.instance.SpawnFromPool("Money", transform.position,  Quaternion.Euler(-90,0,0));
            pooledGameobject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            interract();
        }
    }
    IEnumerator setFalse()
    {
        yield return new WaitForSeconds(2.5f);
        interract();
    }
}
