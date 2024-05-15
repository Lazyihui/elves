using System;
using UnityEngine;

public class Panel_Win : MonoBehaviour {


    public void Ctor() {
    }
    public void Show() {
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }

}