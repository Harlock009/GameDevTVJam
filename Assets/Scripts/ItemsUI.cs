using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsUI : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        player.OnItemPickUp += DisplayPickUp;
        player.OnItemDrop += RemovePickUp;
    }

    private void DisplayPickUp(object sender, Player.ItemEventArgs e)
    {
        Instantiate(player.items[e.itemIndex].itemUI, transform);
    }

    private void RemovePickUp(object sender, Player.ItemEventArgs e)
    {
        Transform[] itemsInUI = GetComponentsInChildren<Transform>();
        Destroy(itemsInUI[e.itemIndex + 1].gameObject);
    }

    private void OnDestroy()
    {
        player.OnItemPickUp -= DisplayPickUp;
        player.OnItemDrop -= RemovePickUp;
    }
}
