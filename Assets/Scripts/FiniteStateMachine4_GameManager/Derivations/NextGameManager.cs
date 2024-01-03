using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Execution orderin attribute ile atanmasi saglandi.
[DefaultExecutionOrder(-98)]
public class NextGameManager : StateConcrete {
    [SerializeField] Button _endGameBtn;
    [SerializeField] GameObject _nextGameGoGrp;
    private void Awake() {
        _endGameBtn.onClick.AddListener(InExit);
        GameStateManager.Instance.OnGameStateChanged += InEnter;
    }

    private void OnDisable() {
        _endGameBtn.onClick.RemoveAllListeners();
        GameStateManager.Instance.OnGameStateChanged -= InEnter;
    }

    public override void InExit() {
        //Ornegin bu button basarili olunan durumda belirir ve tikandiginda sonraki levele gecsin durumu tetiklenir.
        _nextGameGoGrp.SetActive(false);
        GameStateManager.Instance.ChangeGameState(GameState.MainMenu);
        Debug.LogWarning("To MainMenu");
    }

    public override void InEnter(GameState gameState) {
        //Eger state NextLevelMenu ise NextLevelMenu panelini cagir.
        if (gameState == GameState.NextLevelMenu) {
            _nextGameGoGrp.SetActive(true);
        }
    }

}
