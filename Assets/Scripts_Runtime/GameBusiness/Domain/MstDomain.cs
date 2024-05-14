using System;
using UnityEngine;

public static class MstDomain {

    public static MstEntity Spawn(GameContext ctx, int id) {
        bool has = ctx.templateContext.msts.TryGetValue(id, out MstTM tm);

        if (!has) {
            Debug.LogError("没有找到对应模版" + id);
        }
        ctx.assetsContext.TryGetEntity("Entity_Mst", out GameObject prefab);
        MstEntity mst = GameObject.Instantiate(prefab).GetComponent<MstEntity>();
        mst.Ctor();
        mst.Init(tm.sprite);
        mst.typeID = tm.typeID;
        mst.moveSpeed = tm.moveSpeed;
        mst.id = ctx.mstID++;
        mst.isMoveRight = true;
        mst.transform.position = tm.pos;
        ctx.mstRepository.Add(mst);
        return mst;
    }

    public static void Move(MstEntity mst, float rightBoundary, float leftBoundary, float dt) {
        mst.Move(rightBoundary, leftBoundary, dt);
    }
}