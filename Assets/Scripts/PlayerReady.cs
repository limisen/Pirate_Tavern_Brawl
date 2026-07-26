using UnityEngine;

public class PlayerReady : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject playerPlayArea;
    [SerializeField] GameObject opponentPlayArea;

    [SerializeField] Vector3 startPlayerCardPos = new Vector3(-7.6f, 1.6f, 0);
    [SerializeField] Vector3 startOpponentCardPos = new Vector3(-7.8f, -2, 0);

    [SerializeField] Vector3 cardSpacing = new Vector3(2.0f, 0, 0);
    [SerializeField] Vector3 cardScale = new Vector3(0.37f, 0.37f, 1);

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void PlayerReady_Method()
    {
        if (gameManager.player_Ready == true)
        {
            Debug.Log("Player is ready to play their cards");

            int col = 0;
            Debug.Log("Moving ALL chosen cards to their respective play area");
            Debug.Log("Moving player's cards to the play area");
            for (int i = 0; i <= gameManager.chosen_Cards.Count - 1; i++)
            {
                if (col == 5)
                {
                    col = 0;
                    startPlayerCardPos.y -= 1f;
                }
                gameManager.chosen_Cards[i].transform.SetParent(playerPlayArea.transform);

                gameManager.chosen_Cards[i].transform.localScale = cardScale;

                gameManager.chosen_Cards[i].GetComponent<SpriteRenderer>().sortingOrder = 1;

                gameManager.chosen_Cards[i].GetComponent<CardClass>().cardNoInteract = true;

                gameManager.chosen_Cards[i].transform.localPosition = startPlayerCardPos + (cardSpacing * col);
                col++;
            }
            Debug.Log("Player's cards have been moved to the play area");

            Debug.Log("Moving opponent's cards to the play area");
            for (int i = 0; i < gameManager.opponentsCardList.Count; i++)
            {
                if (col == 5)
                {
                    col = 0;
                    startOpponentCardPos.y += 1f;
                }
                gameManager.opponentsCardList[i].transform.SetParent(opponentPlayArea.transform);

                gameManager.opponentsCardList[i].transform.localScale = cardScale;

                gameManager.opponentsCardList[i].GetComponent<SpriteRenderer>().sortingOrder = 1;

                gameManager.opponentsCardList[i].GetComponent<CardClass>().cardNoInteract = true;

                gameManager.opponentsCardList[i].transform.localPosition = startOpponentCardPos + (cardSpacing * col);

                gameManager.opponentsCardList[i].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                col++;
            }
            Debug.Log("Opponent's cards have been moved to the play area");
        }
    }
}