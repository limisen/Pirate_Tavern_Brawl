using UnityEngine;

public class CardClass : MonoBehaviour
{
    public enum Conditions 
    {
        none, No_Attack
    }
    public string Name_Of_Card;
    public int Cost_of_Card;
    public string Card_Description;
    public Sprite Card_Portrait;
    public Conditions condition;

    public class Attack : CardClass
    {
        public int Damage;

        public Attack(int DMG, int Cost, Conditions con)
        {
            Damage = DMG; 
            Cost_of_Card = Cost;
            condition = con;
        }
    }
    public class Defence : CardClass
    {
        public int Defence_Value;

        public Defence(int Def, int Cost)
        {
            Defence_Value = Def; 
            Cost_of_Card = Cost;
        }
    }
}
