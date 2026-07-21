using UnityEngine;

public class CardClass : MonoBehaviour
{
    public enum Conditions
    {
        none, No_Attacks, No_Defends
    }
    public string Name_Of_Card;
    public int Cost_of_Card;
    public Sprite Card_Portrait;
    public string Card_Description;
    public Conditions condition;
}