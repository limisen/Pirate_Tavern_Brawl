using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    CameraSwitch cameraSwitch;
    PlayerReady playerReadyScript;
    D6_DiceRoll d6_DiceRollScript;
    [SerializeField] GameObject Dice;

    bool opponentHasChosenCards = false;

    int playerTotalDamage = 0;
    int playerTotalDefence = 0;
    int opponentTotalDamage = 0;
    int opponentTotalDefence = 0;
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
        // opponent chooses cards to play
        if (!opponentHasChosenCards)
        {
            Debug.Log("Opponent is choosing cards to play...");

            int opponentCardCount = Random.Range(0, 9); // Randomly choose between 0 and 8 cards to play
            Debug.Log("Opponent has chosen " + opponentCardCount + " cards to play.");

            for (int nrOfCardsToPlay = 0; nrOfCardsToPlay < opponentCardCount; nrOfCardsToPlay++)
            {
                // Refill the Opponent's card list if it is empty
                if (gameManager.opponentsCardList.Count == 0)
                {
                    Debug.Log("Opponent's card list is empty, refilling...");
                    gameManager.opponentsCardList = gameManager.populateCards.PopulateOpponentCards();
                }

                int chosenCardIndex = Random.Range(0, gameManager.opponentsCardList.Count); // Randomly choose a card from the opponent's list of card choices
                //Debug.Log("Opponent has chosen card: " + gameManager.opponentsCardList[chosenCardIndex].name + " With index = " + chosenCardIndex);

                //Debug.Log("Adding card to opponent's chosen cards list...");
                gameManager.opponentsChosenCards.Add(gameManager.opponentsCardList[chosenCardIndex].GetComponent<CardClass>()); // Add the card to the opponent's chosen cards list

                //Debug.Log("Opponent's card list count before removal: " + gameManager.opponentsCardList.Count);
                //Debug.Log("Removing card from opponent's card list...");
                gameManager.opponentsCardList.Remove(gameManager.opponentsCardList[chosenCardIndex]); // Remove the card from the opponent's list of card choices
                //Debug.Log("Opponent's card list count after removal: " + gameManager.opponentsCardList.Count);
            }
            Debug.Log("Opponent has finished choosing cards to play.");
            opponentHasChosenCards = true; // Set the flag to true so that the opponent does not choose cards again(/endlessly) until the next turn
        }

        // Player chooses cards to play
        // Check if player is ready to play their selected/chosen cards
        playerReadyScript.PlayerReady_Method();

        //Player has confirmed they are ready to play their cards, switch camera to top down view
        if (gameManager.player_Ready == true)
        {
            // Log the starting total damage and total defence to the console (just to make sure they are zero before calculation)
            Debug.Log("Player's Starting Total Damage: " + playerTotalDamage);
            Debug.Log("Player's Starting Total Defence: " + playerTotalDefence);

            // calculate result of the player's cards played
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
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(currentCard.GetComponent<AttackCard>().minDamage, currentCard.GetComponent<AttackCard>().maxDamage);

                    // Add the result of the dice roll to the total damage
                    playerTotalDamage += CardDiceRoll;
                    // Log the result of the dice roll and the total damage to the console
                    Debug.Log(currentCard.name + " Damage rolled: " + CardDiceRoll);
                    Debug.Log("Player's Total Damage: " + playerTotalDamage);
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
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(currentCard.GetComponent<DefenceCard>().minDefence_Value, currentCard.GetComponent<DefenceCard>().maxDefence_Value);

                    // Add the result of the dice roll to the total defence
                    playerTotalDefence += CardDiceRoll;
                    // Log the result of the dice roll and the total defence to the console
                    Debug.Log(currentCard.name + " Defence rolled: " + CardDiceRoll);
                    Debug.Log("Player's Total Defence: " + playerTotalDefence);
                }
                // If the card is a special card, we will handle it differently (for now, we will just move on to the next card)
                else if (currentCard.GetComponent<SpecialCard>())
                {
                    // Handle special card logic here
                    currentCard.GetComponent<SpecialCard>();
                }
            }
            // Log the result to the console
            Debug.Log("Player's Total Damage: " + playerTotalDamage);
            Debug.Log("Player's Total Defence: " + playerTotalDefence);
            // Finished calculating the result of the player's cards played, now we will calculate the result of the opponent's cards played

            // Log the starting total damage and total defence to the console (just to make sure they are zero before calculation)
            Debug.Log("Opponent's Starting Total Damage: " + opponentTotalDamage);
            Debug.Log("Opponent's Starting Total Defence: " + opponentTotalDefence);
            // calculate result of the opponent's cards played
            for (int i = 0; i < gameManager.opponentsChosenCards.Count; i++)
            {
                // get the first card in the list of chosen cards, then the second card, so on so forth, until the last card in the list has been processed
                CardClass currentCard = gameManager.opponentsChosenCards[i];

                // Check the type of card and add its value to the total damage or total defence
                if (currentCard.GetComponent<AttackCard>())
                {
                    // Instantiate a dice object for the attack card
                    GameObject CardDice = Instantiate(Dice, currentCard.transform);
                    // Make it so that the dice is rendered above the card (sorting order 2)
                    CardDice.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    // position the dice at the card's bottom left of the card (where the dmg is displayed) and scale it up to be visible
                    CardDice.transform.localPosition = new Vector3(1.85f, 2.1f, 0);
                    CardDice.transform.localScale = new Vector3(2, 2, 1);

                    // Roll the dice for the attack card and get the result
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(currentCard.GetComponent<AttackCard>().minDamage, currentCard.GetComponent<AttackCard>().maxDamage);

                    // Add the result of the dice roll to the total damage
                    opponentTotalDamage += CardDiceRoll;
                    // Log the result of the dice roll and the total damage to the console
                    Debug.Log(currentCard.name + " Damage rolled: " + CardDiceRoll);
                    Debug.Log("Opponent's Total Damage: " + opponentTotalDamage);
                }
                else if (currentCard.GetComponent<DefenceCard>())
                {
                    GameObject CardDice = Instantiate(Dice, currentCard.transform);
                    CardDice.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    // position the dice at the card's bottom left of the card (where the block/defence is displayed) and scale it up to be visible
                    CardDice.transform.localPosition = new Vector3(1.85f, 2.1f, 0);
                    CardDice.transform.localScale = new Vector3(2, 2, 1);

                    // Roll the dice for the defence card and get the result
                    int CardDiceRoll = CardDice.GetComponent<D6_DiceRoll>().RollD6(currentCard.GetComponent<DefenceCard>().minDefence_Value, currentCard.GetComponent<DefenceCard>().maxDefence_Value);

                    // Add the result of the dice roll to the total defence
                    opponentTotalDefence += CardDiceRoll;
                    // Log the result of the dice roll and the total defence to the console
                    Debug.Log(currentCard.name + " Defence rolled: " + CardDiceRoll);
                    Debug.Log("Opponent's Total Defence: " + opponentTotalDefence);
                }
                // If the card is a special card, we will handle it differently (for now, we will just move on to the next card)
                else if (currentCard.GetComponent<SpecialCard>())
                {
                    // Handle special card logic here
                    currentCard.GetComponent<SpecialCard>();
                }
            }
            // Log the result to the console
            Debug.Log("Opponent's Total Damage: " + opponentTotalDamage);
            Debug.Log("Opponent's Total Defence: " + opponentTotalDefence);

            gameManager.player_Ready = false; // calculations are complete, so reset the player ready variable to false
        }
        // Finished calculating the result of the opponent's cards played, now we will apply the result of cards played

        // When the player is ready to return to the table view, apply the damage to the opponent's HP (otherwise the player would be thrust into the bar view, if it was done sooner)
        if (gameManager.player_ReadyToReturn == true)
        {
            // Apply the damage to the opponent's HP based on the total damage and total defence calculated earlier
            if (opponentTotalDefence == playerTotalDamage)
            {
                Debug.Log("Damage Perfectly Blocked by opponent!");
            }
            else if (opponentTotalDefence < playerTotalDamage)
            {
                gameManager.opponent_HP -= (playerTotalDamage - opponentTotalDefence);
                userInterface.UpdateUIText();
                Debug.Log("Opponent HP after Damage: " + gameManager.opponent_HP);
            }
            else if (opponentTotalDefence > playerTotalDamage) 
            {
                Debug.Log("No Damage Dealt to Opponent");
            }

            // Apply the damage to the player's HP based on the total damage and total defence calculated earlier
            if (playerTotalDefence == opponentTotalDamage)
            {
                Debug.Log("Damage Perfectly Blocked by Player!");
            }
            else if (playerTotalDefence < opponentTotalDamage)
            {
                gameManager.player_HP -= (opponentTotalDamage - playerTotalDefence);
                userInterface.UpdateUIText();
                Debug.Log("Player HP after Damage: " + gameManager.player_HP);
            }
            else if (playerTotalDefence > opponentTotalDamage)
            {
                Debug.Log("No Damage Dealt to Player");
            }

            // return the values to zero
            opponentTotalDamage = 0;
            opponentTotalDefence = 0;

            // Destroy the Player's chosen cards since they have been played
            for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
            {
                Destroy(gameManager.chosen_Cards[i].gameObject);
            }
            // Destroy the Opponent's chosen cards since they have been played
            for (int i = 0; i < gameManager.opponentsChosenCards.Count; i++)
            {
                Destroy(gameManager.opponentsChosenCards[i].gameObject);
            }

            // Clear the lists of chosen cards since they have all been played
            gameManager.chosen_Cards.Clear();
            gameManager.opponentsChosenCards.Clear();

            // reset the player ready variables so that the player can choose cards again
            gameManager.player_Ready = false;
            gameManager.player_ReadyToReturn = false;
            opponentHasChosenCards = false;
        }
    }
}