using System;
using UnityEngine;
using UnityEngine.UI;
public static class UIApp {


    public static void Panel_Login_Open(UIContext ctx) {
        Panel_Login panel = ctx.Panel_Login;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Login", out GameObject prefab);
            if (has == false) {
                Debug.LogError("panel_Login ==null");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Login>();
            panel.Ctor();
            panel.OnStartClickHandle = () => {
                ctx.uIEvents.Login_StartGame();
            };
            ctx.Panel_Login = panel;

        }
        panel.Show();
    }

    public static void Panel_Login_Close(UIContext ctx) {
        Panel_Login panel = ctx.Panel_Login;
        if (panel != null) {
            panel.Close();
        }
    }
}