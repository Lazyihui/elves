using System;
using UnityEngine;

public class GameContext {


    public ModuleInput moduleInput;

    public RoleEntity roleEntity;

    public AssetsContext assetsContext;

    public RoleRespository roleRespository;

    public int roleid;


    public GameContext() {
        roleRespository = new RoleRespository();
        roleid = 0;
    }

    public void Inject(AssetsContext assetsContext,ModuleInput moduleInput) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
    }
}