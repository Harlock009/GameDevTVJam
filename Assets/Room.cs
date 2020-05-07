using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
   public Vector2 roomPos;
    public int roomType;
    public bool _OpenN, _OpenE, OpenS, _OpenW; //If doors are open to the north south east or west

    public Room(Vector2 pos, int type)
    {
        roomPos = pos;
        roomType = type;
    }

}
