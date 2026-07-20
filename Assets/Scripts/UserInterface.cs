using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    
    GameManager gameManager;
    

    [SerializeField] Text coins;
    [SerializeField] Text player_health_counter;
    [SerializeField] Animator purse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        player_health_counter.text = gameManager.player_HP.ToString();
        coins.text = gameManager.coins_Available.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
