using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enums;

public class BrainManager : MonoBehaviour
{
    [SerializeField] BrainSO brainSO;
    [Header(" ~~~~~~~~~~~~~~ Memory ~~~~~~~~~~~~~~ ")]
    [SerializeField] Image memorryImage;
    [SerializeField] Text memoryValue;

    [Header(" ~~~~~~~~~~~~~~ Speed ~~~~~~~~~~~~~~ ")]
    [SerializeField] Image speedImage;
    [SerializeField] Text speedValue;

    [Header(" ~~~~~~~~~~~~~~ Decision ~~~~~~~~~~~~~~ ")]
    [SerializeField] Image decisionImage;
    [SerializeField] Text decisionValue;

    [Header(" ~~~~~~~~~~~~~~ Observatýon ~~~~~~~~~~~~~~ ")]
    [SerializeField] Image observationImage;
    [SerializeField] Text observationValue;

    [Header(" ~~~~~~~~~~~~~~ Calculation ~~~~~~~~~~~~~~ ")]
    [SerializeField] Image calculationImage;
    [SerializeField] Text calculationValue;


    [Header(" ~~~~~~~~~~~~~~ Brain Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] float imageDuration;

    private void OnEnable()
    {
        EventManager.GameAddBrain += AddBrainChapters;
    }
    private void OnDisable()
    {
        EventManager.GameAddBrain -= AddBrainChapters;
    }

    private void Start()
    {
        SetStartBrainValue();
    }

    void SetStartBrainValue()
    {
        memorryImage.fillAmount = brainSO.memoryAverage / 100;
        memoryValue.text = "%" +brainSO.memoryAverage;

        speedImage.fillAmount = brainSO.speedAverage / 100;
        speedValue.text = "%" + brainSO.speedAverage;

        decisionImage.fillAmount = brainSO.decisionAverage / 100;
        decisionValue.text = "%" + brainSO.decisionAverage;

        observationImage.fillAmount = brainSO.observationAverage / 100;
        observationValue.text = "%" + brainSO.observationAverage;

        calculationImage.fillAmount = brainSO.calculataionAverage / 100;
        calculationValue.text = "%" + brainSO.calculataionAverage;
    }

    public void AddBrainChapters(BrainEnum brainEnum, float value)
    {
        if (brainEnum == BrainEnum.Memory)
        {
            AddMemory(value);
        }
        else if (brainEnum == BrainEnum.Speed)
        {
            AddSpeed(value);
        }
        else if (brainEnum == BrainEnum.Decision)
        {
            AddDecision(value);
        }
        else if (brainEnum == BrainEnum.Observation)
        {
            AddObservatýon(value);
        }
        else if (brainEnum == BrainEnum.Calculation)
        {
            AddCalculation(value);
        }
    }

    void AddMemory(float value)
    {
        brainSO.memoryLast10Game.RemoveAt(0);
        brainSO.memoryLast10Game.Add(value);
        brainSO.memoryAverage = ArithmeticAverage(brainSO.memoryLast10Game.ToArray());
        memorryImage.fillAmount = brainSO.memoryAverage / 100;
        memoryValue.text = "%" + brainSO.memoryAverage;
    }

    void AddSpeed(float value)
    {
        brainSO.speedLast10Game.RemoveAt(0);
        brainSO.speedLast10Game.Add(value);
        brainSO.speedAverage = ArithmeticAverage(brainSO.speedLast10Game.ToArray());
        speedImage.fillAmount = brainSO.speedAverage / 100;
        speedValue.text = "%" + brainSO.speedAverage;
    }

    void AddDecision(float value)
    {
        brainSO.decisionLast10Game.RemoveAt(0);
        brainSO.decisionLast10Game.Add(value);
        brainSO.decisionAverage = ArithmeticAverage(brainSO.decisionLast10Game.ToArray());
        decisionImage.fillAmount = brainSO.decisionAverage / 100;
        decisionValue.text = "%" + brainSO.decisionAverage;
    }

    void AddObservatýon(float value)
    {
        brainSO.observatýonLast10Game.RemoveAt(0);
        brainSO.observatýonLast10Game.Add(value);
        brainSO.observationAverage = ArithmeticAverage(brainSO.observatýonLast10Game.ToArray());
        observationImage.fillAmount = brainSO.observationAverage / 100;
        observationValue.text = "%" + brainSO.observationAverage;
    }

    void AddCalculation(float value)
    {
        brainSO.calculationLast10Game.RemoveAt(0);
        brainSO.calculationLast10Game.Add(value);
        brainSO.calculataionAverage = ArithmeticAverage(brainSO.calculationLast10Game.ToArray());
        calculationImage.fillAmount = brainSO.calculataionAverage / 100;
        calculationValue.text = "%" + brainSO.calculataionAverage;
    }

    float ArithmeticAverage(float[] array)
    {
        float k = 0;

        for (int i = 0; i < array.Length; i++)
        {
            k += array[i];
        }
        return k / array.Length;
    }

}
