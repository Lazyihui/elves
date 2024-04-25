using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {

    Context ctx;
    bool isTearDown;
    void Awake() {


        // === Instantiation ====
        ctx = new Context();
        isTearDown = false;
        Canvas screenCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // Camera mainCamera = gameObject.GetComponentInChildren<Camera>();

        // ==== Injection ====
        ctx.Inject(screenCanvas);


        // ==== Load ====
        ModuleAssets.Load(ctx.assetsContext);
        // ==== Binding ====
        Binding();
        // ==== Init ====

        // ==== Enter ====
        UIApp.Panel_Login_Open(ctx.uiContext);
    }

    void Binding() {

        var uIEvents = ctx.uiContext.uIEvents;

        uIEvents.Login_StartGameHandle = () => {
            Debug.Log("开始游戏");
        };
    }

    // Update is called once per frame
    void Update() {

    }


    void OnApplicationQuit() {
        TearDown();
    }
    void OnDestroy() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        ModuleAssets.Unload(ctx.assetsContext);
    }
}
