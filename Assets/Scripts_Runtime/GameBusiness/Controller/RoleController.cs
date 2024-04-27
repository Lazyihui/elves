using System;
using UnityEngine;

public static class RoleController {


    public static void Tick(RoleEntity role, Vector2 moveAxis, float dt) {
        RoleFSMStatus status = role.fsmStatus;
        if (status == RoleFSMStatus.Idle) {

            Idle_Status(role, moveAxis, dt);
        } else if (status == RoleFSMStatus.Die) {
            Die_State(role, dt);
        } else {
            Debug.Log("Err");
        }
        Any_State(role, dt);
    }

    static void Any_State(RoleEntity role, float dt) {
        //  任何状态都是会执行的逻辑
        // Role.CheckSpike();
        // 技能cd/buff时间
        float x = role.transform.position.x;
        if (x > 10) {
            if (role.fsmStatus != RoleFSMStatus.Die) {
                role.fsmStatus = RoleFSMStatus.Die;
            }
        }
    }

    static void Idle_Status(RoleEntity role, Vector2 moveAxis, float dt) {
        if (role.idle_isEntering) {
            role.idle_isEntering = false;
            role.animator.Play("Animation_Role1_Idle");
            Debug.Log("Idle");

        }


        role.Move(moveAxis, dt);
    }

    static void Die_State(RoleEntity role, float dt) {
        if (role.die_isEntering) {
            role.die_isEntering = false;
            role.animator.Play("Animation_Role1_Die");
            Debug.Log("Die");
        }

        role.die_maintainTime -= dt;
        if (role.die_maintainTime <= 0) {
            role.transform.position = Vector3.zero;
            role.Enter_Idle();
        }
    }
}