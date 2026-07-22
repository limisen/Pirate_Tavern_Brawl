using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] Text coins;
    [SerializeField] Text player_health_counter;
    [SerializeField] Animator purse;
    [SerializeField] Button confirmButton;
    [SerializeField] GameObject BuyButtons;
    CameraSwitch cameraSwitch;


    public void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
    }

    public void UpdatdeUIText()
    {
        coins.text = gameManager.coins_Available.ToString();
        player_health_counter.text = gameManager.player_HP.ToString();
    }

    public void buttonPress()
    {
        Debug.Log("Do stuffs");
        gameManager.player_Ready = true;
    }
}