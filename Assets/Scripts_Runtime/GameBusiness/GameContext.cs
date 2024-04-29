using System;
using UnityEngine;

public class GameContext {


    public ModuleInput moduleInput;

    public RoleEntity roleEntity;

    public AssetsContext assetsContext;

    public RoleRespository roleRespository;

    public BookRepository bookRepository;

    public int roleID;

    public int bookID;


    public GameContext() {
        roleRespository = new RoleRespository();
        bookRepository = new BookRepository();
        roleID = 0;
        bookID = 0;
    }

    public void Inject(AssetsContext assetsContext,ModuleInput moduleInput) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
    }
}