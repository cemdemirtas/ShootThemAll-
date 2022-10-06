using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMechanics : MonoBehaviour
{
    Shoot _shoot;
    [SerializeField] UpgradeSO _upgradeSO;
    private void OnEnable()
    {
        _shoot = new Shoot();
    }
    public void UpgradeFireRate()
    {
        _upgradeSO.BulletForwardSpeed = _upgradeSO.BulletForwardSpeed + 10;
        UIManager.instance.UpgradePanelHide();
    }
}
