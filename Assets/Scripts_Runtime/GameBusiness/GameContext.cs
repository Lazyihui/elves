using System;
using UnityEngine;

public class GameContext {


    public ModuleInput moduleInput;

    public RoleEntity roleEntity;



    public AssetsContext assetsContext;

    public int roleid;

    public GameContext() {
        moduleInput = new ModuleInput();
        roleid = -1;
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }
}