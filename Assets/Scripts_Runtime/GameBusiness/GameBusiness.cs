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
    // static void CheckGround(RoleEntity role) {
    //     RaycastHit[] hits = Physics.RaycastAll(role.transform.position + Vector3.up, Vector3.down, 5.05f);
    //     // 画射线
    //     Debug.DrawRay(role.transform.position + Vector3.up, Vector3.down*5.05f, Color.red);
    //     if (hits != null) {
    //         for (int i = 0; i < hits.Length; i++) {
    //             var hit = hits[i];
    //             if (hit.collider.CompareTag("Ground")) {
    //                 Debug.Log("Ground");
    //                 role.SetGround(true);
    //                 break;
    //             }
    //         }
    //     }
    // }

}
