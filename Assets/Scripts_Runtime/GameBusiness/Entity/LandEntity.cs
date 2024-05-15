using System;
using UnityEngine;

public class LandEntity : MonoBehaviour {

    public int typeID;

    public int id;

    public LandEntity() {

    }

    public void Ctor() { }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
     }
}