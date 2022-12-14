using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class EnemyAl : MonoBehaviour, IInterract
{
    UIManager UIManager;
    NavMeshAgent nav;
    private float OverlapRadius = 100;
    private Transform nearestEnemy;
    [SerializeField] Transform player;
    private int enemyLayer;
    Animator animator;
    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Player");
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        animator.SetBool("Walking", true);

    }
    private void Update()
    {
        GetClosestEnemy();
        animator.SetBool("Walking", true);
        if (Vector3.Distance(nav.destination, nav.transform.position) <= nav.stoppingDistance)
        {
            if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Attacking", true);
            }

        }
        else if (Vector3.Distance(nav.destination, nav.transform.position) >= nav.stoppingDistance)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Attacking", true);
        }


    }
    void GetClosestEnemy()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
                nav.SetDestination(nearestEnemy.position);
            }
        }
    }

    public void interract()
    {
        StartCoroutine(nameof(Die));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Money.coinGoEvent?.Invoke(player.transform);
            interract();
        }
    }
    IEnumerator Die()
    {
        UIManager.Instance.KillEvent?.Invoke();
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
