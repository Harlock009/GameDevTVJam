using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    [SerializeField] private Sprite pedestalWithOrb;
    private bool hasOrb;

    public static event Action OnPedestalCompleted;

    public override void Interact(Player player)
    {
        if (!hasOrb)
        {
            for (int itemIdx = 0; itemIdx < player.items.Count; itemIdx++)
            {
                if (player.items[itemIdx].itemUI.tag == "Orb")
                {
                    GetComponent<SpriteRenderer>().sprite = pedestalWithOrb;
                    hasOrb = true;
                    player.DropItem(itemIdx);
                    OnPedestalCompleted?.Invoke();
                    break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        hasOrb = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
