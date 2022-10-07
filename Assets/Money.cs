using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Money : MonoBehaviour
{
    [SerializeField] GameObject targetPosition;

    private void Start()
    {
        StartCoroutine(nameof(Destroy));
    }

    IEnumerator Destroy()
    {
       yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
        Debug.Log("money has destroyed");
        targetPosition.transform.DOShakeScale(1, 1);
    }
}
