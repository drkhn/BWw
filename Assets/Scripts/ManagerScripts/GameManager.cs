using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header(" ~~~~~~~~~~~~~~ Tap The Color ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject tapTheColor;

    [Header(" ~~~~~~~~~~~~~~ Spinning Block ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject spinningBlock;

    [Header(" ~~~~~~~~~~~~~~ Follow The Leader ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject followTheLeader;

    [Header(" ~~~~~~~~~~~~~~ Follow The Leader ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject simpliCity;

    [Header(" ~~~~~~~~~~~~~~ Concentration ~~~~~~~~~~~~~~ ")]
    [SerializeField] GameObject concentration;

    [SerializeField] GameObject prefab;
    [SerializeField] BrainSO brainSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void StartButton()
    {
        EventManager.GamePlayStartButton();
    }

    public void HomeButton()
    {
        EventManager.GamePlayHomeButton();
        if (prefab != null)
        {
            Destroy(prefab);
        }
    }

    void GameSelect(GameObject go)
    {
        prefab = Instantiate(go);
    }

    public void RestartGame(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        Destroy(prefab);
      
        Vibration.Vibrate(35);
        //EventManager.GamePlayCamera(CameraRoot.FailCamera);
        StartCoroutine(RestartGameCoroutine(enums, gamePrefab));
    }

    IEnumerator RestartGameCoroutine(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        yield return new WaitForSeconds(.2f);
        
        EventManager.GamePlayMemorizedButton(enums,true);
        if (gamePrefab == GamePrefab.PrefabTapTheColor)
        {
            prefab = Instantiate(tapTheColor);
        }
        else if (gamePrefab == GamePrefab.PrefabSpinningBlcok)
        {
            prefab = Instantiate(spinningBlock);
        }
        else if (gamePrefab == GamePrefab.PrefabFollowTheLeader)
        {
            prefab = Instantiate(followTheLeader);
        }
        else if (gamePrefab == GamePrefab.PrefabSimpliCity)
        {
            prefab = Instantiate(simpliCity);
        }
        else if (gamePrefab == GamePrefab.PrefabConcentration)
        {
            prefab = Instantiate(concentration);
        }
    }

    public void SuccessGame(MemorizedRoot enums, GamePrefab gamePrefab)

    {
        Destroy(prefab);
        StartCoroutine(SuccessGameCrouitine(enums,gamePrefab));
        EventManager.GamePlayCamera(CameraRoot.SuccessCamera);
        Debug.Log("SuccessGame Cagrýldý");

    }

    IEnumerator SuccessGameCrouitine(MemorizedRoot enums, GamePrefab gamePrefab)
    {
        yield return new WaitForSeconds(.2f);
       
        EventManager.GamePlayMemorizedButton(enums,true);
        if (gamePrefab == GamePrefab.PrefabTapTheColor)
        {
            prefab = Instantiate(tapTheColor);
        }
        else if (gamePrefab == GamePrefab.PrefabSpinningBlcok)
        {
            prefab = Instantiate(spinningBlock);
        }
        else if (gamePrefab == GamePrefab.PrefabFollowTheLeader)
        {
            prefab = Instantiate(followTheLeader);
        }
        else if (gamePrefab == GamePrefab.PrefabSimpliCity)
        {
            prefab = Instantiate(simpliCity);
        }
        else if (gamePrefab == GamePrefab.PrefabConcentration)
        {
            prefab = Instantiate(concentration);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void EndPanelButton()
    {
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, false);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, true);
        EventManager.GamePlayHomeButton();
        if (prefab != null)
        {
            Destroy(prefab);
        }
    }

    //Tap The Color
    public void OpenTapTheColor()
    {
        EventManager.GamePlayResetConfig(ResetConfigEnum.ResetConfigTapTheColor);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(tapTheColor);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.TapTheColor, true);
    }

    public void TapTheColorMemorized()
    {
        EventManager.GamePLayTapTheColorMemorized();
    }

    public void TapTheColorEndPanelButton()
    {
        EventManager.GamePlaySelectGame(GameRoot.TapTheColor, false);
        EventManager.GamePlayEndGame(EndGameRoot.EndGameTapTheColor, false);
        EndPanelButton();
    }

    public void TapTheColorEndPanelValue()
    {
        var so = tapTheColor.GetComponent<TapTheColor>().tapTheColorSO;
        EventManager.GamePlayAddBrain(BrainEnum.Memory, so.score);
        EventManager.GamePlayEndGameValue(EndGameValue.EndGameValueTapTheColor,so.score,brainSO.memoryAverage,brainSO.speedAverage);
    }


    // Spinning Block

    public void OpenSpinningBlock()
    {
        EventManager.GamePlayResetConfig(ResetConfigEnum.ResetConfigSpinningBlcok);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(spinningBlock);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.SpinningBlcok, true);

    }

    public void SpinningBlockMemorized()
    {
        EventManager.GamePlaySpiningBlockMemorized();
    }

    public void SpinningBlockEndPanelButton()
    {

        EventManager.GamePlaySelectGame(GameRoot.SpinningBlcok, false);
        EventManager.GamePlayEndGame(EndGameRoot.EndGameRootSpinningBlcok, false);
        EndPanelButton();
    }

    public void SipinningBlockEndPanelValue()
    {
        var so = spinningBlock.GetComponent<SpinningBlock>().spinningBlockSO;
        EventManager.GamePlayAddBrain(BrainEnum.Speed, so.score);
        EventManager.GamePlayEndGameValue(EndGameValue.EndGameValueSpinningBlcok, so.score, brainSO.speedAverage, brainSO.decisionAverage);
    }

    // Follow The Leader

    public void OpenFollowTheLeader()
    {
        EventManager.GamePlayResetConfig(ResetConfigEnum.ResetConfigFollowTheLeader);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(followTheLeader);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.FollowTheLeader, true);
    }

    public void FollowTheLeaderMemorized()
    {
        EventManager.GamePlayFollowTheLeaderMemorized();
    }

    public void FollowTheLeaderEndPanelButton()
    {
        EventManager.GamePlaySelectGame(GameRoot.FollowTheLeader, false);
        EventManager.GamePlayEndGame(EndGameRoot.EndGameRootFollowTheLeader, false);
        EndPanelButton();
    }

    public void FollowTheLeaderEndPanelValue()
    {
        var so = followTheLeader.GetComponent<FollowTheLeader>().followTheLeaderSO;
        EventManager.GamePlayAddBrain(BrainEnum.Decision, so.score);
        EventManager.GamePlayEndGameValue(EndGameValue.EndGameValueFollowTheLeader, so.score, brainSO.decisionAverage, brainSO.speedAverage);
    }

    //SimplyCity

    public void OpenSimplyCity()
    {
        EventManager.GamePlayResetConfig(ResetConfigEnum.ResetConfigSimpliCity);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(simpliCity);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.SimpliCity, true);
    }

    public void SimpliCityEndPanelButton()
    {
        EventManager.GamePlaySelectGame(GameRoot.SimpliCity, false);
        EventManager.GamePlayEndGame(EndGameRoot.EndGameRootSimpliCity, false);
        EndPanelButton();
    }

    public void SimpliCityEndPanelValue()
    {
        var so = simpliCity.GetComponent<SimpliCity>().simpliCitySO;
        EventManager.GamePlayAddBrain(BrainEnum.Calculation, so.score);
        EventManager.GamePlayEndGameValue(EndGameValue.EndGameValueSimpliCity, so.score, brainSO.calculataionAverage, brainSO.speedAverage);
    }


    // Concentration

    public void OpenConcentration()
    {
        EventManager.GamePlayResetConfig(ResetConfigEnum.ResetConfigConcentration);
        EventManager.GamePlayUIRoot(UIRoot.MainPanel, false);
        GameSelect(concentration);
        EventManager.GamePlayUIRoot(UIRoot.GamePanel, true);
        EventManager.GamePlaySelectGame(GameRoot.Concentration, true);

    }

    public void ConcentrationMemorized()
    {
        EventManager.GamePlayConcentrationMemorized();
    }

    public void ConcentrationEndPanelButton()
    {

        EventManager.GamePlaySelectGame(GameRoot.Concentration, false);
        EventManager.GamePlayEndGame(EndGameRoot.EndGameRootConcentration, false);
        EndPanelButton();
    }

    public void ConcentrationEndPanelValue()
    {
        var so = concentration.GetComponent<Concentration>().concentrationSO;
        EventManager.GamePlayAddBrain(BrainEnum.Speed, so.score);
        EventManager.GamePlayEndGameValue(EndGameValue.EndGameValueConcentration, so.score, brainSO.speedAverage, brainSO.decisionAverage);
    }




}
