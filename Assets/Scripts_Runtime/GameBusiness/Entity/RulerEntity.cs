using System;
using UnityEngine;

public class RulerEntity : MonoBehaviour {

    public int typeID;

    public int id;
    // 种类
    // 是否是橡皮

    public float maintainterTimer;

    public float maintain;

    public RulerEntity() { }

    public void Ctor() { }

    public void TearDown() {
        Destroy(this.gameObject);
    }

}