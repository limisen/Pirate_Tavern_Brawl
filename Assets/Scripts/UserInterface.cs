using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
public int coinCount = 0;
    [SerializeField] Text coins;
    [SerializeField] Image purse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        coinCount = 50;
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = coinCount.ToString();
    }
}
