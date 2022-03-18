using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Enums;
using DG.Tweening;

public class Concentration : MonoBehaviour
{
    [SerializeField] public ConcentrationSO concentrationSO;
    [Header(" ~~~~~~~~~~~~~~ Simpli City ~~~~~~~~~~~~~~ ")]
    [SerializeField] List<SpriteRenderer> carts = new List<SpriteRenderer>();
    [Header("----------------------------------------------")]
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [Header("----------------------------------------------")]
    [SerializeField] List<int> spriteID = new List<int>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] float rotateDuration = .2f;
    [SerializeField] float finishDuration = .5f;
    [SerializeField] int ID;
    [SerializeField] Sprite closedSrpite;


    private void OnEnable()
    {
        EventManager.GameConcentrationMemorized += MemorizedButton;
    }
    private void OnDisable()
    {
        EventManager.GameConcentrationMemorized -= MemorizedButton;

    }

    private void Start()
    {
        AlignCarts();
    }
    private void Update()
    {
        TimeControl();
    }

    void TimeControl() // Kaç saniye kaldý bulmak
    {
        concentrationSO.TimeFunc();
    }

    void AlignCarts()
    {
        RandomUniq();

        carts[0].sprite = sprites[spriteID[0]];
        carts[1].sprite = sprites[spriteID[0]];
        carts[2].sprite = sprites[spriteID[1]];
        carts[3].sprite = sprites[spriteID[1]];
        carts[4].sprite = sprites[spriteID[2]];
        carts[5].sprite = sprites[spriteID[2]];

        carts[0].gameObject.GetComponent<CartConcentration>().CartID = 1;
        carts[1].gameObject.GetComponent<CartConcentration>().CartID = 1;
        carts[2].gameObject.GetComponent<CartConcentration>().CartID = 2;
        carts[3].gameObject.GetComponent<CartConcentration>().CartID = 2;
        carts[4].gameObject.GetComponent<CartConcentration>().CartID = 3;
        carts[5].gameObject.GetComponent<CartConcentration>().CartID = 3;
    }

    void RandomUniq()
    {
        carts = carts.OrderBy(a => System.Guid.NewGuid()).ToList();
        spriteID = spriteID.OrderBy(a => System.Guid.NewGuid()).ToList();
    }

    public void MemorizedButton()
    {
        ClosedCarts();
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedConcentration, false);
    }

    void ClosedCarts()
    {
        for (int i = 0; i < carts.Count; i++)
        {
            carts[i].gameObject.transform.DORotate(new Vector2(0, 180), rotateDuration).OnComplete (() => DefaultSprite());
        }
        for (int i = 0; i < carts.Count; i++)
        {
            carts[i].gameObject.GetComponent<CartConcentration>().isContact = true;
        }
    }

    void DefaultSprite()
    {
        for (int i = 0; i < carts.Count; i++)
        {
            carts[i].gameObject.GetComponent<SpriteRenderer>().sprite = closedSrpite;
        }
    }
   public void ActivitedCart()
    {
        for (int i = 0; i < carts.Count; i++)
        {
            carts[i].gameObject.GetComponent<CartConcentration>().isContact = true;
           
        }
        DefaultSprite();
    }

    public void TrueSelect(int id)
    {
        for (int i = 0; i < carts.Count; i++)
        {
            if (id == carts[i].gameObject.GetComponent<CartConcentration>().CartID)
            {
                carts[i].gameObject.transform.DOScale(Vector3.zero, finishDuration);
            }
        }

    }
}
