using UnityEngine;

//Contract State sinif tanimi yapilir.
public abstract class StateBody : MonoBehaviour {
    public virtual void InAwake() { }
    public virtual void InEnable() { }
    public virtual void InStart() { }
    public virtual void InUpdate() { }
    public virtual void InFixedUpdate() { }
    public virtual void InDisable() { }
    public virtual void InDestroy() { }

    //Zorunlu olarak yerlestirilmesi gecisliligi zorunlu hale getirmeyi amaclar. Biri input biri output durumudur.
    public abstract void InExit();
    public abstract void InEnter(GameState gameState);
}

public enum GameState {
    MainMenu,
    NewGameMenu,
    NextLevelMenu,
    EndMenu
}