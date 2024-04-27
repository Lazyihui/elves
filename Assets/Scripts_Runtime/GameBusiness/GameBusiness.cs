using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        RoleDomain.Spawn(ctx, 1, new Vector2(0, 0));

    }

    public static void FixedTick(GameContext ctx, float dt) {
        // 加一个状态机 开始游戏才进行
        ModuleInput input = ctx.moduleInput;
        bool hasRole = ctx.roleRespository.TryGet(ctx.roleid, out RoleEntity role);
        if (!hasRole) {
            // Debug.LogError("role ==null");
            return;
        }
        role.Move(input.moveAxis, dt);

    }

}
