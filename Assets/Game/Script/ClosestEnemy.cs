using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ClosestEnemy 
{
    ShootingManager _shootingManager;    
    public float OverlapRadius = 1000.0f;
    public int count;
    public int RandomIndex;
    public Transform nearestEnemy;
    private int enemyLayer;
    public List<Transform> colliderList=new List<Transform>();


    public void Initiliaze(ShootingManager shootingManager)
    {
        _shootingManager = shootingManager;
    }
    //private void Start()
    //{
    //    enemyLayer = LayerMask.NameToLayer("Enemy");
    //    Debug.Log(enemyLayer);
    //}

   public void GetNearestEnemy(Transform transform)
    {
        //RandomIndex = Random.Range(0, colliderList.Count);
        enemyLayer = LayerMask.NameToLayer("Enemy");
     

        if (nearestEnemy != null)
        {
            return;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.gameObject.transform.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider collider in hitColliders)
        {
            colliderList.Add(collider.transform);
            nearestEnemy = colliderList[UnityEngine.Random.Range(0, colliderList.Count)].transform;
            float distance = Vector3.Distance(transform.gameObject.transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {

                //minimumDistance = distance;
                //nearestEnemy = collider.transform;

            }
        }
        if (nearestEnemy != null)
        {
            //nearestEnemy.GetComponent<MeshRenderer>().material.color = Color.red;
            //Debug.Log("Nearest Enemy: " + nearestEnemy + "; Distance: " + minimumDistance);
        }
        else
        {
            //Debug.Log("There is no enemy in the given radius");
        }
    }
}
