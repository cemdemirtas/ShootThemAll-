using System;
using UnityEngine;

namespace Tarodev {
    
    public class Missile : MonoBehaviour {
        ClosestEnemy _closestEnemy;
        Target targetsc;

        [Header("REFERENCES")] 
        [SerializeField] private Rigidbody _rb;
        //[SerializeField] private Target _target;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _explosionPrefab;

        [Header("MOVEMENT")] 
        [SerializeField] private float _speed = 55;
        [SerializeField] private float _rotateSpeed = 195;

        [Header("PREDICTION")] 
        [SerializeField] private float _maxDistancePredict = 100;
        [SerializeField] private float _minDistancePredict = 5;
        [SerializeField] private float _maxTimePrediction = 5;
        private Vector3 _standardPrediction, _deviatedPrediction;

        [Header("DEVIATION")] 
        [SerializeField] private float _deviationAmount = 50;
        [SerializeField] private float _deviationSpeed = 2;
        private void Awake()
        {
            _closestEnemy = new ClosestEnemy();
            targetsc = new Target();
            _target = _closestEnemy.nearestEnemy;
        }
        private void FixedUpdate() {
            if (_closestEnemy == null) return;
            _closestEnemy.GetNearestEnemy(transform);
            _target = _closestEnemy.nearestEnemy;

            _rb.velocity = transform.forward * _speed;

            var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(transform.position, _target.GetComponent<Target>().transform.position));

            PredictMovement(leadTimePercentage);

            AddDeviation(leadTimePercentage);

            RotateRocket();
        }
        private void Update()
        {
            if (_closestEnemy == null) return;
            _closestEnemy.GetNearestEnemy(transform);
            _target = _closestEnemy.nearestEnemy;


        }
        private void PredictMovement(float leadTimePercentage) {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = _target.GetComponent<Target>().Rb.position + _target.GetComponent<Rigidbody>().velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage) {
            var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);
            
            var predictionOffset = transform.TransformDirection(deviation) * _deviationAmount * leadTimePercentage;

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }

        private void RotateRocket() {
            var heading = _deviatedPrediction - transform.position;

            var rotation = Quaternion.LookRotation(heading);
            _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision collision) {
            if(_explosionPrefab) Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            if (collision.transform.TryGetComponent<IExplode>(out var ex)) ex.Explode();
   
            Destroy(gameObject);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, _standardPrediction);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
        }
    }
}