using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeMechanics : MonoBehaviour
{
    Shoot _shoot;
    [SerializeField] UpgradeSO _upgradeSO;



    [SerializeField] ParticleSystem BulletSpeedParticle;
    [SerializeField] ParticleSystem BulletCountParticle;
    [SerializeField] ParticleSystem HealthParticle;
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        //_shoot = new Shoot();
    }
    public void UpgradeFireRate()
    {
        _upgradeSO.BulletForwardSpeed = _upgradeSO.BulletForwardSpeed + 10;
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
        //BulletCountParticle.Play();
        _upgradeSO.MissileCount++;
        Shoot.Instance.MissileBuildEvent?.Invoke();
        //Shoot.Instance.AddMissile();
    }
}
