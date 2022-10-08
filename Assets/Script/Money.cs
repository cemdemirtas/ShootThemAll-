using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] Image targetPosition;

    private void Start()
    {
        StartCoroutine(nameof(Destroy));
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Vector2 vector2 =Camera.main.WorldToScreenPoint(transform.position+Vector3.right*20);
        transform.DOMove((vector2),50);
        yield return new WaitForSeconds(3.5f);
        gameObject.SetActive(false);
        Debug.Log("money has destroyed");
    }
}
