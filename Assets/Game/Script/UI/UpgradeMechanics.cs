using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeMechanics : MonoBehaviour
{
    [SerializeField] UpgradeSO _upgradeSO;

    [SerializeField] ParticleSystem BulletSpeedParticle;
    [SerializeField] ParticleSystem BulletCountParticle;
    [SerializeField] ParticleSystem HealthParticle;

    public void UpgradeFireRate()
    {
        _upgradeSO.BulletForwardSpeed = _upgradeSO.BulletForwardSpeed + 3;
        UIManager.Instance.UpgradePanelHide();
        BulletSpeedParticle.Play();
    }
    public void UpgradeFireCount()
    {
        UIManager.Instance.UpgradePanelHide();
        BulletCountParticle.Play();
        if (_upgradeSO.BulletCount >= 2) return;
        _upgradeSO.BulletCount++;
    }
    public void UpgradeMissileCount()
    {
        UIManager.Instance.UpgradePanelHide();
        _upgradeSO.MissileCount++;
        Shoot.Instance.MissileBuildEvent?.Invoke();
    }
}
