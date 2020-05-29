using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiseMonkeysClue : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] monkeyClues = null;
    [SerializeField] private WiseMonkeys wiseMonkeys = null;

    // List of sprites used for the puzzle
    public List<Sprite> monkeySprites;
    public List<Sprite> monkeyOrder;

    public bool puzzleCompleted;

    private void Start()
    {
        puzzleCompleted = false;

        SetCorrectOrder();
    }

    public void SetCorrectOrder()
    {
        List<Sprite> tempSprites = new List<Sprite>(monkeySprites);
        monkeyOrder = new List<Sprite>();

        for (int idx = 0; idx < monkeySprites.Count; idx++)
        {
            int monkeyIdx = Random.Range(0, tempSprites.Count);
            monkeyOrder.Add(tempSprites[monkeyIdx]);
            tempSprites.RemoveAt(monkeyIdx);
        }

        SetWiseMonkeyClue();
    }

    public void SetWiseMonkeyClue()
    {
        for (int monClueIdx = 0; monClueIdx < monkeyOrder.Count; monClueIdx++)
        {
            monkeyClues[monClueIdx].sprite = monkeyOrder[monClueIdx];
        }
    }
}
