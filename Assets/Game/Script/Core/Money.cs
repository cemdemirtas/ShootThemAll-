using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class Money : MonoBehaviour
{
    [SerializeField]GameObject targetPosition;
   public static UnityAction<Transform> coinGoEvent;
    private void Awake()
    {
    }
    private void OnEnable()
    {
        coinGoEvent += coinGo;
        StartCoroutine(nameof(Destroy));
    }
    private void OnDisable()
    {
        coinGoEvent -= coinGo;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }
    public void coinGo(Transform moveToObject)
    {
        transform.DOMove(moveToObject.transform.position, 1);

    }

}
