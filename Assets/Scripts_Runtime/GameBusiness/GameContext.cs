using System;
using UnityEngine;

public class GameContext {


    public ModuleInput moduleInput;

    public RoleEntity roleEntity;

    public AssetsContext assetsContext;

    public RoleRespository roleRespository;

    public BookRepository bookRepository;

    public StabRepository stabRepository;

    public RulerRepository rulerRepository;

    public LandRepository landRepository;
    public TemplateContext templateContext;

    public UIContext uiContext;
    public int roleID;

    public int bookID;
    public int stabID;

    public int rulerID;

    public int landID;

    public GameFSMStatus status;

    public GameContext() {
        roleRespository = new RoleRespository();
        bookRepository = new BookRepository();
        stabRepository = new StabRepository();
        rulerRepository = new RulerRepository();
        landRepository = new LandRepository();
        roleID = 0;
        bookID = 0;
        stabID = 0;
        rulerID = 0;
        landID = 0;
    }

    public void Inject(AssetsContext assetsContext, ModuleInput moduleInput, TemplateContext templateContext, UIContext uIContext,GameFSMStatus status) {
        this.assetsContext = assetsContext;
        this.moduleInput = moduleInput;
        this.templateContext = templateContext;
        this.uiContext = uIContext;
        this.status = status;

    }
}