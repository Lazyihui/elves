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

    // panel_Over
    public static void Panel_Over_Open(UIContext ctx) {
        Panel_Over panel = ctx.Panel_Over;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Over", out GameObject prefab);
            if (has == false) {
                Debug.LogError("Panel_Over==null");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_Over>();
            panel.Ctor();
            panel.OnStartClickHandle = () => {
                ctx.uIEvents.Over_RestartGame();
            };
            ctx.Panel_Over = panel;
        }
        panel.Show();
    }

    public static void Panel_Over_Close(UIContext ctx) {
        Panel_Over panel = ctx.Panel_Over;
        if (panel != null) {
            panel.close();
        }
    }

    // panel_HeartInfo
    public static void Panel_HeartInfo_Open(UIContext ctx, int hp) {
        Panel_HeartInfo panel = ctx.panel_HeartInfo;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_HeartInfo", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel==Null");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.screenCanvas.transform).GetComponent<Panel_HeartInfo>();
            panel.Ctor();
            ctx.panel_HeartInfo = panel;
        }
        panel.Init(hp);
        panel.Show();
    }

    public static void Panel_HeartInfo_Updata(UIContext ctx, int hp) {
        Panel_HeartInfo panel = ctx.panel_HeartInfo;
        if (panel != null) {
            panel.Init(hp);
        }
    }


    public static void Panel_HeartInfo_Close(UIContext ctx) {
        Panel_HeartInfo panel = ctx.panel_HeartInfo;
        if (panel != null) {
            panel.Close();
        }
    }


}