using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Execution orderin attribute ile atanmasi saglandi.
[DefaultExecutionOrder(-98)]
public class MainMenu : StateConcrete {

    [SerializeField] Button _newGameButton;
    [SerializeField] GameObject _mainMenuGoGrp;
    public void Awake() {
        Debug.LogWarning("MainMenu Awake");

        //Listener olarak eklenir.
        GameStateManager.Instance.OnGameStateChanged += InEnter;

        //Listenerlari baslarken dinleyici olarak atar.
        _newGameButton.onClick.AddListener(InExit);
    }

    public void OnDisable() {
        //Listener kaldirilir.
        GameStateManager.Instance.OnGameStateChanged -= InEnter;

        //Memory sizintilarini engellemek amaciyla serbest birakir.
        _newGameButton.onClick.RemoveAllListeners();
    }

    public override void InExit() {
        //New game buttonuna tiklandiginda gerceklesecek olaydir. Bu ayrica ChangeGameState ile yonlendirmeyi saglayacaktir.
        Debug.LogWarning("New Game Secildi!");
        _mainMenuGoGrp.SetActive(false);
        GameStateManager.Instance.ChangeGameState(GameState.NewGameMenu);
    }

    //Aslinda Yonlendirme Noktasi Olarak Bu Metod Kullanilacaktir.
    public override void InEnter(GameState gameState) {
        //Bu aslinda standart finite state machinedeki OnExit, OnEnter, OnUpdate, OnFixedUpdate ve OnDestroy metodlari gibi gorev ustlenmektedir.
        if (gameState == GameState.MainMenu) {
            //Bu classa bagli panel game objesini aktif et.
            _mainMenuGoGrp.SetActive(true);
        }
        Debug.LogWarning("Main menu ekrani getiriliyor!");
    }


}
