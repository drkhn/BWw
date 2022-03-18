using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Enums;
public class TapTheColor : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Indicators ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject indicator;
    [SerializeField] Transform indicatorsPos;

    [Header("----------------------------------------------")]
    [SerializeField] float indicatorHorizontal;
    [SerializeField] float indicatorVertical;

    [Header(" ---------------------------------------------- ")]
    [SerializeField] List<GameObject> indicatorlist = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Carts ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject cart;
    [SerializeField] Transform cartPos;

    [Header("----------------------------------------------")]
    [SerializeField] float cartHorizontal;
    [SerializeField] float cartVertical;
    [Header("----------------------------------------------")]
    [SerializeField] Color cartDefaultColor;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> cartList = new List<GameObject>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]

    [SerializeField] public TapTheColorSO tapTheColorSO;
    int cartCount;
    [Header("----------------------------------------------")]
    [SerializeField] float moveDuration = .5f;
    [SerializeField] float colorDuration = .5f;
    [Header("----------------------------------------------")]

    [SerializeField] Color[] colors;

    [SerializeField] List<int> cartID = new List<int>();

    [SerializeField]List<int> indicatorID = new List<int>();


    private void OnEnable()
    {
        EventManager.GameTapTheColorMemorized += MemorizedButton;
        EventManager.GameTapTheColorClosedCart += ClosedCart;
    }

    private void OnDisable()
    {
        EventManager.GameTapTheColorMemorized -= MemorizedButton;
        EventManager.GameTapTheColorClosedCart -= ClosedCart;
    }

    private void Start()
    {
        GameControl();
        SetStartMath();
        AlignCart();
    }

    void SetStartMath()
    {
        cartCount = tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount] * tapTheColorSO.StackVerticalCount[tapTheColorSO.gameCount];
    }

    void GameControl()
    {
        if (tapTheColorSO.gameCount == 3)
        {
            cartPos.position = new Vector2(.75f, .3f);
            indicatorsPos.position = new Vector2(-.75f, 3f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 4)
        {
            cartPos.position = new Vector2(0.75f, .3f);
            indicatorsPos.position = new Vector2(-.75f, 3f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 5)
        {
            cartPos.position = new Vector2(.75f, .3f);
            indicatorsPos.position = new Vector2(-.75f, 3f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 6)
        {
            cartPos.position = new Vector2(1, .3f);
            indicatorsPos.position = new Vector2(.5f, 3f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 7)
        {
            cartPos.position = new Vector2(1, .3f);
            indicatorsPos.position = new Vector2(.5f, 3f);
        }
        if (tapTheColorSO.gameCount == 8)
        {
            indicatorsPos.position = new Vector2(1.25f, 3f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 9)
        {
            indicatorsPos.position = new Vector2(-1.25f, 3f);
            Debug.Log("Cart Pos Girdi");
        }

        if (tapTheColorSO.gameCount == 11)
        {
            cartPos.position = new Vector2(0f, 1.1f);
            indicatorsPos.position = new Vector2(-2.25f, 3.4f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 12)
        {
            cartPos.position = new Vector2(0f, 1.1f);
            indicatorsPos.position = new Vector2(2.25f, 3.4f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 13)
        {
            cartPos.position = new Vector2(0f, 1.1f);
            indicatorsPos.position = new Vector2(2.25f, 3.4f);
            Debug.Log("Cart Pos Girdi");
        }
        if (tapTheColorSO.gameCount == 14)
        {
            cartPos.position = new Vector2(0f, 1.1f);
            indicatorsPos.position = new Vector2(2.25f, 3.4f);
            Debug.Log("Cart Pos Girdi");
        }
    }

    private void Update()
    {
        TimeControl();
    }

    void TimeControl() // Kaç saniye kaldý bulmak
    {
        tapTheColorSO.TimeFunc();
    }


    void AlignIndicators()
    {
        for (int i = 0; i < cartCount; i++)
        {
            GameObject indicatorGO = Instantiate(indicator, new Vector2(indicatorsPos.transform.position.x +(i /1.8f), indicatorsPos.transform.position.y), Quaternion.identity);
            indicatorGO.transform.SetParent(indicatorsPos);
            indicatorlist.Add(indicatorGO);
        }
        //for (int j = 0; j < indicatorlist.Count; j++)
        //{
        //    Vector2 targetPos = Vector2.zero;
           
        //    targetPos.x = (j % tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount]) - (tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount] / 2);
        //    targetPos.y = (j / tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount]) % (tapTheColorSO.StackVerticalCount[tapTheColorSO.gameCount]);

        //    targetPos.x *= indicatorHorizontal;
        //    targetPos.y *= -indicatorVertical;

        //    indicatorlist[j].transform.DOLocalMove(targetPos,moveDuration);
            
        //}
    }

    void AlignCart()
    {
        for (int i = 0; i < cartCount; i++)
        {
            GameObject cartGO = Instantiate(cart, new Vector2(cartPos.transform.position.x, cartPos.transform.position.y), Quaternion.identity);
            cartGO.transform.SetParent(cartPos);
            cartList.Add(cartGO);
        }
        for (int j = 0; j < cartList.Count; j++)
        {
            Vector2 targetPos = Vector2.zero;

            targetPos.x = (j % tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount]) - (tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount] / 2);
            targetPos.y = (j / tapTheColorSO.StackHorizontalCount[tapTheColorSO.gameCount]) % (tapTheColorSO.StackVerticalCount[tapTheColorSO.gameCount]);

            targetPos.x *= cartHorizontal;
            targetPos.y *= -cartVertical;

            cartList[j].transform.DOLocalMove(targetPos, moveDuration);

        }

        CartColor();
    }

    void IndicatorColor()
    {
        for (int i = 0; i < indicatorlist.Count; i++)
        {
            indicatorlist[i].gameObject.GetComponent<SpriteRenderer>().DOColor(colors[indicatorID[i]],colorDuration);
        }
    }

    void CartColor()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
            int rndColor = Random.Range(0, colors.Length);
            cartID.Add(rndColor);
            cartList[i].gameObject.GetComponent<SpriteRenderer>().DOColor(colors[rndColor], colorDuration);
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().cartID = rndColor;

            cartList[i].gameObject.GetComponent<CartsTapTheColor>().cartColor = colors[rndColor];
        }
    }

    void CartDefaultColor()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
           
            cartList[i].gameObject.GetComponent<SpriteRenderer>().DOColor(cartDefaultColor, colorDuration);
        }
    }

    void RandomUniq()
    {
        indicatorID = cartID.OrderBy(a => System.Guid.NewGuid()).ToList();
    }

    public void MemorizedButton()
    {
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedTapTheColor,false);
        AlignIndicators();
        RandomUniq();
        IndicatorColor();
        CartDefaultColor();
        MatchCartID();
        CartContact( true);

    }
    void CartContact( bool value) // Kartlarý Dokunabilir yapabiliyorum
    {
        for(int i = 0; i < cartList.Count; i++)
        {
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().isContact = value;
        }
    }
      

    void MatchCartID()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
            cartList[i].gameObject.GetComponent<CartsTapTheColor>().indicatorIDList = indicatorID;
        }
    }


    public void ClosedCart()
    {
        for (int i = 0; i < cartList.Count; i++)
        {
            cartList[i].gameObject.GetComponent<SpriteRenderer>().DOFade(0,0.2f);
        }
        CartContact(false);


    }


  
}


