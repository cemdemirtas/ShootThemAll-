using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectScale : MonoBehaviour
{
    float totalhp = 100;
    public Image hpbarimage;
    private void Awake()
    {
        hpbarimage.GetComponent<Image>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hpbarimage.fillAmount =  totalhp/100;

            totalhp = totalhp - 5;
            Debug.Log("curren hp" + totalhp);
            Debug.Log("bar AMOUNT" + hpbarimage.fillAmount);
        }
    }


}
