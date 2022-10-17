using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IDamageable 
{
    void takeDamage(int damage, Image hpBarIcon, Transform transform);
}
