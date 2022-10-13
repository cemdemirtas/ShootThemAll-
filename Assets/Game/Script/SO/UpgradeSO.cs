using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UpgradeSo", order = 1)]
public class UpgradeSO : ScriptableObject
{
   public enum bulletTypeEnum { Bullet, TwoBullet, ThreeBullet }

    [SerializeField] public float BulletForwardSpeed;
    [SerializeField] public int BulletCount;
    [SerializeField] public int MissileCount;
    [SerializeField] public int Health;
    [SerializeField] public int Money;

    
}
