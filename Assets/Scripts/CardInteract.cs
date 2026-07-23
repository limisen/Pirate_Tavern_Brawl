using UnityEngine;
using UnityEngine.InputSystem;

public class CardInteract : MonoBehaviour
{
    public bool CardSelected = false;
    public bool onCard = false;
    public bool is_in_playbox = false;

    private Vector3 startLocalScale;
    private Vector3 startLocalPosition;
    private Quaternion startLocalRotation;
    private int cardRendererStartingValue;

    private CardClass cardClass;
    private Renderer cardRenderer;
    private Camera cam;

    GameManager gameManager;

    private void Start()
    {
        cam = Camera.main;                              // Define the camera we are viewing through

        startLocalScale = transform.localScale;         // /-
        startLocalPosition = transform.localPosition;   // Set the starting values so we have something to return to after manipulating the cards
        startLocalRotation = transform.localRotation;   // -/

        cardRenderer = GetComponent<SpriteRenderer>();
        cardRendererStartingValue = cardRenderer.sortingOrder;
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnMouseDown()
    {
        cardClass = GetComponent<CardClass>();
        if (CardSelected == false && cardClass.cardNoInteract == false)                        // If we click on a card set "CardSelected" to true and "onCard" to false.
        {
            CardSelected = true;                          // Attempting to make it so we dont try to both enlarge the card and move it at the same time
            onCard = false;
        }
    }
    private void OnMouseUp()
    {
        CardSelected = false;
        cardManipulation();
    }
    void OnMouseOver()
    {
        cardClass = GetComponent<CardClass>();
        if (CardSelected == false && onCard == false && cardClass.cardNoInteract == false)
        {
            onCard = true;
            cardManipulation();
        }
    }
    void OnMouseExit()
    {
        onCard = false;
        cardManipulation();
    }
    private void Update()
    {
        if (CardSelected == true && onCard == false && cardClass.cardNoInteract == false)
        {
            cardManipulation();                        // if we are holding down M1 then move the card along with the mouse
        }
    }
    void cardManipulation()
    {
        if (CardSelected == true && cardClass.cardNoInteract == false)     // If we are holding down M1, rotate the card upright then move it along with the mouse
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.transform.position = cam.ScreenToWorldPoint(new Vector3((Mouse.current.position.ReadValue().x), (Mouse.current.position.ReadValue().y), 11)); // breaks on other resolutions than 1920x1080
            cardRenderer.sortingOrder = 100;
        }
        else if (onCard == true && cardClass.cardNoInteract == false)    // If we are hovering over a card, Enlarge it and rotate it upright
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            //gameObject.transform.localPosition = new Vector3(0, 2.5f, 0);
            cardRenderer.sortingOrder = 100;
        }
        else if (CardSelected == false && onCard == false && is_in_playbox == true && cardClass.cardNoInteract == false && gameObject.transform.localScale == new Vector3(0.300000012f, 0.300000012f, 1))
        {// if the card is in the playbox and we are not hovering over it or holding down M1 on it, then add it to the array of cards to be played
            Debug.Log("Card " + gameObject.name + " has been selected to be played");
            gameManager.chosen_Cards.Add(this);
            //Debug.Log("Card added to the array: " + gameManager.chosen_Cards);

            gameObject.GetComponent<CardClass>().cardNoInteract = true; // make it so we cant interact with the card anymore

            gameManager.coins_Available -= gameObject.GetComponent<CardClass>().Cost_of_Card;
        }
        else if ((CardSelected == false || onCard == false || is_in_playbox == false) && cardClass.cardNoInteract == false) // if we arent hovering over a card or holding down M1 on it, return it to the scale, rotation and position it was at the start.
        {
            gameObject.transform.localScale = startLocalScale;
            gameObject.transform.localRotation = startLocalRotation;
            gameObject.transform.localPosition = startLocalPosition;
            cardRenderer.sortingOrder = cardRendererStartingValue;
        }
    }
}