using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        RoleDomain.Spawn(ctx, 1, new Vector2(0, 0));
    }

    public static void Fixdt(float dt) {

    }

}
