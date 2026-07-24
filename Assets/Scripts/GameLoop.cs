using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    CameraSwitch cameraSwitch;
    PlayerReady playerReadyScript;
    D6_DiceRoll d6_DiceRollScript;

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
        if (gameManager.player_HP >= 1 | gameManager.opponent_HP >= 1)
        {
            // choose cards to play

            // confirm cards to be played / check if player is ready to play cards
            playerReadyScript.PlayerReady_Method();

            //Player has confirmed they are ready to play their cards, switch camera to top down view
            if (gameManager.player_Ready == true)
            {
                Debug.Log("Changing Camera To TopDown");
                cameraSwitch.SwitchToCamera("TopDown");
                cameraSwitch.currentCamera = "TopCamera";
                Debug.Log("Starting Total Damage: " + totatlDMG);
                Debug.Log("Starting Total Defence: " + totatlDefence);

                // calculate result of cards played
                for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
                {
                    //
                    int rando_nr = d6_DiceRollScript.RollD6();

                    // Check the type of card and add its value to the total damage or total defence
                    if (gameManager.chosen_Cards[i].GetComponent<AttackCard>())
                    {
                        totatlDMG += rando_nr;
                        Debug.Log("Dice Value rolled: " + rando_nr);
                        Debug.Log("Total Damage: " + totatlDMG);
                        //totatlDMG += gameManager.chosen_Cards[i].GetComponent<AttackCard>().Damage;
                    }
                    else if (gameManager.chosen_Cards[i].GetComponent<DefenceCard>())
                    {
                        totatlDefence += rando_nr;
                        Debug.Log("Dice Value rolled: " + rando_nr);
                        Debug.Log("Total Defence: " + totatlDefence);
                        //totatlDefence += gameManager.chosen_Cards[i].GetComponent<DefenceCard>().Defence_Value;
                    }
                    else if (gameManager.chosen_Cards[i].GetComponent<SpecialCard>())
                    {
                        // rando_nr, meant to be used once special cards are implemented...
                        gameManager.chosen_Cards[i].GetComponent<SpecialCard>();
                    }
                }
                // Log the result to the console
                Debug.Log("Total Damage: " + totatlDMG);
                Debug.Log("Total Defence: " + totatlDefence);
                totatlDMG -= totatlDefence;
                Debug.Log("Total Damage after Defence: " + totatlDMG);
                
                gameManager.player_Ready = false;
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

                if (gameManager.player_HP >= 1 && gameManager.opponent_HP <= 0)
                {
                    Debug.Log("Player has won the encounter!");
                    gameManager.coins_Available += 20; // reward for winning the encounter
                    userInterface.UpdatdeUIText();
                    Debug.Log("Player gained 20 coins!");
                    Debug.Log("Player Coins: " + gameManager.coins_Available);
                }

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
}