using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enums;

public class CartFollowTheLeader : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartDefaultColor;
    [SerializeField] Color cartGreyColor;
    [SerializeField] Color cartColor;
    [SerializeField] Animator anim;

    [Header("----------------------------------------------")]
    [SerializeField] public bool isContact = false;
    [SerializeField] public int cartID = -1;
    public static int id = 0;
    public static int successCount = 0;
    public int totalSuccessCount;


    private void OnMouseDown()
    {
        if (isContact)
        {
            TrueSelectCart();
        }
    }

    void TrueSelectCart()
    {
        id++;
        if (id == cartID)
        {
            Debug.Log("Select True ");
            TrueSelectAnim();
            successCount++;
            if (successCount == totalSuccessCount)
            {
                id = 0;
                successCount = 0;
                Debug.Log("Success");
                EventManager.GamePlayScore(ScoreEnum.ScoreFollowTheLeader);
                EventManager.GamePlayLevelBoost(LevelBoostEnum.LevelBoostFollowTheLeader);
                GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedFollowTheLeader, GamePrefab.PrefabFollowTheLeader);
            }

        }
        else
        {
            Vibration.Vibrate(25);
            id = 0;
            successCount = 0;
            Debug.Log("Fail");
            StartCoroutine(FailCoroutine());
            
        }
    }

    public void ColorChange(int k , float duration)
    {
        transform.DOScale(Vector3.one * 1.2f, duration *k). OnComplete (() => transform.DOScale(Vector3.one, .1f));
        spriteRenderer.DOColor(cartDefaultColor, duration * k).OnComplete(() =>spriteRenderer.DOColor(cartGreyColor, .1f));
    }

    public void ColorChangeCoroutine()
    {
        spriteRenderer.color = cartColor;
    }
    void TrueSelectAnim()
    {
        transform.DOScale(Vector3.one* 1.5f, .5f);
        spriteRenderer.DOFade(0,.5f);
    }

    IEnumerator FailCoroutine()
    {
        EventManager.GamePlayFollowTheClosedCart();
        FailColorAnim();
        yield return new WaitForSeconds(2f);
        GameManager.Instance.RestartGame(MemorizedRoot.MemorizedFollowTheLeader, GamePrefab.PrefabFollowTheLeader);
    }

    void FailColorAnim()
    {
        anim.enabled = true;
        //spriteRenderer.DOFade(0,.5f).OnComplete(() => spriteRenderer.DOFade(100, .5f)).SetLoops(4);
    }
}
