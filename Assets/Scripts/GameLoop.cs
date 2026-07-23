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
            // väljer kort etc att spela

            // confirm cards to be played
            playerReadyScript.PlayerReady_Method();
            if (gameManager.player_Ready == true)
            {
                Debug.Log("Changing Camera To TopDown");
                cameraSwitch.SwitchToCamera("TopDown");
            }

            // calculate result of cards played + show player
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

            Debug.Log("Total Damage: " + totatlDMG);
            Debug.Log("Total Defence: " + totatlDefence);

            totatlDMG -= totatlDefence;
            Debug.Log("Total Damage after Defence: " + totatlDMG);
        }
    }
}