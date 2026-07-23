using System;
using UnityEngine;

public class PlayerReady : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject playArea;

    [SerializeField] Vector3 startPos = new Vector3(-0.437000006f, 0.282000005f, 0);
    [SerializeField] Vector3 cardSpacing = new Vector3(0.14f, 0, 0);
    [SerializeField] Vector3 cardScale = new Vector3(0.03f, 0.08f, 0.4f);
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
            // Move the chosen cards to the play area and set their position
            for (int i = 0; i <= gameManager.chosen_Cards.Count - 1; i++)
            {
                if (col == 6)
                {
                    col = 0;
                    startPos.y -= 0.3f;
                }
                gameManager.chosen_Cards[i].transform.SetParent(playArea.transform);
                gameManager.chosen_Cards[i].GetComponent<CardClass>().cardNoInteract = true;

                gameManager.chosen_Cards[i].transform.localScale = cardScale;
                gameManager.chosen_Cards[i].transform.localPosition = startPos + (cardSpacing * col);
                col++;
            }
        }
    }
}