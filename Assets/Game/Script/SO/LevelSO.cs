using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "ScriptableObjects/LevelDataSO", order = 1)]

public class LevelSO : ScriptableObject
{
    [SerializeField] public int LevelIndex;
}
