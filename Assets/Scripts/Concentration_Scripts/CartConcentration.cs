using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CartConcentration : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] Concentration concentration;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite baseSprite;
    [SerializeField] public bool isContact = false;
    [SerializeField] public int CartID;
    [SerializeField] static public int ID;
    [SerializeField] static public int count = 1;
    [SerializeField] static public int successCount = 0;


    private void Start()
    {
        baseSprite = spriteRenderer.sprite;
    }

    private void OnMouseDown()
    {
        if (isContact)
        {
            Debug.Log("Cart");
            // concentration.SelectCart(CartID,count);
            spriteRenderer.sprite = baseSprite;
            SelectCart();
            count++;
            isContact = false;
        }
    }

    void SelectCart()
    {
        if (count % 2 == 1)
        {
            ID = CartID;
        }
        if (count % 2 == 0)
        {
            if (ID == CartID)
            {
                successCount++;
                Debug.Log("True Select" + successCount);
                concentration.TrueSelect(CartID);
                ID = 0;
                //count = 0;
                if (successCount == 3)
                {
                    Debug.Log("Success");
                    EventManager.GamePlayScore(ScoreEnum.ScoreConcentration);
                    EventManager.GamePlayLevelBoost(LevelBoostEnum.LevelBoostConcentration);
                    GameManager.Instance.SuccessGame(MemorizedRoot.MemorizedConcentration, GamePrefab.PrefabConcentration);
                    successCount = 0;
                }
               
            }
            else
            {
                Debug.Log("False Select");
                ID = 0;
                concentration.ActivitedCart();
                GameManager.Instance.RestartGame(MemorizedRoot.MemorizedConcentration, GamePrefab.PrefabConcentration);
                successCount = 0;
                // count = 0;
            }
        }
    }
}
