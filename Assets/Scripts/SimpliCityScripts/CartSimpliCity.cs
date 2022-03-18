using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Enums;

public class CartSimpliCity : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] public TextMeshPro cartText;
    [SerializeField] public int  cartValue;
    [Header("----------------------------------------------")]
    [SerializeField] SimpliCity simpliCity;
    [Header("----------------------------------------------")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("----------------------------------------------")]
    [SerializeField] float duration;
    [Header("----------------------------------------------")]
    [SerializeField] Color trueColor;

    private void Start()
    {
        cartText.text = cartValue.ToString();
    }


    private void OnMouseDown()
    {
        SelectCart();
    }


    void SelectCart()
    {
        if (cartValue == simpliCity.result)
        {
            Debug.Log("Success");
            TrueSelect();
            //Success();
        }
        else
        {
            Debug.Log("Fail");
            FalseSelect();
        }
    }

    void TrueSelect()
    {
        spriteRenderer.DOColor(trueColor, duration).OnComplete(() => Success());
    }
    void Success()
    {
        EventManager.GamePlayScore(ScoreEnum.ScoreSimpliCity);
        EventManager.GamePlayLevelBoost(LevelBoostEnum.LevelBoostSimpliCity);
        GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedSimpliCity, GamePrefab.PrefabSimpliCity);
    }

    void FalseSelect()
    {
        transform.DOScale(new Vector3(5f,1.5f,1), duration).OnComplete(() => transform.DOScale(new Vector3(4f, 1f, .5f), duration));
        spriteRenderer.DOFade(0f, duration).OnComplete(() => spriteRenderer.DOFade(1f, duration)).OnComplete(() => DoFalse());
        Vibration.Vibrate(25);
    }
    void DoFalse()
    {
        GameManager.Instance.RestartGame(MemorizedRoot.MemorizedSimpliCity, GamePrefab.PrefabSimpliCity);
    }
}
