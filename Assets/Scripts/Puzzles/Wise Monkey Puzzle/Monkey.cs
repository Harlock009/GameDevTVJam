using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Interactable
{
    [SerializeField] private WiseMonkeyPuzzle wiseMonkeyPuzzle = null;
    [SerializeField] private WiseMonkeys wiseMonkeys = null;

    public SpriteRenderer monkeySprite;
    public int CurrentMonkey;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    public override void Interact(Player player)
    {
        if (!wiseMonkeyPuzzle.puzzleCompleted)
        {
            if (CurrentMonkey == wiseMonkeyPuzzle.monkeySprites.Count - 1)
                CurrentMonkey = -1;

            monkeySprite.sprite = wiseMonkeyPuzzle.monkeySprites[++CurrentMonkey];
            wiseMonkeys.CheckOrder();
        }
    }
}
