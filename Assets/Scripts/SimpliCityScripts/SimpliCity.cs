using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class SimpliCity : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Simpli City ~~~~~~~~~~~~~~ ")]
    [SerializeField] List<string> calculation = new List<string>();
    [SerializeField] List<GameObject> carts = new List<GameObject>();
    [SerializeField] List<int> randomResult = new List<int>();
    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] public SimpliCitySO simpliCitySO;
    [SerializeField] Text mathText;
    [Header("----------------------------------------------")]
    [SerializeField] int minValue;
    [SerializeField] int maxValue;
    [SerializeField] public int result;



    private void Start()
    {
        Calculations();
        GetCalculationText();
        AlignSimpliCity();
    }
    private void Update()
    {
        TimeControl();
    }

    void TimeControl() // Kaç saniye kaldý bulmak
    {
        simpliCitySO.TimeFunc();
    }


    void Calculations()
    {
        Math1();
    }

    void GetCalculationText()
    {
        EventManager.GamePlaySimpliCityCalculationText(calculation[0]);
    }
    void AlignSimpliCity()
    {
        RandomUniq();
        for (int i = 0; i < carts.Count; i++)
        {
            carts[i].GetComponent<CartSimpliCity>().cartValue = randomResult[i];
        }
    }

    void RandomUniq()
    {
        randomResult.Add(result + Random.Range(1, 5));
        randomResult.Add(result - Random.Range(1, 5));
        randomResult.Add(result * Random.Range(2, 3));
        randomResult.Add(result);

        randomResult = randomResult.OrderBy(a => System.Guid.NewGuid()).ToList();
    }


    void Math1()
    {
        if (simpliCitySO.gameCount == 0)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            result = a + b;
            calculation.Add(a + " + " + b);           
        }

        if (simpliCitySO.gameCount == 1)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            result = a - b;
            calculation.Add(a + " - " + b);
        }

        if (simpliCitySO.gameCount == 2)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            result = a * b;
            calculation.Add(a + " * " + b);
        }
        if (simpliCitySO.gameCount == 3)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            result = (a * b) + c;
            calculation.Add("( " + a + " * " + b +" )" + " + " + c);
        }
        if (simpliCitySO.gameCount == 4)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            result = c - (a * b) ;
            calculation.Add( c + " - " + "( "+ a + " * " + b + " )");
        }
        if (simpliCitySO.gameCount == 5)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            result = c * (a + b);
            calculation.Add(c + " * " + "( " + a + " + " + b + " )");
        }
        if (simpliCitySO.gameCount == 6)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            result = (a - b) * c;
            calculation.Add("( " + a + " - " + b + " )" + " * " + c);
        }
        if (simpliCitySO.gameCount == 7)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            int d = Random.Range(minValue, maxValue);
            result = (a - b) * (c + d);
            calculation.Add("( " + a + " - " + b + " )" + " * " + " ( " + c + " + " + d  + " )");
        }

        if (simpliCitySO.gameCount == 8)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            int d = Random.Range(minValue, maxValue);
            result = (a * b) - (c + d);
            calculation.Add("( " + a + " * " + b + " )" + " - " + " ( " + c + " + " + d + " )");
        }


        if (simpliCitySO.gameCount == 9)
        {
            int a = Random.Range(minValue, maxValue);
            int b = Random.Range(minValue, maxValue);
            int c = Random.Range(minValue, maxValue);
            int d = Random.Range(minValue, maxValue);
            int e = Random.Range(minValue, maxValue);
            result = (a - b) * (c - d) + e;
            calculation.Add("( " + a + " - " + b + " )" + " * " + " ( " + c + " - " + d + " )" + " + " + e);
        }
    }

}
