using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class RoomSpriteSelector : MonoBehaviour
{
    public Sprite sT, sB, sL, sR,
                  sTB, sTL, sTR,
                  sBL, sBR,
                  sLR,
                  sTBL, sTBR, sTLR,
                  sBLR,sTBLR;

    public bool top, bottom, left, right;

    public int type; //we'll add types as we go such as what type of puzzle or if its an empty room

    public Color normal, starting;

        Color mainColor;
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        mainColor = normal;
        PickSprite();
        PickColor();
    }

    void PickSprite()
    {
        if(top)
        {
            if (bottom)
            {
                if(right)
                {
                    if (left){
                        rend.sprite = sTBLR;
                    }
                    else
                    {
                        rend.sprite = sTBR;
                    }
                }
                else if(left)
                {
                    rend.sprite = sTBL;
                }
                else
                {
                    rend.sprite = sTB;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = sTLR;
                    }
                    else
                    {
                        rend.sprite = sTR;
                    }
                }
                else if(left)
                {
                    rend.sprite = sTL;
                }
                else
                {
                    rend.sprite = sT;
                }
            }
            return;
        }
        if(bottom)
        {
            if (right)
            {
                if (left)
                {
                    rend.sprite = sBLR;
                }
                else
                {
                    rend.sprite = sBR;
                }
            }else if (left)
            {
                rend.sprite = sBL;
            }
            else
            {
                rend.sprite = sB;
            }

            return;
        }
        if(right)
        {
            if(left)
            {
                rend.sprite = sLR;
            }
            else
            {
                rend.sprite = sR;
            }
        }
        else
        {
            rend.sprite = sL;
        }
    }


    void PickColor()
    {
        if(type == 0)
        {
            mainColor = normal;
        }else if(type == 1)
        {
            mainColor = starting;
        }
        rend.color = mainColor;
    }
}
