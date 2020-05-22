using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : Interactable
{
    [SerializeField] private Sprite pedestalWithOrb;
    [SerializeField] private AudioClip door;
    private bool hasOrb;

    public override void Interact(Player player)
    {
        //TODO:
        //The drop SFX plays
        //Door opens
        if (!hasOrb)
        {
            for (int itemIdx = 0; itemIdx < player.items.Count; itemIdx++)
            {
                if (player.items[itemIdx].itemUI.tag == "Orb")
                {
                    GetComponent<SpriteRenderer>().sprite = pedestalWithOrb;
                    //TODO: Door opens
                    AudioSource.PlayClipAtPoint(door, Camera.main.transform.position, 0.5f);
                    hasOrb = true;
                    player.DropItem(itemIdx);
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
