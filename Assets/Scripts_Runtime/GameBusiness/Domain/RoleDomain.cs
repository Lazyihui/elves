using System;
using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int ID, Vector2 pos) {
        bool has = ctx.assetsContext.TryGetEntity("Entity_Role", out GameObject prefab);
        if (!has) {
            Debug.LogError("Entity_Role ==null");
            return null;
        }

        RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
        role.Ctor();
        role.id = ID;//先这样写
        role.transform.position = pos;
        role.moveSpeed = 3;
        role.isDie = false;
        role.Enter_Idle();
        ctx.roleRespository.Add(role);
        ctx.roleID = role.id;


        // role.OnCollisionEnterHandle = OnCollisionEnter;
        // role.OnCollisionStayHandle = OnCollisionStay;


        return role;
    }

    static void OnCollisionEnter(RoleEntity role, Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            role.SetGround(true);
        }
        if (other.gameObject.CompareTag("Ruler")) {
            // 可以在ruler上面站三秒 然后ruler消失
            role.SetGround(true);
            Debug.Log("Ruler");
        }
    }

    static void OnCollisionStay(RoleEntity role, Collision2D other) {

        if (other.gameObject.CompareTag("Ruler")) {
            role.SetGround(true);
            Debug.Log("Ruler");
        }
    }

    public static void OverLapStab(GameContext ctx, RoleEntity role) {
        StabEntity target = ctx.stabRepository.Find((stab) => {
            float dirSqr = Vector2.SqrMagnitude(stab.transform.position - role.transform.position);
            if (dirSqr < 1.5f) {
                role.isDie = true;
                return true;
            } else {
                return false;
            }
        });

    }

    // public static void OverLapCircle(GameContext ctx, Vector2 pos, float radius) {
    //     Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);
    //     foreach (var collider in colliders) {
    //         if (collider.gameObject.CompareTag("Role")) {
    //             RoleEntity role = collider.gameObject.GetComponent<RoleEntity>();
    //             if (role.id != ctx.roleID) {
    //                 role.OnOverlapCircle(ctx.roleID);
    //             }
    //         }
    //     }
    // }


}