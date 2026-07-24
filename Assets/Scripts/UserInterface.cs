using Unity.VisualScripting;
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

    // Enemy stuffs

    [SerializeField] Text enemy_health_counter;

    // Power-Ups at the Bar
    [SerializeField] GameObject health_drink;
    [SerializeField] GameObject greed_drink;
    [SerializeField] GameObject fury_drink;

    [SerializeField] Image opponentHealthbar;
    [SerializeField] Sprite[] healthBar;
    public int debugIndex = 1;

    CameraSwitch cameraSwitch;


    public void Start()
    {
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
    }

    public void UpdatdeUIText()
    {
        coins.text = gameManager.coins_Available.ToString();
        player_health_counter.text = gameManager.player_HP.ToString();
        enemy_health_counter.text = gameManager.opponent_HP.ToString();
        UpdateUI_health(gameManager.opponent_HP, 30);
    }

    public void UpdateUI_health(int HP, int maxHP)
    {
        // Alvin's probalby good code but unnessesary 
        //Debug.Log("Opponent HP" + HP.ToString());
        //float hpRatio = maxHP / HP;
        //Debug.Log("Ratio" + hpRatio.ToString());
        //int spriteI = Mathf.Clamp(Mathf.Floor(healthBar.Length * hpRatio), 0f, healthBar.Length - 1).ConvertTo<int>();
        //Debug.Log("SpriteI" + spriteI.ToString());
        //opponentHealthbar.sprite = healthBar[spriteI];

        Debug.Log("pre division: " + HP.ToString());
        HP = (HP / 2); // use for normal play
        //HP = (debugIndex / 2); // use for debug purposes
        Debug.Log("post division: "+ HP.ToString());

        //opponentHealthbar.sprite = healthBar[HP]; //use this one for debugging, min value 0, max 14
        opponentHealthbar.sprite = healthBar[HP - 1]; //use this one for normal play min value 0, max 14
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