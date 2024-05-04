using System;
using UnityEngine;

public static class RulerDomain {

    public static RulerEntity Spawn(GameContext ctx, int typeID, int id) {
        bool has = ctx.templateContext.rulers.TryGetValue(id, out RulerTM tm);

        if (!has) {
            Debug.LogError("没找到typeID对应的模板" + id);
        }
        ctx.assetsContext.TryGetEntity("Entity_Ruler", out GameObject prefab);
        RulerEntity ruler = GameObject.Instantiate(prefab).GetComponent<RulerEntity>();

        ruler.Ctor();
        ruler.id = ctx.rulerID++;
        ruler.typeID = tm.typeID;
        ruler.transform.position = tm.pos;
        ctx.rulerRepository.Add(ruler);
        return ruler;
    }
}