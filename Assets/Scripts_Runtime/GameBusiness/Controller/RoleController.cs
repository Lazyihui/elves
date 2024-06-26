using System;
using UnityEngine;

public static class RoleController {


    public static void Tick(GameContext ctx, RoleEntity role, Vector2 moveAxis, float dt) {
        RoleFSMStatus status = role.fsmStatus;
        if (status == RoleFSMStatus.Idle) {

            Idle_Status(ctx, role, moveAxis, dt);

        } else if (status == RoleFSMStatus.Die) {

            Die_State(role, dt);

        } else if (status == RoleFSMStatus.Run) {

            // Run_Status(role, moveAxis, dt);

        } else {
            Debug.LogError("未知状态");
        }
        Any_State(role, dt);
    }

    static void Any_State(RoleEntity role, float dt) {
        //  任何状态都是会执行的逻辑
        // Role.CheckSpike();
        // 技能cd/buff时间
        float x = role.transform.position.x;
        float y = role.transform.position.y;
        // if (x > 10) {
        //     if (role.fsmStatus != RoleFSMStatus.Die) {
        //         role.fsmStatus = RoleFSMStatus.Die;
        //     }
        // }
        if (y < -6) {
            if (role.fsmStatus != RoleFSMStatus.Die) {
                role.Enter_Die(0.8f);
            }
        }
        if (role.isDie) {
            if (role.fsmStatus != RoleFSMStatus.Die) {
                role.Enter_Die(0.8f);
            }
        }
    }

    static void Idle_Status(GameContext ctx, RoleEntity role, Vector2 moveAxis, float dt) {
        ModuleInput moduleInput = ctx.moduleInput;
        if (role.idle_isEntering) {
            role.idle_isEntering = false;
            role.animator.Play("idle");
        }


        role.Move(moveAxis, dt);
        if (moveAxis != Vector2.zero) {
            role.animator.Play("walk");
        } else {
            role.animator.Play("idle");
        }

        role.Jump(moduleInput.isJump);

    }

    static void Run_Status(RoleEntity role, Vector2 moveAxis, float dt) {
        if (role.run_isEntering) {
            role.run_isEntering = false;
            Debug.Log("Run");
        }

        role.Move(moveAxis, dt);
        if (moveAxis == Vector2.zero) {
            role.Enter_Idle();
        }
    }

    static void Die_State(RoleEntity role, float dt) {

        if (role.isDie) {
            role.isDie = false;
        }

        if (role.die_isEntering) {
            role.die_isEntering = false;
            role.animator.Play("Die");
        }

        role.die_maintainTime -= dt;
        if (role.die_maintainTime <= 0) {
            Debug.Log("Die");
            role.transform.position = new Vector2(-8.5f, 0);
            // 扣血
            role.hp -= 1;
            role.Enter_Idle();
        }
    }
}