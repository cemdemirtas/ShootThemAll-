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
        UIManager.Instance.UpgradePanelHide();
    }
    public void UpgradeFireCount()
    {
        UIManager.Instance.UpgradePanelHide();
        if (_upgradeSO.BulletCount >= 2) return;
        _upgradeSO.BulletCount++;
    }
}
