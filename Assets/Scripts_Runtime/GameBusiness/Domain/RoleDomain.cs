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
        role.moveSpeed = 2;
        role.Enter_Idle();
        ctx.roleRespository.Add(role);
        ctx.roleid = role.id;


        role.OnCollisionEnterHandle = OnCollisionEnter;


        return role;
    }

    static void OnCollisionEnter(RoleEntity role, Collision2D other) {
        Debug.Log("OnCollisionEnter");
        if (other.gameObject.CompareTag("Ground")) {
            role.SetGround(true);
        }
    }


}