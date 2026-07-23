using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    CameraSwitch cameraSwitch;
    PlayerReady playerReadyScript;

    int totatlDMG = 0;
    int totatlDefence = 0;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        userInterface = FindAnyObjectByType<UserInterface>();
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        playerReadyScript = GetComponent<PlayerReady>();
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
            }

            Debug.Log("Starting Total Damage: " + totatlDMG);
            Debug.Log("Starting Total Defence: " + totatlDefence);

            // calculate result of cards played
            for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
            {
                if (gameManager.chosen_Cards[i].GetComponent<AttackCard>())
                {
                    totatlDMG += gameManager.chosen_Cards[i].GetComponent<AttackCard>().Damage;
                }
                else if (gameManager.chosen_Cards[i].GetComponent<DefenceCard>())
                {
                    totatlDefence += gameManager.chosen_Cards[i].GetComponent<DefenceCard>().Defence_Value;
                }
                else if (gameManager.chosen_Cards[i].GetComponent<SpecialCard>())
                {
                    gameManager.chosen_Cards[i].GetComponent<SpecialCard>();
                }
            }
            // apply the result of cards played + Log the result to the console
            if (gameManager.player_Ready == true)
            {
                Debug.Log("Total Damage: " + totatlDMG);
                Debug.Log("Total Defence: " + totatlDefence);

                totatlDMG -= totatlDefence;
                Debug.Log("Total Damage after Defence: " + totatlDMG);

                if (totatlDMG > 0) // + && gameManager.opponentChosenCards total defence value < totatlDMG
                {
                    gameManager.opponent_HP -= totatlDMG;
                    Debug.Log("Opponent HP after Damage: " + gameManager.opponent_HP);
                }
                else
                {
                    Debug.Log("No Damage Dealt to Opponent");
                }
            }

            // return the values to zero and switch camera back to table view
            totatlDMG = 0;
            totatlDefence = 0;

            if (gameManager.player_Ready == true)
            {
                gameManager.chosen_Cards.Clear();
                //cameraSwitch.SwitchToCamera("TableView");
                //Debug.Log("Changing Camera To TableView");
                gameManager.player_Ready = false;
            }
        }
    }
}