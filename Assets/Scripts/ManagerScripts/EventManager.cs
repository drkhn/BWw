using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;



    public class EventManager
    {

    public delegate void onGamePlayUIRoot(UIRoot value, bool val);
    public static event onGamePlayUIRoot GameUIRoot;

    public static void GamePlayUIRoot(UIRoot value, bool val)
    {
        GameUIRoot?.Invoke(value,val);
    }

    public delegate void onGameSelectGame(GameRoot value, bool val);
    public static event onGameSelectGame GameSelectGame;

    public static void GamePlaySelectGame(GameRoot value, bool val)
    {
        GameSelectGame?.Invoke(value, val);
    }

    public delegate void onGameResetConfig(ResetConfigEnum value);
    public static event onGameResetConfig GameResetConfig;

    public static void GamePlayResetConfig(ResetConfigEnum value)
    {
        GameResetConfig?.Invoke(value);
    }

    public delegate void onGameStartButton();
    public static event onGameStartButton GameStartButton;

    public static void GamePlayStartButton()
    {
        GameStartButton?.Invoke();
    }

    public delegate void onGameHomeButton();
    public static event onGameHomeButton GameHomeButton;

    public static void GamePlayHomeButton()
    {
        GameHomeButton?.Invoke();
    }

    public delegate void onGameMemorizedButton(MemorizedRoot value,bool val);
    public static event onGameMemorizedButton GameMemorizedButton;

    public static void GamePlayMemorizedButton(MemorizedRoot value,bool val)
    {
        GameMemorizedButton?.Invoke(value,val);
    }

    public delegate void onGameEndGame(EndGameRoot value, bool val);
    public static event onGameEndGame GameEndGame;

    public static void GamePlayEndGame(EndGameRoot value, bool val)
    {
        GameEndGame?.Invoke(value, val);
    }
    public delegate void onGameEndGameValue(EndGameValue endGameValue, float scoreValue, float sliderValue1, float sliderValue2);
    public static event onGameEndGameValue GameEndGameValue;

    public static void GamePlayEndGameValue(EndGameValue endGameValue, float scoreValue, float sliderValue1, float sliderValue2)
    {
        GameEndGameValue?.Invoke(endGameValue, scoreValue,sliderValue1,sliderValue2);
    }

    //Brain

    public delegate void onGameAddBrain(BrainEnum brainEnum , float value);
    public static event onGameAddBrain GameAddBrain;

    public static void GamePlayAddBrain(BrainEnum brainEnum, float value)
    {
        GameAddBrain?.Invoke(brainEnum, value);
    }

    // Camera
    public delegate void onGameCamera(CameraRoot value);
    public static event onGameCamera GameCamera;

    public static void GamePlayCamera(CameraRoot value)
    {
        GameCamera?.Invoke(value);
    }

    // Score

    public delegate void onGameScore(ScoreEnum scoreEnum);
    public static event onGameScore GameScore;

    public static void GamePlayScore(ScoreEnum scoreEnum)
    {
        GameScore?.Invoke(scoreEnum);
    }
    // Level Boost

    public delegate void onGameLevelBoost(LevelBoostEnum levelBoostEnum);
    public static event onGameLevelBoost GameLevelBoost;

    public static void GamePlayLevelBoost(LevelBoostEnum levelBoostEnum)
    {
        GameLevelBoost?.Invoke(levelBoostEnum);
    }

    //Tap The Color

    public delegate void onGameTapTheColorMemorized();
    public static event onGameTapTheColorMemorized GameTapTheColorMemorized;

    public static void GamePLayTapTheColorMemorized()
    {
        GameTapTheColorMemorized?.Invoke();
    }

    public delegate void onGameTapTheColorClosedCart();
    public static event onGameTapTheColorClosedCart GameTapTheColorClosedCart;

    public static void GamePlayTapTheColorClosedCart()
    {
        GameTapTheColorClosedCart?.Invoke();
    }


    // Spinning Block

    public delegate void onGameSpiningBlockMemorized();
    public static event onGameSpiningBlockMemorized GameSpiningBlockMemorized;

    public static void GamePlaySpiningBlockMemorized()
    {
        GameSpiningBlockMemorized?.Invoke();
    }

    // Follow The Leader

    public delegate void onGameFollowTheLeaderMemorized();
    public static event onGameFollowTheLeaderMemorized GameFollowTheLeaderMemorized;

    public static void GamePlayFollowTheLeaderMemorized()
    {
        GameFollowTheLeaderMemorized?.Invoke();
    }

    public delegate void onGameFollowTheClosedCart();
    public static event onGameFollowTheClosedCart GameFollowTheClosedCart;

    public static void GamePlayFollowTheClosedCart()
    {
        GameFollowTheClosedCart?.Invoke();
    }



    // Simpli City

    public delegate void onGameSimpliCityCalculationText(string value);
    public static event onGameSimpliCityCalculationText GameSimpliCityCalculationText;

    public static void GamePlaySimpliCityCalculationText(string value)
    {
        GameSimpliCityCalculationText?.Invoke(value);
    }

    // Concentration

    public delegate void onGameConcentrationMemorized();
    public static event onGameConcentrationMemorized GameConcentrationMemorized;

    public static void GamePlayConcentrationMemorized()
    {
        GameConcentrationMemorized?.Invoke();
    }

}



