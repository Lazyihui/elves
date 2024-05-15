using System;
using UnityEngine;

public static class GoldDomain {

    public static GoldEntity Spawn(GameContext ctx, int id) {

        bool has = ctx.templateContext.golds.TryGetValue(id, out GoldTM tm);
        if (!has) {
            Debug.LogError("没有对应的模板");
            return null;
        }
        ctx.assetsContext.TryGetEntity("Entity_Gold", out GameObject prefab);
        GoldEntity gold = GameObject.Instantiate(prefab).GetComponent<GoldEntity>();

        gold.Ctor();
        gold.id = ctx.goldID++;
        gold.typeID = tm.typeID;
        gold.transform.position = tm.pos;
        gold.isWin = tm.isWin;
        gold.ishp = tm.ishp;
        gold.Init(tm.sprite);
        ctx.goldRepository.Add(gold);
        return gold;

    }
}