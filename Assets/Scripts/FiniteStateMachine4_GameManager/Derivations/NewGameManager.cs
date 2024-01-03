using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Execution orderin attribute ile atanmasi saglandi.
[DefaultExecutionOrder(-98)]
public class NewGameManager : StateConcrete {
    [SerializeField] Button _nextGameBtn;
    [SerializeField] GameObject _newGameGoGrp;
    private void Awake() {
        _nextGameBtn.onClick.AddListener(InExit);
        GameStateManager.Instance.OnGameStateChanged += InEnter;
    }

    private void OnDisable() {
        _nextGameBtn.onClick.RemoveAllListeners();
        GameStateManager.Instance.OnGameStateChanged -= InEnter;
    }

    public override void InExit() {
        //Ornegin bu button basarili olunan durumda belirir ve tikandiginda sonraki levele gecsin durumu tetiklenir.
        _newGameGoGrp.SetActive(false);
        GameStateManager.Instance.ChangeGameState(GameState.NextLevelMenu);
        Debug.LogWarning("Next Game Secildi!");
    }

    public override void InEnter(GameState gameState) {
        //Eger state NextLevelMenu ise NextLevelMenu panelini cagir.
        if (gameState == GameState.NewGameMenu) {
            _newGameGoGrp.SetActive(true);
        }
    }

}
