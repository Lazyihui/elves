using System;
using UnityEngine;
public class Context {
    public AssetsContext assetsContext;

    public UIContext uiContext;

    public Context() {
        uiContext = new UIContext();
        assetsContext = new AssetsContext();
    }
    public void Inject(Canvas screenCanvas) {
        uiContext.Inject(screenCanvas, assetsContext);
    }
}

