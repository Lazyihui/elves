using System;
using UnityEngine;
public class Context {
    public AssetsContext assetsContext;

    public GameContext gameContext;

    public UIContext uiContext;

    public ModuleInput moduleInput;

    public GameFSMStatus status;
 
    public TemplateContext templateContext;


    public Context() {
        uiContext = new UIContext();
        assetsContext = new AssetsContext();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
        templateContext = new TemplateContext();

    }
    public void Inject(Canvas screenCanvas) {
        uiContext.Inject(screenCanvas, assetsContext);
        gameContext.Inject(assetsContext, moduleInput, templateContext);
    }
}

