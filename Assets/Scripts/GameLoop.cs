using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    CameraSwitch cameraSwitch;
    PlayerReady playerReadyScript;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        userInterface = FindAnyObjectByType<UserInterface>();
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        playerReadyScript = FindAnyObjectByType<PlayerReady>();
    }

    public void GameLoop_Method()
    {
        if (gameManager.player_HP >= 1 | gameManager.opponent_HP >= 1)
        {
            // switch camera
            cameraSwitch.SwitchToCamera("TableView");
            //gameManager.player_Ready = false;

            // väljer kort etc att spela

            // confirm cards to be played
            playerReadyScript.PlayerReady_Method();

            //cameraSwitch.SwitchToCamera("TopDown");

            // calculate result of cards played + show player

            // check hp if less than 0

            userInterface.UpdatdeUIText();

            //      return to star
            //      or
            //      continue to upgrades

            //done
        }
    }
}
