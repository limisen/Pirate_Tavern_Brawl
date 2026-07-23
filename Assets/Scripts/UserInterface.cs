using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] Text coins;
    [SerializeField] Animator purse;
    [SerializeField] Text player_health_counter;
    [SerializeField] Button confirmButton;
    [SerializeField] GameObject BuyButtons;

    // drinkarna
    [SerializeField] GameObject health_drink;
    [SerializeField] GameObject greed_drink;
    [SerializeField] GameObject fury_drink;
    CameraSwitch cameraSwitch;


    public void Start()
    {
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
    }

    public void UpdatdeUIText()
    {
        Debug.Log(coins);
        Debug.Log(gameManager);
        coins.text = gameManager.coins_Available.ToString();
        player_health_counter.text = gameManager.player_HP.ToString();
    }

    public void buttonPress()
    {
        Debug.Log("confirm button pressed");
        gameManager.player_Ready = true;
        FindAnyObjectByType<CameraSwitch>().SwitchToCamera("TopDown");
    }

    public void buyButtonOne(Button buttonOne)
    {
        Debug.Log("Knapp 1");
        health_drink.gameObject.SetActive(false);
        buttonOne.gameObject.SetActive(false);
    }

    public void buyButtonTwo(Button buttonTwo)
    {
        Debug.Log("Knapp 2");
        greed_drink.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);

    }

    public void buyButtonThree(Button buttonThree)
    {
        Debug.Log("Knapp 3");
        fury_drink.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);

    }
}