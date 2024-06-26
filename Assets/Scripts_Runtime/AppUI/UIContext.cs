using UnityEngine;
using UnityEngine.UI;

public class UIContext {

    public Panel_Login Panel_Login;

    public Panel_HeartInfo  panel_HeartInfo;

    public Panel_Over Panel_Over;

    public Panel_Win panel_Win;

    public Canvas screenCanvas;

    public AssetsContext assetsContext;

    public UIEvents uIEvents;

    public UIContext() {
        uIEvents = new UIEvents();
    }

    public void Inject(Canvas scrernCanvans, AssetsContext assetsContext) {
        this.screenCanvas = scrernCanvans;
        this.assetsContext = assetsContext;
    }
}