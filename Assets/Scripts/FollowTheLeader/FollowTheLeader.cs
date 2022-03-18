using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using Enums;
public class FollowTheLeader : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Follow The Leader ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject carts;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> followTheLeaderCarts = new List<GameObject>();
    [SerializeField] List<GameObject> RandomID = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] public FollowTheLeaderSO followTheLeaderSO;
    [SerializeField] float colorDuration = 1f;
    [SerializeField] float colorTimeDuration = 0f;
    [SerializeField] Color cartDefaultColor;
    [SerializeField]int cartCount;

    private void OnEnable()
    {
        EventManager.GameFollowTheLeaderMemorized += MemorizedButton;
        EventManager.GameFollowTheClosedCart += ClosedCart;
    }
    private void OnDisable()
    {
        EventManager.GameFollowTheLeaderMemorized -= MemorizedButton;
        EventManager.GameFollowTheClosedCart -= ClosedCart;
    }

    private void Start()
    {
        cartCount = followTheLeaderSO.cartArray[followTheLeaderSO.gameCount];
        AlignBlock();

    }
    private void Update()
    {
        TimeControl();
    }

    void TimeControl() // Kaç saniye kaldý bulmak
    {
        followTheLeaderSO.TimeFunc();
    }

    void AlignBlock()
    {
        for (int i = 0; i < carts.transform.childCount; i++)
        {
            followTheLeaderCarts.Add(carts.transform.GetChild(i).gameObject);
        }
        RandomUniq();
        for (int i = 0; i < cartCount; i++)
        {
             RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().isContact = true;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().cartID = i+1;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().totalSuccessCount = cartCount;
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().ColorChange(i, colorDuration);
            colorTimeDuration += colorDuration * i;
        }

        StartCoroutine(ColorCorouitine());
    }

    IEnumerator ColorCorouitine()
    {
        yield return new WaitForSeconds(colorTimeDuration);
        for (int i = 0; i < cartCount; i++)
        {
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().ColorChangeCoroutine();
        }
    }

    void RandomUniq()
    {
        RandomID = followTheLeaderCarts.OrderBy(a => System.Guid.NewGuid()).ToList();
    }

    public void MemorizedButton()
    {
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedFollowTheLeader, false);
    }

    public void ClosedCart()
    {
        for (int i = 0; i < cartCount; i++)
        {
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().spriteRenderer.DOFade(0, 0.2f);
            RandomID[i].gameObject.GetComponent<CartFollowTheLeader>().isContact = false;


        }
    }

}
