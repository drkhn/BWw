using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CartSpinnigBlock : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Cart Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator anim;

    [Header("----------------------------------------------")]
    [SerializeField] public bool isContact = false;
    [SerializeField] public bool isColor = false;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartColor;
    public static int successCount = 0;

    private void OnMouseDown()
    {
        if (isContact)
        {
            Debug.Log("Cart");
            TrueSelectCart();
        }
    }

    void TrueSelectCart()
    {
        if (isColor)
        {
            successCount++;
            spriteRenderer.color = cartColor;
            Debug.Log("Doðru Týklandý");
            if (successCount == 3)
            {
                successCount = 0;
                Debug.Log("Success");
                EventManager.GamePlayScore(ScoreEnum.ScoreSpinningBlcok);
                EventManager.GamePlayLevelBoost(LevelBoostEnum.LevelBoostSpinningBlock);
                GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedSpinningBlcok, GamePrefab.PrefabSpinningBlcok);
            }
        }
        else
        {
            Debug.Log("Fail");
            Vibration.Vibrate(25);
            successCount = 0;
            StartCoroutine(FailCoroutine());
           
        }
    }


    IEnumerator FailCoroutine()
    {
        anim.enabled = true;
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.RestartGame(MemorizedRoot.MemorizedSpinningBlcok, GamePrefab.PrefabSpinningBlcok);
    }
}
