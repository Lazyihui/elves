using System;
using UnityEngine;

public static class RoleDomain {

    public static RoleEntity Spawn(GameContext ctx, int typeID, Vector2 pos) {
        bool has = ctx.assetsContext.TryGetEntity("Entity_Role", out GameObject prefab);
        if (!has) {
            Debug.LogError("Entity_Role ==null");
            return null;
        }

        RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
        role.Ctor();
        return role;
    }

}