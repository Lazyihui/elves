using System;
using UnityEngine;

public class StabEntity : MonoBehaviour {

    public int typeID;

    public int id;

    public StabEntity() { }

    public void Ctor() { }

    public void TearDown() { 
        GameObject.Destroy(this.gameObject);
    }

}