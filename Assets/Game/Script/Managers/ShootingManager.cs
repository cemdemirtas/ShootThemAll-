using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ShootingManager : MonoBehaviour
{
    UnityAction<Transform> shootEvent;

    ClosestEnemy closestEnemy = new ClosestEnemy();
    [SerializeField] Shoot Shoot;

    float elapsed = 1;

    private void Awake()
    {
        shootEvent += ShootReady;
    }

    private void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        if (closestEnemy == null) return;
        closestEnemy.GetNearestEnemy(transform);
        var closest = closestEnemy.nearestEnemy;

        if (Input.GetMouseButton(0) && elapsed >= 1f && closestEnemy.nearestEnemy != null && UIManager.Instance._panelCount < 45)
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





