using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiseMonkeyPuzzle : MonoBehaviour
{
    public WiseMonkeysClue wiseMonkeyClue;
    public WiseMonkeys wiseMonkeys;

    // List of sprites used for the puzzle
    public List<Sprite> monkeySprites;
    public bool puzzleCompleted;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCompleted = false;

        if (wiseMonkeyClue != null)
            wiseMonkeyClue.SetCorrectOrder();

        if (wiseMonkeys != null)
            wiseMonkeys.RandomizeMonkeys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
