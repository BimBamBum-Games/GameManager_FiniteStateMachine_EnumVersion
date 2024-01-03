using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bu attribute kullanilirken ilglili scriptlerin hepsi initialize esnasinda awake metodunda veya start metodunda olmalidirlar.
[DefaultExecutionOrder(-99)]
public class GameStateManager : MonoBehaviour {
    [Header("Test Serilestirmesi")]
    [SerializeField] GameState _gameState = GameState.MainMenu;
    
    //Singleton olarak kullanmak ve statik olarak dis kaynaktan cagirabilmek amaciyla kullaniliacak olan referans alanidir.
    public static GameStateManager Instance;

    //Event tabanli state machine patterni icin gerekli delegate alanidir.
    public event Action <GameState> OnGameStateChanged;

    protected void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(gameObject);
        }

        Debug.LogWarning("GameStateManager Created!");
    }

    protected void Start () {
        //Eger bu awake icinde cagrilirsa tum classlar awake olamadigindan uygun sekilde calismaz. Bu nedenle start esnasinda ilklendirme yapilir.
        ChangeGameState(_gameState);
    }

    public void ChangeGameState(GameState gameState) {
        //Bu metod diger tetikleyici class tarafindan cagrilacaktir. Bu class aslinda bir singleton ve statik olarak disaridan cagrilabildiginden kullanislidir.
        _gameState = gameState;
        if (gameState == GameState.MainMenu) {
            //Oyun baslangicinda

        }
        else if (gameState == GameState.NewGameMenu) {
            //Gorev basarildiginda

        }
        else if (gameState == GameState.NextLevelMenu) {
            //Sonraki goreve gecildiginde

        }
        else if (gameState == GameState.EndMenu) {
            //Yenilgiyle sonuclandiginda

        }
        else {
            //Diger durumlar

        }
        Debug.LogWarning("ChangeGameState Cagrildi! " + _gameState);
        OnGameStateChanged?.Invoke(gameState);
    }
}