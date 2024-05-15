using System;
using UnityEngine;

public class BookEntity : MonoBehaviour {

    public int typeID;

    public int id;

    public BookEntity() {

    }

    public void Ctor() { }
    public void TearDown() {
        GameObject.Destroy(this.gameObject);
     }


}