using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Book", menuName = "Template/Book")]


public class BookTM : ScriptableObject {

    [Header("Book")]

    public int typeID;

    public int id;


    public Vector2 pos;


}