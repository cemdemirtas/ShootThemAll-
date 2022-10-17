using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyWeapon : MonoBehaviour, IDamageable
{
    UnityAction<int , Image ,Transform> damageEvent;

    public void takeDamage(int damage, Image hpBarIcon, Transform transform)
    {
        
    }
}
