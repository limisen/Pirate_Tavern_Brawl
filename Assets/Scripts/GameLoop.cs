using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager gameManager;
    UserInterface userInterface;
    private void Start()
    {
       gameManager  = GetComponent<GameManager>();
       userInterface = FindAnyObjectByType<UserInterface>();
    }

    public void GameLoop_Method()
    {
        if (gameManager.player_HP >= 1 | gameManager.opponent_HP >= 1)
        {
           // switch camera

            // väljer kort etc att spela

            // confirm

            // opponent väljer kort

            // switch camera

            // calculate result of cards played + show player

            // check hp if less than 0
                // return to star
                //continue to upgrades

            userInterface.UpdatdeUIText();
            //done
        }
    }
}
