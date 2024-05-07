using System;
using UnityEngine;

public static class GameBusiness {

    public static void Enter(GameContext ctx) {
        // Role
        RoleDomain.Spawn(ctx, 1, new Vector2(-4, 0));

        // Land
        for (int i = 0; i < 10; i++) {
            // 先typeID 再id
            BookDomain.Spawn(ctx, 1, i);
        }

        // 地刺stab
        StabDomain.Spawn(ctx, 0, 0);
        StabDomain.Spawn(ctx, 0, 1);

        // ruler
        RulerDomain.Spawn(ctx, 1, 0);


    }

    static void OnCollisionStay2D(RoleEntity role, Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            role.SetGround(true);
        }
        if (other.gameObject.CompareTag("Ruler")) {
            // 可以在ruler上面站三秒 然后ruler消失
            role.SetGround(true);
            Debug.Log("Ruler");
        }
    }

    public static void FixedTick(GameContext ctx, float dt) {


        // 加一个状态机 开始游戏才进行
        ModuleInput input = ctx.moduleInput;
        bool hasRole = ctx.roleRespository.TryGet(ctx.roleID, out RoleEntity role);
        if (!hasRole) {
            Debug.LogError("role ==null");
            return;
        }


        RoleController.Tick(ctx, role, input.moveAxis, dt);

        // CheckGround(role);
        // CheckGround(role);


        // role.Move(input.moveAxis, dt);

        // for role 就一个
        RoleDomain.OverLapStab(ctx, role);

        // ruler
        int rulerLen = ctx.rulerRepository.TakeAll(out RulerEntity[] rulers);


        for (int i = 0; i < rulerLen; i++) {
            RulerEntity ruler = rulers[i];
            // 匿名函数


            role.OnCollisionStayHandle = (role, other) => {

                if (other.gameObject.CompareTag("Ground")) {
                    role.SetGround(true);
                }

                if (other.gameObject.CompareTag("Ruler")) {
                    role.SetGround(true);

                    ruler.maintainterTimer -= dt;
                    if (ruler.maintainterTimer < 0) {

                        RulerDomain.UnSpawn(ctx, ruler);
                        
                        ruler.maintainterTimer = ruler.maintain;

                    }

                }

            };
            //想写成bool

        }


    }

    static void CheckGround(RoleEntity role) {
        RaycastHit2D[] hits = Physics2D.RaycastAll(role.transform.position, Vector2.down, 0.6f);
        Debug.DrawRay(role.transform.position, Vector2.down * 0.6f, Color.red);
        // 画射线
        if (hits != null) {
            for (int i = 0; i < hits.Length; i++) {
                var hit = hits[i];
                if (hit.collider.CompareTag("Ground")) {

                    role.SetGround(true);
                    break;
                }
            }
        }
    }
}
