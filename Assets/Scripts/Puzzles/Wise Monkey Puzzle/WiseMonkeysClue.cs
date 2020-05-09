using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiseMonkeysClue : MonoBehaviour
{
    [SerializeField] private WiseMonkeyPuzzle wiseMonkeyPuzzle = null;
    [SerializeField] private SpriteRenderer[] monkeyClues = null;

    public List<Sprite> monkeyOrder;

    /// <summary>
    /// 
    /// </summary>
    public void SetCorrectOrder()
    {
        List<Sprite> tempSprites = new List<Sprite>(wiseMonkeyPuzzle.monkeySprites);
        monkeyOrder = new List<Sprite>();

        for (int idx = 0; idx < wiseMonkeyPuzzle.monkeySprites.Count; idx++)
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
