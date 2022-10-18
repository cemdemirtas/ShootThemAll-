using System;
using UnityEngine;
using System.Collections;



public class Missile : MonoBehaviour
{
    ClosestEnemy _closestEnemy;

    [Header("REFERENCES")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _explosionPrefab;

    [Header("MOVEMENT")]
    [SerializeField] private float _rotateSpeed = 195;

    [Header("PREDICTION")]
    [SerializeField] private float _maxDistancePredict = 100;
    [SerializeField] private float _minDistancePredict = 5;
    [SerializeField] private float _maxTimePrediction = 5;
    private Vector3 _standardPrediction, _deviatedPrediction;

    [Header("DEVIATION")]
    [SerializeField] private float _deviationAmount = 50;
    [SerializeField] private float _deviationSpeed = 2;

    private int RandomIndex;


    [SerializeField] private UpgradeSO _upgradeSO;



    private void Awake()
    {
        _closestEnemy = new ClosestEnemy();
        _target = null;
    }
    private void FixedUpdate()
    {
        if (_closestEnemy.nearestEnemy == null)
        {
            _target = _closestEnemy.nearestEnemy;
        }

        _closestEnemy.GetNearestEnemy(transform);
        _target = _closestEnemy.nearestEnemy;
        _rb.velocity = transform.forward * _upgradeSO.BulletForwardSpeed;
        var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, _closestEnemy.nearestEnemy.transform.position));

        PredictMovement(leadTimePercentage);
        AddDeviation(leadTimePercentage);
        RotateRocket();



        if (_target.gameObject.activeSelf == (false))
        {

            this.gameObject.SetActive(false);
        }


    }
    private void Update()
    {
        if (_closestEnemy == null) return;
        _closestEnemy.GetNearestEnemy(transform);
        _target = _closestEnemy.nearestEnemy;
        RandomIndex = UnityEngine.Random.Range(0, _closestEnemy.colliderList.Count);


    }
    private void PredictMovement(float leadTimePercentage)
    {
        var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

        _standardPrediction = _target.GetComponent<Target>().Rb.position + _target.GetComponent<Rigidbody>().velocity * predictionTime;
    }

    private void AddDeviation(float leadTimePercentage)
    {
        var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);

        var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage;

        _deviatedPrediction = _standardPrediction + predictionOffset;
    }

    private void RotateRocket()
    {
        var heading = _deviatedPrediction - transform.position;

        var rotation = Quaternion.LookRotation(heading);
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject pooledExplosionEffect = PoolingManager.instance.SpawnFromPool("ExplosionEffect", transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        pooledExplosionEffect.SetActive(true);
        if (other.transform.TryGetComponent<IExplode>(out var ex)) ex.Explode();
        StartCoroutine((setFalse(pooledExplosionEffect.transform)));
    }
    IEnumerator setFalse(Transform FalseObject)
    {
        yield return new WaitForSeconds(0.5f);
        FalseObject.gameObject.SetActive(false);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, _standardPrediction);
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
    //}
}
