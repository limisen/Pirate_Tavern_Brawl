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

    // Power-Ups at the Bar
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
        Debug.Log("Buy Health Drink");
        health_drink.gameObject.SetActive(false);
        buttonOne.gameObject.SetActive(false);
    }

    public void buyButtonTwo(Button buttonTwo)
    {
        Debug.Log("Buy Greed Drink");
        greed_drink.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);

    }

    public void buyButtonThree(Button buttonThree)
    {
        Debug.Log("Buy Fury Drink");
        fury_drink.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);

    }
    public void doneWithCheckingResults()
    {
        if (gameManager.opponent_HP > 0)
        {
            Debug.Log("Changing Camera To TableView");
            cameraSwitch.SwitchToCamera("TableView");
            gameManager.player_ReadyToReturn = true;
        } 
        else if (gameManager.opponent_HP <= 0)
        {
            Debug.Log("Changing Camera To BarView");
            cameraSwitch.SwitchToCamera("BarView");
            gameManager.player_ReadyToReturn = true;
        }
    }
}