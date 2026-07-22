using UnityEngine;

public class PlayerReady : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();

    }

    public void PlayerReady_Method(GameObject playArea)
    {
        if (gameManager.player_Ready == true)
        {
            Debug.Log("Player is ready to play their cards");
            // opponent väljer kort

            for (int i = 0; i < gameManager.chosen_Cards.Count; i++)
            {
                gameManager.chosen_Cards[i].transform.SetParent(playArea.transform);
                gameManager.chosen_Cards[i].transform.localPosition = new Vector3(i, 0, 0);
            }
        }
    }
}