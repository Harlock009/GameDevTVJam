using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Item class.
/// </summary>
/// 
[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public GameObject itemUI;
    public AudioClip pickUpSFX;
    public AudioClip dropSFX;
}
