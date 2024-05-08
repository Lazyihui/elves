using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Land", menuName = "Template/Land")]


public class LandTM : ScriptableObject {

    [Header("Land")]

    public int typeID;

    public int id;


    public Vector2 pos;


}