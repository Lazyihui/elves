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
        ruler.fade = tm.fade;
        ruler.fadeTimer = tm.fadeTimer;
        ruler.transform.position = tm.pos;
        ctx.rulerRepository.Add(ruler);
        return ruler;
    }

    public static void UnSpawn(GameContext ctx, RulerEntity ruler) {

        ctx.rulerRepository.Remove(ruler);
        ruler.TearDown();
    }

    public static void Hide(GameContext ctx, RulerEntity ruler) {
        ruler.Hide();
    }

    public static void Show(GameContext ctx, RulerEntity ruler) {
        ruler.Show();
    }

    public static void RulerFade(GameContext ctx, RulerEntity ruler, RoleEntity role, float dt) {


        if (ruler.isRoleStanding) {
            ruler.maintainterTimer -= dt;

            if (ruler.maintainterTimer < 0) {

                RulerDomain.Hide(ctx, ruler);
                ruler.maintainterTimer = ruler.maintain;

                role.rulerID = ruler.id;
                role.rulerTypeID = ruler.typeID;
            }

        }

        

    }

}