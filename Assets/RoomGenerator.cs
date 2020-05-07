﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    Vector2 levelSize = new Vector2(10, 10);

    Room[,] rooms;
    List<Vector2> TakenPos = new List<Vector2>();

    int GridSizeX, GridSizeY, numRooms = 20;

    public GameObject roomObj;
    // Start is called before the first frame update
    void Start()
    {
        if(numRooms >= (levelSize.x * 2) * (levelSize.y * 2))
        {
            numRooms = Mathf.RoundToInt((levelSize.x * 2) * (levelSize.y * 2));

        }

        GridSizeX = Mathf.RoundToInt(levelSize.x);
        GridSizeY = Mathf.RoundToInt(levelSize.y);
        CreateRooms();
        SetRoomDoors();
        DrawMap();
    }
    void SetRoomDoors()
    {
        for(int x = 0;x < ((GridSizeX * 2)); x++)
        {
            for(int y = 0; y < ((GridSizeY * 2)); y++)
            {
                if(rooms[x,y] == null)
                {
                    continue;
                }

                Vector2 gridPos = new Vector2(x, y);
                if(y -1 < 0)
                {
                    rooms[x, y].OpenS = false;
                }
                else
                {
                    rooms[x, y].OpenS = (rooms[x, y - 1] != null);
                }
                if (y + 1 >= GridSizeY*2)
                {
                    rooms[x, y]._OpenN = false;
                }
                else
                {
                    rooms[x, y]._OpenN = (rooms[x, y + 1] != null);
                }

                if (x - 1 < 0)
                {
                    rooms[x, y]._OpenW = false;
                }
                else
                {
                    rooms[x, y]._OpenW = (rooms[x- 1, y ] != null);
                }
                if (x + 1 >= GridSizeX * 2)
                {
                    rooms[x, y]._OpenE = false;
                }
                else
                {
                    rooms[x, y]._OpenE = (rooms[x+ 1, y ] != null);
                }
            }
        }
    }

    void CreateRooms()
    {
        //set up
        rooms = new Room[GridSizeX * 2, GridSizeY * 2];
        rooms[GridSizeX, GridSizeY] = new Room(Vector2.zero, 1);
        TakenPos.Insert(0, Vector2.zero);
        Vector2 checkpos = Vector2.zero;
        //Random Chance offset checks
        float RandComp = 0.2f, randCompBegin = 0.2f, randCompEnd = 0.01f;
        //Add Rooms
        for (int i = 0; i < numRooms; i++ )
        {
            float RandPercent = ((float)i) / (((float)numRooms - 1));
            //store Position
            checkpos = NewRoomPosition();
            //Test Position
            if(NumNeighbors(checkpos,TakenPos) > 1 && UnityEngine.Random.value > RandComp)
            {
                int iteration = 0;
                do
                {
                    checkpos = SelectiveNewPosition();
                    iteration++;
                }
                while (NumNeighbors(checkpos, TakenPos) > 1 && iteration < 100);
             

            }
            //Finalize room positions
            rooms[(int)checkpos.x + GridSizeX, (int)checkpos.y + GridSizeY] = new Room(checkpos, 0);
            TakenPos.Insert(0, checkpos);
        }




    }
    Vector2 NewRoomPosition()
    {
        int x = 0, y = 0;
        Vector2 chkPos = Vector2.zero;
        do
        {
            int index = Mathf.RoundToInt(UnityEngine.Random.value * (TakenPos.Count - 1));
            x = (int)TakenPos[index].x;
            y = (int)TakenPos[index].y;
            bool Updown = (UnityEngine.Random.value < 0.5f);
            bool positive = (UnityEngine.Random.value < 0.5f);
            if (Updown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            chkPos = new Vector2(x, y);
        } while (TakenPos.Contains(chkPos) || x >= GridSizeX || x < -GridSizeX || y >= GridSizeY || y < -GridSizeY);

        return chkPos;
    }
    int NumNeighbors(Vector2 chk, List<Vector2> taken)
    {
        int ret = 0;
        if(taken.Contains(chk+Vector2.right))
        {
            ret++;
        }
        if (taken.Contains(chk + Vector2.up))
        {
            ret++;
        }
        if (taken.Contains(chk + Vector2.down))
        {
            ret++;
        }
        if (taken.Contains(chk + Vector2.left))
        {
            ret++;
        }
        return ret;
    }

    Vector2 SelectiveNewPosition()
    {
        int index = 0, incremental = 0;
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do
        {
            incremental = 0;

            do
            {
                index = Mathf.RoundToInt(UnityEngine.Random.value * (TakenPos.Count - 1));
                incremental++;
            } while (NumNeighbors(TakenPos[index], TakenPos) > 1 && incremental < 100);
            x = (int)TakenPos[index].x;
            y = (int)TakenPos[index].y;
            bool Updown = (UnityEngine.Random.value < 0.5f);
            bool positive = (UnityEngine.Random.value < 0.5f);
            if (Updown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        } while (TakenPos.Contains(checkingPos) || x >= GridSizeX || x < -GridSizeX || y >= GridSizeY || y < -GridSizeY);

        return checkingPos;


    }

    void DrawMap()
    {
        foreach (Room room in rooms)
        {
            if (room == null)
            {
                continue;
            }
            Vector2 drawpos = room.roomPos;
            drawpos.x *= 10;
            drawpos.y *= 10;
            RoomSpriteSelector mapper = UnityEngine.Object.Instantiate(roomObj, drawpos, Quaternion.identity).GetComponent<RoomSpriteSelector>();
            mapper.type = room.roomType;
            mapper.top = room._OpenN;
            mapper.bottom = room.OpenS;
            mapper.right = room._OpenE;
            mapper.left = room._OpenW;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
