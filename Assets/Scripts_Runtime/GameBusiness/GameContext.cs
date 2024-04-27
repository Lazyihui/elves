using System;
using UnityEngine;

public class GameContext {


    public ModuleInput moduleInput;

    public RoleEntity roleEntity;

    public AssetsContext assetsContext;

    public ModuleInput input;

    public RoleRespository roleRespository;

    public int roleid;


    public GameContext() {
        moduleInput = new ModuleInput();
        roleRespository = new RoleRespository();
        roleid = 0;
    }

    public void Inject(AssetsContext assetsContext,ModuleInput input) {
        this.assetsContext = assetsContext;
        this.input = input;
    }
}