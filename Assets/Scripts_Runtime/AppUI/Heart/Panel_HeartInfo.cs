using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_HeartInfo : MonoBehaviour {

    [SerializeField] Image elePrefab;

    [SerializeField] Transform HeartGroup;

    List<Image> elements;

    public void Ctor() { 

        elements = new List<Image>();
    }

    public void Init(int hp ){
        
    }

}

