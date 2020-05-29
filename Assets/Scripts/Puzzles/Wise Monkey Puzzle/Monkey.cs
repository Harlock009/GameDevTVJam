using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Interactable
{
    [SerializeField] private WiseMonkeysClue wiseMonkeyClue = null;
    [SerializeField] private WiseMonkeys wiseMonkeys = null;

    public SpriteRenderer monkeySprite;
    public int CurrentMonkey;

    private void Start()
    {
        wiseMonkeyClue = FindObjectOfType<WiseMonkeysClue>();
    }

    public override void Interact(Player player)
    {
        if (!wiseMonkeyClue.puzzleCompleted)
        {
            if (CurrentMonkey == wiseMonkeyClue.monkeySprites.Count - 1)
                CurrentMonkey = -1;

            monkeySprite.sprite = wiseMonkeyClue.monkeySprites[++CurrentMonkey];
            wiseMonkeys.CheckOrder();
        }
    }
}
