using System;
using UnityEngine;
public static class StabDomain {

    public static StabEntity Spawn(GameContext ctx, int typeID, int id) {
        bool has = ctx.templateContext.stabs.TryGetValue(id, out StabTM tm);

        if (!has) {
            Debug.LogError("没找到typeID对应的模板" + id);
        }

        bool h = ctx.assetsContext.TryGetEntity("Entity_Stab", out GameObject prefab);

        if (!h) {
            Debug.LogError("Entity_Stab ==null");
            return null;
        }
        StabEntity stab = GameObject.Instantiate(prefab).GetComponent<StabEntity>();

        stab.Ctor();
        stab.id = ctx.stabID++;
        stab.typeID = tm.typeID;
        stab.transform.position = tm.pos;
        ctx.stabRepository.Add(stab);
        return stab;
    }

    public static void Unspawn(GameContext ctx, StabEntity stab) {
        ctx.stabRepository.Remove(stab);
        stab.TearDown();
    }

}