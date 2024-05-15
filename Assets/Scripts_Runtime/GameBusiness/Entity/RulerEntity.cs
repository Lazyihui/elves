using System;
using UnityEngine;

public class RulerEntity : MonoBehaviour {

    public int typeID;

    public int id;
    // 种类
    // 是否是橡皮

    public float maintainterTimer;

    public float maintain;

    public float fadeTimer;
    public float fade;

    public bool isRoleStanding;

    public bool isRoleHadNoStanding;

    public RulerEntity() { }

    public void Ctor() { }

    public void TearDown() {
        Destroy(this.gameObject);
    }

    // 隐藏ruler
    public void Hide() {
        this.gameObject.SetActive(false);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }


}