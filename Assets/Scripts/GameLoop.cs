using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    CameraSwitch cameraSwitch;
    PlayerReady playerReadyScript;
    D6_DiceRoll d6_DiceRollScript;
    [SerializeField] GameObject Dice;

    int totatlDMG = 0;
    int totatlDefence = 0;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        userInterface = FindAnyObjectByType<UserInterface>();
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        playerReadyScript = GetComponent<PlayerReady>();
        d6_DiceRollScript = FindAnyObjectByType<D6_DiceRoll>();
    }

    public void GameLoop_Method()
    {
        // Player chooses cards to play

        // Check if player is ready to play their selected/chosen cards
        playerReadyScript.PlayerReady_Method();

        //Player has confirmed they are ready to play their cards, switch camera to top down view
        if (gameManager.player_Ready == true)
        {
            // Log the starting total damage and total defence to the console (just to make sure they are zero before calculation)
            Debug.Log("Starting Total Damage: " + totatlDMG);
            Debug.Log("Starting Total Defence: " + totatlDefence);

            // calculate result of cards played
            for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
            {
                // get the first card in the list of chosen cards, then the second card, so on so forth, until the last card in the list has been processed
                CardInteract currentCard = gameManager.chosen_Cards[i]; 

                // Check the type of card and add its value to the total damage or total defence
                if (currentCard.GetComponent<AttackCard>())
                {
                    // Instantiate a dice object for the attack card
                    GameObject CardDice = Instantiate(Dice, currentCard.transform);
                    // Make it so that the dice is rendered above the card (sorting order 2)
                    CardDice.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    // position the dice at the bottom left of the card (where the dmg is displayed) and scale it up to be visible
                    CardDice.transform.localPosition = new Vector3(-1.85f, -2.1f, 0);
                    CardDice.transform.localScale = new Vector3(2, 2, 1);

                    // Roll the dice for the attack card and get the result
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(1, currentCard.GetComponent<AttackCard>().Damage);

                    // Add the result of the dice roll to the total damage
                    totatlDMG += CardDiceRoll;
                    // Log the result of the dice roll and the total damage to the console
                    Debug.Log(currentCard.name + " Damage rolled: " + CardDiceRoll);
                    Debug.Log("Total Damage: " + totatlDMG);
                }
                else if (currentCard.GetComponent<DefenceCard>())
                {
                    GameObject CardDice = Instantiate(Dice, currentCard.transform);
                    CardDice.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    CardDice.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    // position the dice at the bottom left of the card (where the block/defence is displayed) and scale it up to be visible
                    CardDice.transform.localPosition = new Vector3(-1.85f, -2.1f, 0);
                    CardDice.transform.localScale = new Vector3(2, 2, 1);

                    // Roll the dice for the defence card and get the result
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(1, currentCard.GetComponent<DefenceCard>().Defence_Value);

                    // Add the result of the dice roll to the total defence
                    totatlDefence += CardDiceRoll;
                    // Log the result of the dice roll and the total defence to the console
                    Debug.Log(currentCard.name + " Defence rolled: " + CardDiceRoll);
                    Debug.Log("Total Defence: " + totatlDefence);
                }
                // If the card is a special card, we will handle it differently (for now, we will just move on to the next card)
                else if (currentCard.GetComponent<SpecialCard>())
                {
                    // Handle special card logic here
                    currentCard.GetComponent<SpecialCard>();
                }
            }
            // Log the result to the console
            Debug.Log("Total Damage: " + totatlDMG);
            Debug.Log("Total Defence: " + totatlDefence);
            totatlDMG -= totatlDefence;
            Debug.Log("Total Damage after Defence: " + totatlDMG);

            gameManager.player_Ready = false; // calculations are complete, so reset the player ready variable to false
        }

        // When the player is ready to return to the table view, apply the damage to the opponent's HP (otherwise the player would be thrust into the bar view, if it was done sooner)
        if (gameManager.player_ReadyToReturn == true)
        {
            if (totatlDefence == totatlDMG)
            {
                Debug.Log("Damage Perfectly Blocked by opponent!");
            }
            else if (totatlDMG > totatlDefence)
            {
                gameManager.opponent_HP -= totatlDMG;
                userInterface.UpdatdeUIText();
                Debug.Log("Opponent HP after Damage: " + gameManager.opponent_HP);
            }
            else
            {
                Debug.Log("No Damage Dealt to Opponent");
            }

            // return the values to zero
            totatlDMG = 0;
            totatlDefence = 0;

            // Destroy the chosen cards since they have been played
            for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
            {
                Destroy(gameManager.chosen_Cards[i].gameObject);
            }
            // Clear the list of chosen cards since they have all been played
            gameManager.chosen_Cards.Clear();

            // reset the player ready variables so that the player can choose cards again
            gameManager.player_Ready = false;
            gameManager.player_ReadyToReturn = false;
        }
    }
}