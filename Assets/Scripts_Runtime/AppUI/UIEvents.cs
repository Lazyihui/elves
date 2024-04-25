using System;

public class UIEvents {
    public Action Login_StartGameHandle;
    public void Login_StartGame() {
        if (Login_StartGameHandle != null) {
            Login_StartGameHandle.Invoke();
        }
    }

}