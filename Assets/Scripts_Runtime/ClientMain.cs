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
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.gameContext);
        };
    }

    float restDT = 0;
    void Update() {

        float dt = Time.deltaTime;
        // // === Phase : Input===
        ModuleInput input = ctx.moduleInput;
        input.ProcessMoveAxis();

        //=== Phase : Login===
        float fixedDT = Time.fixedDeltaTime; // 0.02
        restDT += dt;// 0.0083 (0.0000000001, 10)
        if (restDT >= fixedDT) {
            while (restDT >= fixedDT) {
                restDT -= fixedDT;
                FixedTick(fixedDT);
            }
        } else {
            FixedTick(restDT);
            restDT = 0;
        }


    }
    void FixedTick(float dt) {
        // === Phase:Logic===
        GameBusiness.FixedTick(ctx.gameContext, dt);
        // === phade: Simulate===
        Physics.Simulate(dt);
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
