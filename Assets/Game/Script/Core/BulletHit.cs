using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletHit : MonoBehaviour, IInterract
{

    GameObject pooledMoney;
    [SerializeField] Transform _missile;
    [SerializeField]public static Transform Money ;

    public void interract()
    {
        gameObject.SetActive(false);
    }
    IEnumerator SpawnObject(Transform coinGoObject)
    {
        float rndmpos = Random.Range(-2f, 2f);
        Vector3 variousPos = new Vector3(rndmpos, 1f, rndmpos);
        GameObject pooledGameobject = PoolingManager.instance.SpawnFromPool("Enemy", transform.position + variousPos, Quaternion.identity);
        pooledMoney = PoolingManager.instance.SpawnFromPool("Money", transform.position, Quaternion.Euler(-90, 0, 0));
        pooledMoney.SetActive(true);
        pooledGameobject.GetComponent<CapsuleCollider>().enabled = true;
        pooledGameobject.SetActive(true);
        interract();
        yield return new WaitForSeconds(0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out IInterract intr)) //require enemy components
        {
            StartCoroutine(SpawnObject(other.transform));
            other.transform.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    IEnumerator setFalse()
    {
        yield return new WaitForSeconds(3.5f);
        interract();
    }
}
