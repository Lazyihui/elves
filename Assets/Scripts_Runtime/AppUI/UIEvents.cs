using System;

public class UIEvents {
    public Action Login_StartGameHandle;
    public void Login_StartGame() {
        if (Login_StartGameHandle != null) {
            Login_StartGameHandle.Invoke();
        }
    }

    public Action Over_RestartGameHandle;

    public void Over_RestartGame() {
        if (Over_RestartGameHandle != null) {
            Over_RestartGameHandle.Invoke();
        }
    }


}