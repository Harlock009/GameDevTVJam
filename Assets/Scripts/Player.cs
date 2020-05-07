using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Movement
    [Header("Player Movement")]
    [SerializeField] float speed = 5f;
    private bool moving;
    [SerializeField] private Vector2 lastMove;

    // Items and interactables
    Interactable interactableInRange;
    public List<ItemData> items;

    // New EventArgs to pass in arguments
    public class ItemEventArgs : EventArgs
    {
        public int itemIndex;
    }

    // Events
    public event EventHandler<ItemEventArgs> OnItemPickUp;
    public event EventHandler<ItemEventArgs> OnItemDrop;

    // Cached References
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        moving = false;
        lastMove = new Vector2(0f, -1f);
        interactableInRange = null;
        items = new List<ItemData>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
        Move();
    }

    /// <summary>
    /// The player interacts with the Interactable if they entered the trigger
    /// </summary>
    private void Interact()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (interactableInRange != null)
                interactableInRange.Interact(this);
        }
    }

    public void PickUpItem(ItemData itemToPickUp)
    {
        AudioSource.PlayClipAtPoint(itemToPickUp.pickUpSFX, Camera.main.transform.position, 0.5f);
        items.Add(itemToPickUp);
        OnItemPickUp?.Invoke(this, new ItemEventArgs() { itemIndex = items.Count - 1 });
    }

    public void DropItem(int itemIndexToRemove)
    {
        //AudioSource.PlayClipAtPoint(items[itemIndexToRemove].dropSFX, Camera.main.transform.position, 0.5f);
        OnItemDrop?.Invoke(this, new ItemEventArgs() { itemIndex = itemIndexToRemove });
        items.RemoveAt(itemIndexToRemove);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
            interactableInRange = other.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
            interactableInRange = null;
    }

    /// <summary>
    /// The player moves based on input
    /// </summary>
    private void Move()
    {
        float horizontal = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        float vertical = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
        {
            playerRigidBody.MovePosition(new Vector2(transform.position.x + (horizontal * speed * Time.deltaTime), transform.position.y));
            moving = true;
            lastMove = new Vector2(horizontal, 0f);
        }
        else if (vertical != 0)
        {
            playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y + (vertical * speed * Time.deltaTime)));
            moving = true;
            lastMove = new Vector2(0f, vertical);
        }
        else
            moving = false;

        playerAnimator.SetFloat("Horizontal", horizontal);
        playerAnimator.SetFloat("Vertical", vertical);
        playerAnimator.SetFloat("LastMoveHorizontal", lastMove.x);
        playerAnimator.SetFloat("LastMoveVertical", lastMove.y);
        playerAnimator.SetBool("Walking", moving);
    }
}
