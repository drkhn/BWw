using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "GamesConfig", menuName = "GamesConfig/SpinningBlock", order = 2)]
public class SpinningBlockSO : ScriptableObject
{
    public float time = 30;
    public float baseTime;
    [Header("----------------------------------------------")]
    public int score = 20;
    public int baseScore;
    [Header("----------------------------------------------")]
    public int gameCount = 0;
    [Header("----------------------------------------------")]
    [Range(1, 9)]
    public int cartCount = 3;

    [Header("----------------------------------------------")]
    public int[] scoreArray;
    bool isZero = false;




    private void OnEnable()
    {
        EventManager.GameLevelBoost += LevelBost;
        EventManager.GameScore += SetScore;
        EventManager.GameResetConfig += ResetConfig;
    }

    private void OnDisable()
    {
        EventManager.GameLevelBoost -= LevelBost;
        EventManager.GameScore -= SetScore;
        EventManager.GameResetConfig -= ResetConfig;
    }

    public void TimeFunc()
    {
        time -= Time.deltaTime;
        EndOfTime();
    }

    void EndOfTime()
    {
        if (!isZero)
        {
            if (time <= 0)
            {
                Debug.Log("End Of Time");
                GameManager.Instance.SipinningBlockEndPanelValue();
                EventManager.GamePlayEndGame(EndGameRoot.EndGameRootSpinningBlcok, true);
                gameCount = 0;
                isZero = true;
            }
        }
      
    }

    public void LevelBost(LevelBoostEnum levelBoostEnum)
    {
        if (levelBoostEnum == LevelBoostEnum.LevelBoostSpinningBlock)
        {
            gameCount++;
        }

    }

    public void SetScore(ScoreEnum scoreEnum)
    {
        if (scoreEnum == ScoreEnum.ScoreSpinningBlcok)
        {
            score = scoreArray[gameCount];
            Debug.Log("Score : " + score);
        }
    }

    public void ResetConfig(ResetConfigEnum resetConfigEnum)
    {
        if (resetConfigEnum == ResetConfigEnum.ResetConfigSpinningBlcok)
        {
            time = baseTime;
            score = baseScore;
            gameCount = 0;
            isZero = false;
        }

    }
}
