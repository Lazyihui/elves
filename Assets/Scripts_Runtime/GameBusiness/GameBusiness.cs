using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        // Role
        RoleDomain.Spawn(ctx, 1, new Vector2(-4, 0));

        // Land
        for (int i = 0; i < 10; i++) {
            // 先typeID 再id
            BookDomain.Spawn(ctx, 1, i);
        }

        // 地刺stab
        StabDomain.Spawn(ctx, 0, 0);
        StabDomain.Spawn(ctx, 0, 1);

        // ruler
        RulerDomain.Spawn(ctx, 1, 0);


    }

    public static void FixedTick(GameContext ctx, float dt) {


        // 加一个状态机 开始游戏才进行
        ModuleInput input = ctx.moduleInput;
        bool hasRole = ctx.roleRespository.TryGet(ctx.roleID, out RoleEntity role);
        if (!hasRole) {
            Debug.LogError("role ==null");
            return;
        }


        RoleController.Tick(ctx, role, input.moveAxis, dt);

        // CheckGround(role);
        // CheckGround(role);


        // role.Move(input.moveAxis, dt);

        // for role 就一个
        RoleDomain.OverLapStab(ctx, role);

        // ruler
        int rulerLen = ctx.rulerRepository.TakeAll(out RulerEntity[] rulers);


        for (int i = 0; i < rulerLen; i++) {
            RulerEntity ruler = rulers[i];
            // 这应该有错 多几个TM可能会有问题
            RulerDomain.RulerFade(ctx, ruler, role, dt);

            if (role.isRoleHadNoStanding) {

                // 根据id找到对应的ruler是否存在

                bool has = ctx.rulerRepository.TryGet(role.rulerID, out RulerEntity rulerEntity);
                if (has) {
                    Debug.Log("没找到对应的ruler" + role.rulerID);
                    // Debug.Log(dt);
                    role.fadeTimer -= dt;
                    Debug.Log(role.fadeTimer);
                    if (role.fadeTimer < 0) {

                        Debug.Log(";;;");

                        RulerDomain.Show(ctx, ruler);

                        role.fadeTimer = role.fade;

                        role.isRoleHadNoStanding = false;
                    }

                }

            }

        }


    }

    static void CheckGround(RoleEntity role) {
        RaycastHit2D[] hits = Physics2D.RaycastAll(role.transform.position, Vector2.down, 0.6f);
        Debug.DrawRay(role.transform.position, Vector2.down * 0.6f, Color.red);
        // 画射线
        if (hits != null) {
            for (int i = 0; i < hits.Length; i++) {
                var hit = hits[i];
                if (hit.collider.CompareTag("Ground")) {

                    role.SetGround(true);
                    break;
                }
            }
        }
    }
}
