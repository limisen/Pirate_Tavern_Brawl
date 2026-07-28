using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] Text coins;
    [SerializeField] Animator purse;
    [SerializeField] Text player_health_counter;
    [SerializeField] Button confirmButton;
    [SerializeField] Button TitleStartButton;
    [SerializeField] Button TitleQuitButton;
    [SerializeField] GameObject BuyButtons;

    [SerializeField] public Text creditstext;


    // Enemy stuffs
    [SerializeField] Text enemy_health_counter;

    // Power-Ups at the Bar
    [SerializeField] GameObject health_drink;
    [SerializeField] GameObject greed_drink;
    [SerializeField] GameObject fury_drink;

    [SerializeField] Image opponentHealthbar;
    [SerializeField] Sprite[] healthBar;

    CameraSwitch cameraSwitch;


    public void Start()
    {
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        gameManager = FindAnyObjectByType<GameManager>();
    }



    public void UpdateUIText()
    {
        coins.text = gameManager.coins_Available.ToString();
        player_health_counter.text = "Player HP: " + gameManager.player_HP.ToString();
        enemy_health_counter.text = "Enemy HP: " + gameManager.opponent_HP.ToString();
        UpdateUI_health(gameManager.opponent_HP, gameManager.opponent_MaxHP);
    }

    public void UpdateUI_health(int HP, int maxHP)
    {
        if (maxHP != 30)
        {
            // math to get the ratio of the current HP to the max HP, then use that ratio to determine which sprite to use for the health bar
            Debug.Log("Opponent HP" + HP.ToString());
            float hpRatio = (float)HP / maxHP;
            Debug.Log("Ratio" + hpRatio.ToString());
            int spriteI = ((int)Mathf.Clamp(Mathf.Floor(healthBar.Length * hpRatio), 0f, healthBar.Length - 1));
            Debug.Log("SpriteI" + spriteI.ToString());
            opponentHealthbar.sprite = healthBar[spriteI];
        }
        else if (maxHP == 30)
        {
            // Debug.Log("pre division: " + HP.ToString());
            HP = (HP / 2);
            // Debug.Log("post division: " + HP.ToString());

            if (HP == 1 || HP <= 0)
            {
                opponentHealthbar.sprite = healthBar[0];
            }
            else
            {
                opponentHealthbar.sprite = healthBar[HP - 1]; //use this one for normal play min value 0, max 14
            }
        }
    }

    public void buttonPress()
    {
        Debug.Log("confirm button pressed");
        if (gameManager.opponent_HP <= 0 && gameManager.player_HP > 0)
        {
            // Opponent is dead, You can stop gloating now. Head over to the bar!
            Debug.Log("changing camera to BarView");
            gameManager.cameraSwitch.SwitchToCamera("BarView");

            // Adding the coin reward for winning the encounter
            gameManager.coins_Available += 20;
            // Updating UI to reflect the new value
            gameManager.userInterface.UpdateUIText();

            // Giving the opponent an new face
            Debug.Log("Checking opponent's current face Sprite");
            Debug.Log("CurrentFace: " + gameManager.CharacterFaceCurrentSprite.name);
            for (int i = 0; i < gameManager.CharacterFaces.Count; i++)
            {
                Debug.Log(i);
                if (i + 1 == gameManager.CharacterFaces.Count)
                {
                    Debug.Log("At end of CharacterFacesList...");
                    Debug.Log("Changing Face of Opponent to: " + gameManager.CharacterFaces[0].name + ", first element in the list");
                    gameManager.CharacterFaceObject.GetComponent<SpriteRenderer>().sprite = gameManager.CharacterFaces[0];
                    break;
                }
                else if (gameManager.CharacterFaceCurrentSprite.name == gameManager.CharacterFaces[i].name)
                {
                    Debug.Log("Changing Face of Opponent to: " + gameManager.CharacterFaces[i + 1].name);
                    gameManager.CharacterFaceObject.GetComponent<SpriteRenderer>().sprite = gameManager.CharacterFaces[i + 1];
                    break;
                }
            }
            gameManager.CharacterFaceCurrentSprite = gameManager.CharacterFaceObject.GetComponent<SpriteRenderer>().sprite;
        }
        else if (gameManager.player_HP <= 0)
        {
            Debug.Log("Player is dead, game over");

            // resetting starting values so the player can start the first Encounter agian.
            gameManager.coins_Available = 100;
            gameManager.player_HP = 20;
            gameManager.player_MaxHP = 20;
            gameManager.opponent_HP = 20;
            gameManager.opponent_MaxHP = 20;

            UpdateUIText();

            // Destroying all the cards in the card list
            for (int i = 0; i < gameManager.populateCards.ParentObject.transform.childCount; i++)
            {
                Destroy(gameManager.populateCards.ParentObject.transform.GetChild(i).gameObject);
            }

            // Returning the player to TitleScreen
            Debug.Log("Switcing camera to TitleScreen...");
            gameManager.cameraSwitch.SwitchToCamera("TitleView");
        }
        else if (gameManager.opponent_HP > 0 && gameManager.player_HP > 0)
        {
            // both parties are still alive, switching to TopDown before continuing play
            gameManager.player_Ready = true;
            Debug.Log("changing camera to TopDown");
            gameManager.cameraSwitch.SwitchToCamera("TopDown");
        }
    }

    public void RefillCardsButtonPress()
    {
        Debug.Log("Refill Cards button pressed");

        if (gameManager.chosen_Cards.Count == 0 && !(gameManager.coins_Available - 6 < 0))
        {
            gameManager.coins_Available -= 6;
            gameManager.userInterface.UpdateUIText();

            // Destroy all the cards in the card list before repopulating it
            for (int i = 0; i < gameManager.populateCards.ParentObject.transform.childCount; i++)
            {
                Destroy(gameManager.populateCards.ParentObject.transform.GetChild(i).gameObject);
            }

            gameManager.populateCards.PopulateCardList();
        }
        else
        {
            Debug.Log("But player has already chosen cards to play, cannot refill cards");
        }
    }

    public void buyButtonOne(Button buttonOne)
    {
        Debug.Log("Buy Health Drink");
        health_drink.gameObject.SetActive(false);
        buttonOne.gameObject.SetActive(false);

        gameManager.health_drink_aquired = true;
    }

    public void TitleStartButtonPressed()
    {
        Debug.Log("Title Start Button Pressed");
        Debug.Log("Changing Camera To TableView");
        cameraSwitch.SwitchToCamera("TableView");
    }

    public void TitleCreditsButtonPressed()
    {
        Debug.Log("Title Credits Button Pressed");
        Debug.Log("Changing Camera To CreditsView");
        cameraSwitch.SwitchToCamera("CreditsView");
    }

    public void TitleQuitButtonPressed()
    {
        Debug.Log("Title Quit Button Pressed");
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void buyButtonTwo(Button buttonTwo)
    {
        Debug.Log("Buy Greed Drink");
        greed_drink.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);

        gameManager.greed_drink_aquired = true;
    }

    public void buyButtonThree(Button buttonThree)
    {
        Debug.Log("Buy Fury Drink");
        fury_drink.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);

        gameManager.fury_drink_aquired = true;
    }
    public void doneWithCheckingResults()
    {
        Debug.Log("Player is done with checking the results of cards played");
        if (gameManager.opponent_HP <= 0)
        {
            Debug.Log("Changing Camera To BarView");
            cameraSwitch.SwitchToCamera("BarView");
            gameManager.player_ReadyToReturn = true;
        }
        else if (gameManager.opponent_HP > 0)
        {
            Debug.Log("Changing Camera To TableView");
            cameraSwitch.SwitchToCamera("TableView");
            gameManager.player_ReadyToReturn = true;
        }
    }
    public void DoneWithUpgrades()
    {
        Debug.Log("Player is done with buying upgrades");
        Debug.Log("Changing Camera To TableView");
        cameraSwitch.SwitchToCamera("TableView");

        if (gameManager.health_drink_aquired)
        {
            gameManager.player_MaxHP += 10;
        }
        if (gameManager.greed_drink_aquired)
        {
            gameManager.coins_Available += 10;
        }
        if (gameManager.fury_drink_aquired)
        {
            gameManager.opponent_MaxHP -= 10;
        }

        // Reset the HP values for a new encounter
        gameManager.player_HP = gameManager.player_MaxHP;
        gameManager.opponent_HP = gameManager.opponent_MaxHP;
        // Update the UI to reflect the new HP values
        UpdateUIText();

        // Reset the drink acquisition flags for the next encounter (otherwise the opponent HP will be reduced by 10 every time the player goes to the bar, even if they don't buy the drink)
        gameManager.health_drink_aquired = false;
        gameManager.fury_drink_aquired = false;
        gameManager.greed_drink_aquired = false;

        // For the future, IF the drinks should be able to be bought again
        //health_drink.gameObject.SetActive(true);
        //fury_drink.gameObject.SetActive(true);
        //greed_drink.gameObject.SetActive(true);
        //BuyButtons.SetActive(true);

        // Destroy all the cards in the card list before repopulating it
        for (int i = 0; i < gameManager.populateCards.ParentObject.transform.childCount; i++)
        {
            Destroy(gameManager.populateCards.ParentObject.transform.GetChild(i).gameObject);
        }
        gameManager.populateCards.PopulateCardList();
    }
}