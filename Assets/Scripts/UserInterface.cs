using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] Text coins;
    [SerializeField] Text player_health_counter;
    [SerializeField] Animator purse;
    [SerializeField] Button confirmButton;


    public void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void UpdatdeUIText()
    {
        coins.text = gameManager.coins_Available.ToString();
        player_health_counter.text = gameManager.player_HP.ToString();
    }

    public void buttonPress()
    {
        Debug.Log("Do stuffs");
    }
}