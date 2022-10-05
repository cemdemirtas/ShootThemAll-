using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour, IInterract
{
    EnemyAl _enemyAl;
    private void Start()
    {
        _enemyAl = new EnemyAl();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IInterract intr)) //require enemy components
        {
            StartCoroutine(SpawnObject());

        }
      

        IEnumerator SpawnObject()
        {
            float rndmpos= Random.Range(3f, 10f);
            Vector3 variousPos = new Vector3(rndmpos, rndmpos, rndmpos);
            GameObject pooledGameobject = PoolingManager.instance.SpawnFromPool("Enemy", transform.position+ variousPos, Quaternion.identity);
            pooledGameobject.SetActive(true);
            Debug.Log("we hit");
            yield return new WaitForSeconds(1);
            interract();

        }


    }
}
