using System;
using UnityEngine;

public static class LandDomain {

    public static LandEntity Spawn(GameContext ctx, int typeID, int id) {

        bool has = ctx.templateContext.lands.TryGetValue(id, out LandTM tm);
        if (!has) {
            Debug.LogError("没找到typeID对应的模板" + id);
        }
        ctx.assetsContext.TryGetEntity("Entity_Land", out GameObject prefab);
        LandEntity land = GameObject.Instantiate(prefab).GetComponent<LandEntity>();
        land.Ctor();
        land.id = ctx.landID++;
        land.typeID = tm.typeID;
        land.transform.position = tm.pos;
        land.isEraser = tm.isEraser;
        ctx.landRepository.Add(land);
        return land;
    }

    public static void Unspawn(GameContext ctx, LandEntity land) {
        ctx.landRepository.Remove(land);
        land.TearDown();
    }

    public static void EraserFall(GameContext ctx, LandEntity land) {

        if (land.isEraser) {
            land.rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

}