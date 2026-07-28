using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameLoop gameLoop;
    public CameraSwitch cameraSwitch;
    public UserInterface userInterface;
    D6_DiceRoll d6_DiceRollScript;
    public PopulateCards populateCards;

    //Debug for set current camera
    public bool tableView = false;
    public bool topView = false;
    public bool barView = false;
    public bool TitleView = false;
    public bool CreditsView = false;

    // starting values for the first Encounter
    public int coins_Available = 100;
    public int player_HP = 20;
    public int player_MaxHP = 20;
    public int opponent_HP = 20;
    public int opponent_MaxHP = 20;

    public bool health_drink_aquired = false;
    public bool greed_drink_aquired = false;
    public bool fury_drink_aquired = false;

    [SerializeField] public GameObject CharacterFaceObject;
    [SerializeField] public List<Sprite> CharacterFaces = new List<Sprite>();
    public Sprite CharacterFaceCurrentSprite;

    public List<GameObject> opponentsCardList = new();
    public List<CardClass> opponentsChosenCards = new();

    public List<CardInteract> chosen_Cards = new(); // List of cards the player has chosen to play

    public bool player_Ready;
    public bool player_ReadyToReturn;

    private void Start()
    {
        userInterface = FindAnyObjectByType<UserInterface>();
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        gameLoop = FindAnyObjectByType<GameLoop>();
        d6_DiceRollScript = FindAnyObjectByType<D6_DiceRoll>();
        populateCards = FindAnyObjectByType<PopulateCards>();
        CharacterFaceCurrentSprite = CharacterFaceObject.GetComponent<SpriteRenderer>().sprite;

        CharacterFaceCurrentSprite = CharacterFaces[0];

        userInterface.UpdateUIText();

        cameraSwitch.SwitchToCamera("TitleView");
    }
    void Update()
    {
        if (cameraSwitch.currentCamera == "TableCamera" || cameraSwitch.currentCamera == "TopCamera")
        {
            // Refill the Player's card list if it is empty
            if (populateCards.ParentObject.transform.childCount == 0)
            {
                populateCards.PopulateCardList();
                opponentsCardList = populateCards.PopulateOpponentCards();
            }

            if (player_HP <= 0)
            {
                Debug.Log("Player has lost the game, Please restart");
            }

            gameLoop.GameLoop_Method();
        }
    }

    private void LateUpdate()
    {
        //Debug for forcefully setting and switching current camera
        if (tableView == true)
        {
            cameraSwitch.currentCamera = "TableCamera";
            cameraSwitch.SwitchToCamera("TableView");
        }
        if (topView == true)
        {
            cameraSwitch.currentCamera = "TopCamera";
            cameraSwitch.SwitchToCamera("TopDown");
        }
        if (barView == true)
        {
            cameraSwitch.currentCamera = "BarCamera";
            cameraSwitch.SwitchToCamera("BarView");
        }
        if (TitleView == true)
        {
            cameraSwitch.currentCamera = "TitleCamera";
            cameraSwitch.SwitchToCamera("TitleView");
        }
        if (CreditsView == true)
        {
            cameraSwitch.currentCamera = "CreditsCamera";
            cameraSwitch.SwitchToCamera("CreditsView");
        }
    }

    private void FixedUpdate()
    {
        if (cameraSwitch.currentCamera == "CreditsCamera")
        {
            // scrolls the credits until out of frame
            if (userInterface.creditstext.rectTransform.localPosition.y <= 66f)
            {
                userInterface.creditstext.rectTransform.localPosition += new Vector3(0, 0.1f, 0);
            }
        }
    }
}
