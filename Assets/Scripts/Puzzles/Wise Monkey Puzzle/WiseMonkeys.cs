using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiseMonkeys : MonoBehaviour
{
    [SerializeField] private WiseMonkeyPuzzle wiseMonkeyPuzzle = null;
    [SerializeField] private Monkey[] monkeys = null;

    /// <summary>
    /// 
    /// </summary>
    public void RandomizeMonkeys()
    {
        if (wiseMonkeyPuzzle == null) return;

        List<Sprite> tempSprites = new List<Sprite>(wiseMonkeyPuzzle.monkeySprites);

        for (int idx = 0; idx < wiseMonkeyPuzzle.monkeySprites.Count; idx++)
        {
            int monkeyIdx = Random.Range(0, tempSprites.Count);
            monkeys[idx].monkeySprite.sprite = tempSprites[monkeyIdx];
            tempSprites.RemoveAt(monkeyIdx);
        }

        for (int i = 0; i < wiseMonkeyPuzzle.monkeySprites.Count; i++)
        {
            for (int j = 0; j < monkeys.Length; j++)
            {
                if (wiseMonkeyPuzzle.monkeySprites[i] == monkeys[j].monkeySprite.sprite)
                    monkeys[j].CurrentMonkey = i;
            }
        }

        // To guarantee that the monkeys do not start in the correct positon,
        // swap the first monkey with the second if it matches the correct monkey
        if (monkeys[0].monkeySprite.sprite == wiseMonkeyPuzzle.wiseMonkeyClue.monkeyOrder[0])
        {
            Sprite temp = monkeys[0].monkeySprite.sprite;
            int tempCurrentMonkey = monkeys[0].CurrentMonkey;

            monkeys[0].monkeySprite.sprite = monkeys[1].monkeySprite.sprite;
            monkeys[0].CurrentMonkey = monkeys[1].CurrentMonkey;
            monkeys[1].monkeySprite.sprite = temp;
            monkeys[1].CurrentMonkey = tempCurrentMonkey;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void CheckOrder()
    {
        bool match = true;

        for (int idx = 0; idx < monkeys.Length; idx++)
        {
            if (monkeys[idx].monkeySprite.sprite != wiseMonkeyPuzzle.wiseMonkeyClue.monkeyOrder[idx])
            {
                match = false;
                break;
            }
        }

        if (match)
        {
            wiseMonkeyPuzzle.puzzleCompleted = true;
        }
    }
}
