using System;
using System.Collections.Generic;
using UnityEngine;

public class WiseMonkeys : MonoBehaviour
{
    [SerializeField] private WiseMonkeysClue wiseMonkeyClue = null;
    [SerializeField] private Monkey[] monkeys = null;

    public static event Action OnWiseMonkeyCompleted;

    private void Start()
    {
        wiseMonkeyClue = FindObjectOfType<WiseMonkeysClue>();
        RandomizeMonkeys();
    }

    public void RandomizeMonkeys()
    {
        if (wiseMonkeyClue == null) return;

        List<Sprite> tempSprites = new List<Sprite>(wiseMonkeyClue.monkeySprites);

        for (int idx = 0; idx < wiseMonkeyClue.monkeySprites.Count; idx++)
        {
            int monkeyIdx = UnityEngine.Random.Range(0, tempSprites.Count);
            monkeys[idx].monkeySprite.sprite = tempSprites[monkeyIdx];
            tempSprites.RemoveAt(monkeyIdx);
        }

        for (int i = 0; i < wiseMonkeyClue.monkeySprites.Count; i++)
        {
            for (int j = 0; j < monkeys.Length; j++)
            {
                if (wiseMonkeyClue.monkeySprites[i] == monkeys[j].monkeySprite.sprite)
                    monkeys[j].CurrentMonkey = i;
            }
        }

        // To guarantee that the monkeys do not start in the correct positon,
        // swap the first monkey with the second if it matches the correct monkey
        if (monkeys[0].monkeySprite.sprite == wiseMonkeyClue.monkeyOrder[0])
        {
            Sprite temp = monkeys[0].monkeySprite.sprite;
            int tempCurrentMonkey = monkeys[0].CurrentMonkey;

            monkeys[0].monkeySprite.sprite = monkeys[1].monkeySprite.sprite;
            monkeys[0].CurrentMonkey = monkeys[1].CurrentMonkey;
            monkeys[1].monkeySprite.sprite = temp;
            monkeys[1].CurrentMonkey = tempCurrentMonkey;
        }
    }

    public void CheckOrder()
    {
        bool match = true;

        for (int idx = 0; idx < monkeys.Length; idx++)
        {
            if (monkeys[idx].monkeySprite.sprite != wiseMonkeyClue.monkeyOrder[idx])
            {
                match = false;
                break;
            }
        }

        if (match)
        {
            wiseMonkeyClue.puzzleCompleted = true;
            OnWiseMonkeyCompleted?.Invoke();
        }
    }
}
