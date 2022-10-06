using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UpgradeSo", order = 1)]
public class UpgradeSO : ScriptableObject
{
    [SerializeField] public float BulletForwardSpeed;
    [SerializeField] public float BulletCount;
    [SerializeField] public int Health;
}
