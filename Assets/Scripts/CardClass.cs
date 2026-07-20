using UnityEngine;

public class CardClass : MonoBehaviour
{
    public enum Conditions 
    {
        none, No_Attack, No_Defends
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
        public Conditions card_condition;

        public Defence(int Def, int Cost, Conditions con)
        {
            Defence_Value = Def; 
            Cost_of_Card = Cost;
            card_condition = con;
        }
    }

    public class Special : CardClass
    {
        public Conditions card_condition;
        public Special(int Cost, Conditions con)
        {
            Cost_of_Card = Cost;
            card_condition = con;
        }
    }
}
