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
        ruler.maintain = tm.maintain;
        ruler.maintainterTimer = tm.maintainterTimer;
        ruler.transform.position = tm.pos;
        ctx.rulerRepository.Add(ruler);
        return ruler;
    }

    public static void UnSpawn(GameContext ctx, RulerEntity ruler) {

        ctx.rulerRepository.Remove(ruler);
        ruler.TearDown();
    }

    public static void RulerFade(GameContext ctx, RulerEntity ruler, float dt) {

        if (ruler.isRoleStanding) {
            Debug.Log(ruler.isRoleStanding);
            ruler.maintainterTimer -= dt;

            if (ruler.maintainterTimer < 0) {
                RulerDomain.UnSpawn(ctx, ruler);
                ruler.maintainterTimer = ruler.maintain;
            }
        }

        if (!ruler.isRoleStanding) {
            RulerDomain.Spawn(ctx, 0, 0);

        }
    }

}