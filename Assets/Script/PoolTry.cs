using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTry : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] List<GameObject> cubes;

    private void Awake()
    {
        cubes.Add(cube);
        foreach (var item in cubes)
        {

        }
    }
    private void Start()
    {

    }
}
