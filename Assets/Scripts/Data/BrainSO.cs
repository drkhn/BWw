using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ManagerConig", menuName = "ManagerConfig/Brain", order = 1)]
public class BrainSO : ScriptableObject
{
    public List<float> memoryLast10Game = new List<float>();
    public float memoryAverage;
    [Header("----------------------------------------------")]
    public List<float> speedLast10Game = new List<float>();
    public float speedAverage;
    [Header("----------------------------------------------")]
    public List<float> decisionLast10Game = new List<float>();
    public float decisionAverage;
    [Header("----------------------------------------------")]
    public List<float> observatýonLast10Game = new List<float>();
    public float observationAverage;
    [Header("----------------------------------------------")]
    public List<float> calculationLast10Game = new List<float>();
    public float calculataionAverage;

}
