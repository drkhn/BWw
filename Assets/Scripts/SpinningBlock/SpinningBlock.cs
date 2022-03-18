using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using Enums;
public class SpinningBlock : MonoBehaviour
{
    [Header(" ~~~~~~~~~~~~~~ Spinning block ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject block;
    [SerializeField] Color cartColor;
    [SerializeField] Color cartDefaultColor;

    [Header("----------------------------------------------")]
    [SerializeField] List<GameObject> spinningCarts = new List<GameObject>();
    [SerializeField] List<int> spinningCartsID = new List<int>();
    [SerializeField] List<int> RandomID = new List<int>();
    List<int> randomList = new List<int>();

    [Header(" ~~~~~~~~~~~~~~ Game Settings ~~~~~~~~~~~~~~ ")]
    [SerializeField] public SpinningBlockSO spinningBlockSO;
    [SerializeField] float rotateDuration = .5f;
    private void OnEnable()
    {
        EventManager.GameSpiningBlockMemorized += MemorizedButton;
    }
    private void OnDisable()
    {
        EventManager.GameSpiningBlockMemorized -= MemorizedButton;

    }
    private void Start()
    {
        AlignBlock();
    }

    private void Update()
    {
        TimeControl();
    }

    void TimeControl() // Kaç saniye kaldý bulmak
    {
        spinningBlockSO.TimeFunc();
    }

    void AlignBlock()
    {
        RandomUniq();
        for (int i = 0; i < spinningBlockSO.cartCount; i++)
        {
            spinningCarts[RandomID[i]].gameObject.GetComponent<CartSpinnigBlock>().isColor = true; //
           // Debug.Log("Random Uniq :" + RandomID[i]);
            spinningCarts[RandomID[i]].gameObject.GetComponent<SpriteRenderer>().color = cartColor;
        }

    }

    void RandomUniq()
    {
        RandomID = spinningCartsID.OrderBy(a => System.Guid.NewGuid()).ToList();
    }


    public void MemorizedButton()
    {
        RotateBlock();
        ColorCart();
        EventManager.GamePlayMemorizedButton(MemorizedRoot.MemorizedSpinningBlcok, false);
    }

    void RotateBlock()
    {
        int rnd = Random.Range(0, 4);

        if (rnd == 0)
        {
            block.transform.DORotate(new Vector2(0, 180), rotateDuration);
            Debug.LogWarning("X");
        }
        else if (rnd == 1)
        {
            Debug.LogWarning("-X");
            block.transform.DORotate(new Vector2(0, 180), rotateDuration);
        }

        else if (rnd == 2)
        {
            Debug.LogWarning("Y");
            block.transform.DORotate(new Vector2(180, 0), rotateDuration);
        }
        else if (rnd == 3)
        {
            Debug.LogWarning("-Y");
            block.transform.DORotate(new Vector2(-180, 0), rotateDuration);
        }

        //----------------------------------------------------------------------------------------------------------

    }

    void ColorCart()
    {
        for (int i = 0; i < spinningCarts.Count; i++)
        {
            spinningCarts[i].gameObject.GetComponent<SpriteRenderer>().color = cartDefaultColor;
            spinningCarts[i].gameObject.GetComponent<CartSpinnigBlock>().isContact = true;
        }
    }
}
