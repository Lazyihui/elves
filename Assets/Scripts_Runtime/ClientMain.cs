using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMain : MonoBehaviour {

    Context ctx;
    bool isTearDown;

    void Awake() {

        // === Instantiation ====
        ctx = new Context();
        ctx.status = GameFSMStatus.Login;
        isTearDown = false;
        Canvas screenCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // Camera mainCamera = gameObject.GetComponentInChildren<Camera>();

        // ==== Injection ====
        ctx.Inject(screenCanvas);


        // ==== Load ====
        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfras.Load(ctx.templateContext);
        // ==== Binding ====
        Binding();
        // ==== Init ====

        // ==== Enter ====
        UIApp.Panel_Login_Open(ctx.uiContext);
    }

    void Binding() {

        var uIEvents = ctx.uiContext.uIEvents;
        // 开始游戏
        uIEvents.Login_StartGameHandle = () => {
            UIApp.Panel_Login_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.gameContext);
            ctx.status = GameFSMStatus.Game;
        };
        // 重新开始游戏
        uIEvents.Over_RestartGameHandle = () => {
            
            UIApp.Panel_Over_Close(ctx.uiContext);
            GameBusiness.Enter(ctx.gameContext);
            ctx.status = GameFSMStatus.Game;
        };
    }

    float restDT = 0;
    void Update() {

        float dt = Time.deltaTime;
        GameFSMStatus status = ctx.status;
        // // === Phase : Input===
        ModuleInput input = ctx.moduleInput;

        // 在登入页的时候
        if (status == GameFSMStatus.Login) {


            // 在开始游戏的时候
        } else if (status == GameFSMStatus.Game) {

            GameBusiness.PreTick(ctx.gameContext, dt);


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

            GameBusiness.LateTick(ctx.gameContext, dt);




        } else if (status == GameFSMStatus.Pause) {
            // 在暂停游戏的时候

        } else if (status == GameFSMStatus.Over) {
            // 游戏结束
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
        TemplateInfras.Unload(ctx.templateContext);
    }
}
