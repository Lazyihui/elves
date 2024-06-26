using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        // Role
        RoleEntity role = RoleDomain.Spawn(ctx, 1, new Vector2(-8.5f, 0));

        // UI
        UIApp.Panel_HeartInfo_Open(ctx.uiContext, role.hp);

        // Book
        for (int i = 0; i < 12; i++) {
            // 先typeID 再id
            BookDomain.Spawn(ctx, 1, i);
        }

        // 地刺stab
        for (int i = 0; i < 8; i++) {
            StabDomain.Spawn(ctx, 0, i);
        }

        // ruler
        for (int i = 0; i < 2; i++) {
            RulerDomain.Spawn(ctx, 0, i);
        }

        // land
        for (int i = 0; i < 10; i++) {
            LandDomain.Spawn(ctx, 0, i);
        }

        // mst
        MstEntity mst = MstDomain.Spawn(ctx, 0);

        // gold
        GoldDomain.Spawn(ctx, 0);
        GoldDomain.Spawn(ctx, 1);


    }


    public static void Exit(GameContext ctx) {
        // role
        int roleLen = ctx.roleRespository.TakeAll(out RoleEntity[] roles);
        for (int i = 0; i < roleLen; i++) {
            RoleEntity role = roles[i];
            RoleDomain.Unspawn(ctx, role);
        }
        // book
        int bookLen = ctx.bookRepository.TakeAll(out BookEntity[] books);
        for (int i = 0; i < bookLen; i++) {
            BookEntity book = books[i];
            BookDomain.Unspawn(ctx, book);
        }
        // stab
        int stabLen = ctx.stabRepository.TakeAll(out StabEntity[] stabs);
        for (int i = 0; i < stabLen; i++) {
            StabEntity stab = stabs[i];
            StabDomain.Unspawn(ctx, stab);
        }
        // ruler
        int rulerLen = ctx.rulerRepository.TakeAll(out RulerEntity[] rulers);
        for (int i = 0; i < rulerLen; i++) {
            RulerEntity ruler = rulers[i];
            RulerDomain.UnSpawn(ctx, ruler);
        }
        // land
        int landLen = ctx.landRepository.TakeAll(out LandEntity[] lands);
        for (int i = 0; i < landLen; i++) {
            LandEntity land = lands[i];
            LandDomain.Unspawn(ctx, land);
        }
        // mst
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);
        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            MstDomain.Unspawn(ctx, mst);
        }
        // gold
        int goldLen = ctx.goldRepository.TakeAll(out GoldEntity[] golds);
        for (int i = 0; i < goldLen; i++) {
            GoldEntity gold = golds[i];
            GoldDomain.Unspawn(ctx, gold);
        }

    }
    // 多次
    public static void FixedTick(GameContext ctx, float dt) {


        // 加一个状态机 开始游戏才进行
        ModuleInput input = ctx.moduleInput;
        bool hasRole = ctx.roleRespository.TryGet(ctx.roleID, out RoleEntity role);
        if (!hasRole) {
            Debug.LogError("role ==null");
            return;
        }


        RoleController.Tick(ctx, role, input.moveAxis, dt);

        // role.Move(input.moveAxis, dt);

        // for role 就一个
        RoleDomain.OverLapStab(ctx, role);
        RoleDomain.OverLapMst(ctx, role);
        RoleDomain.OverLapGold(ctx, role);
        RoleDomain.OverLapLand(ctx, role);

        // ruler
        int rulerLen = ctx.rulerRepository.TakeAll(out RulerEntity[] rulers);

        for (int i = 0; i < rulerLen; i++) {
            RulerEntity ruler = rulers[i];
            // 这应该有错 多几个TM可能会有问题
            RulerDomain.RulerFade(ctx, ruler, role, dt);
        }

        // for 所有的mst
        int mstLen = ctx.mstRepository.TakeAll(out MstEntity[] msts);
        for (int i = 0; i < mstLen; i++) {
            MstEntity mst = msts[i];
            MstDomain.Move(mst, -1.2f, -3.2f, dt);
        }

    }
    // 每针一次
    public static void PreTick(GameContext ctx, float dt) {

    }

    public static void LateTick(GameContext ctx, float dt) {
        bool hasRole = ctx.roleRespository.TryGet(ctx.roleID, out RoleEntity role);
        if (!hasRole) {
            // Debug.LogError("role ==null");
            return;
        }
        UIApp.Panel_HeartInfo_Updata(ctx.uiContext, role.hp);
    }

    static void CheckGround(RoleEntity role) {
        RaycastHit2D[] hits = Physics2D.RaycastAll(role.transform.position, Vector2.down, 0.6f);
        Debug.DrawRay(role.transform.position, Vector2.down * 0.6f, Color.red);
        // 画射线
        if (hits != null) {
            for (int i = 0; i < hits.Length; i++) {
                var hit = hits[i];
                if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Ruler")) {
                    role.SetGround(true);
                    break;
                }
            }
        }
    }
}
