using System.Collections.Generic;
using UnityEngine;
using static CardClass;

public class PopulateCards : MonoBehaviour
{
    // Where the cards will be instantiated as children of this object
    [SerializeField, Tooltip("The parent object used for when instantiatig cards. (Cards get instantiated as children of this object)")] public GameObject ParentObject;

    [SerializeField] GameObject AttackCardPrefab;
    [SerializeField] List<Sprite> AttackCardPortrait;

    [SerializeField] GameObject DefenceCardPrefab;
    [SerializeField] List<Sprite> DefenceCardPortrait;

    [SerializeField] GameObject SpecialCardPrefab;
    [SerializeField] List<Sprite> SpecialCardPortrait;

    public int costs_Of_Card = 3;
    public void PopulateCardList()
    {
        // List of positons on the cardList for where the cards will be instantiated
        var positionsOnListOfCards = new Dictionary<int, Vector3>
        {
            [0] = new Vector3(0.56f, 0.47f, 0),
            [1] = new Vector3(2.7f, 0.47f, 0),
            [2] = new Vector3(4.82f, 0.47f, 0),
            [3] = new Vector3(0.6f, -2.5f, 0),
            [4] = new Vector3(2.67f, -2.57f, 0),
            [5] = new Vector3(4.77f, -2.52f, 0),
            [6] = new Vector3(0.6f, -5.44f, 0),
            [7] = new Vector3(2.7f, -5.48f, 0),
        };

        // Create the list of cards
        for (int i = 0; i < 8; i++)
        {
            // Randomly select a card type (0 = Attack, 1 = Defence, 2 = Special)
            int cardType = Random.Range(0, 3);

            if (cardType == 0) // Attack Card
            {
                GameObject Card = Instantiate(AttackCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                AttackCard attackCard = Card.GetComponent<AttackCard>();

                int attackPortraitIndex = Random.Range(0, AttackCardPortrait.Count);

                attackCard.Card_Portrait = AttackCardPortrait[attackPortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = attackCard.Card_Portrait;

                if (attackPortraitIndex == 0)
                {
                    attackCard.Name_Of_Card = "Shark_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 3;

                    attackCard.Card_Description = "Attack Card Description";

                    attackCard.Damage = Random.Range(1, 3);

                    attackCard.condition = Conditions.none;
                }
                else if (attackPortraitIndex == 1)
                {
                    attackCard.Name_Of_Card = "Cat_Malw_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 4;

                    attackCard.Card_Description = "Attack Card Description";

                    attackCard.Damage = Random.Range(2, 4);

                    attackCard.condition = Conditions.none;
                }
                else if (attackPortraitIndex == 2)
                {
                    attackCard.Name_Of_Card = "CatClaw_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 2;

                    attackCard.Card_Description = "Attack Card Description";

                    attackCard.Damage = Random.Range(1, 2);

                    attackCard.condition = Conditions.none;
                }
            } // end of if (cardType == 0) // Attack Card

            else if (cardType == 1) // Defence Card
            {
                GameObject Card = Instantiate(DefenceCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();

                int defencePortraitIndex = Random.Range(0, DefenceCardPortrait.Count);

                defenceCard.Card_Portrait = DefenceCardPortrait[defencePortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = defenceCard.Card_Portrait;

                if (defencePortraitIndex == 0)
                {
                    defenceCard.Name_Of_Card = "Mammoth_Defence_Card";
                    Card.name = defenceCard.Name_Of_Card;

                    defenceCard.Cost_of_Card = 4;

                    defenceCard.Card_Description = "Defence Card Description";

                    defenceCard.Defence_Value = Random.Range(1, 3);

                    defenceCard.condition = Conditions.none;
                }
                else if (defencePortraitIndex == 1)
                {
                    defenceCard.Name_Of_Card = "TurtleShield_Defence_Card";
                    Card.name = defenceCard.Name_Of_Card;

                    defenceCard.Cost_of_Card = 2;

                    defenceCard.Card_Description = "Defence Card Description";

                    defenceCard.Defence_Value = Random.Range(2, 4);

                    defenceCard.condition = Conditions.none;
                }
            } // end of else if (cardType == 1) // Defence Card

            else if (cardType == 2) // Special Card
            {
                GameObject Card = Instantiate(SpecialCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();

                int specialPortraitIndex = Random.Range(0, SpecialCardPortrait.Count);

                specialCard.Card_Portrait = SpecialCardPortrait[specialPortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = specialCard.Card_Portrait;

                if (specialPortraitIndex == 0)
                {
                    specialCard.Name_Of_Card = "FlintLockPistol_Special_Card";
                    Card.name = specialCard.Name_Of_Card;

                    specialCard.Cost_of_Card = 6;

                    specialCard.Card_Description = "Special Card Description";

                    //specialCard.Special_Effect = "Special Effect Description";

                    specialCard.condition = Conditions.none;
                }
                else if (specialPortraitIndex == 1)
                {
                    specialCard.Name_Of_Card = "Reflecitve_Mirror_Special_Card";
                    Card.name = specialCard.Name_Of_Card;

                    specialCard.Cost_of_Card = 6;

                    specialCard.Card_Description = "Reduces damage taken by the rolled value and reflects that amount back at the attacker, the remaining damage goes through as normal (unless blocked by another shield)";

                    //specialCard.Special_Effect = "Special Effect Description";

                    specialCard.condition = Conditions.none;
                }
            } // end of else if (cardType == 2) // Special Card
        }
    }

    public List<GameObject> PopulateOpponentCards()
    {
        List<GameObject> opponentsCards = new List<GameObject>();

        // Create the list of cards
        for (int i = 0; i < 8; i++)
        {
            // Randomly select a card type (0 = Attack, 1 = Defence, 2 = Special)
            int cardType = Random.Range(0, 3);

            if (cardType == 0) // Attack Card
            {
                GameObject Card = AttackCardPrefab;
                
                AttackCard attackCard = Card.GetComponent<AttackCard>();

                int attackPortraitIndex = Random.Range(0, AttackCardPortrait.Count);

                attackCard.Card_Portrait = AttackCardPortrait[attackPortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = attackCard.Card_Portrait;            

                if (attackPortraitIndex == 0)
                {
                    attackCard.Name_Of_Card = "Shark_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 3;

                    attackCard.Card_Description = "Attack Card Description";

                    attackCard.Damage = Random.Range(1, 3);

                    attackCard.condition = Conditions.none;
                }
                else if (attackPortraitIndex == 1)
                {
                    attackCard.Name_Of_Card = "Cat_Malw_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 4;

                    attackCard.Card_Description = "Attack Card Description";

                    attackCard.Damage = Random.Range(2, 4);

                    attackCard.condition = Conditions.none;
                }
                else if (attackPortraitIndex == 2)
                {
                    attackCard.Name_Of_Card = "CatClaw_Attack_Card";
                    Card.name = attackCard.Name_Of_Card;

                    attackCard.Cost_of_Card = 2;
                    
                    attackCard.Card_Description = "Attack Card Description";
                    
                    attackCard.Damage = Random.Range(1, 2);
                    
                    attackCard.condition = Conditions.none;
                }
                opponentsCards.Add(Card);
            } // end of if (cardType == 0) // Attack Card

            else if (cardType == 1) // Defence Card
            {
                GameObject Card = DefenceCardPrefab;

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();

                int defencePortraitIndex = Random.Range(0, DefenceCardPortrait.Count);

                defenceCard.Card_Portrait = DefenceCardPortrait[defencePortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = defenceCard.Card_Portrait;

                if (defencePortraitIndex == 0)
                {
                    defenceCard.Name_Of_Card = "Mammoth_Defence_Card";
                    Card.name = defenceCard.Name_Of_Card;

                    defenceCard.Cost_of_Card = 4;

                    defenceCard.Card_Description = "Defence Card Description";

                    defenceCard.Defence_Value = Random.Range(1, 3);

                    defenceCard.condition = Conditions.none;
                }
                else if (defencePortraitIndex == 1)
                {
                    defenceCard.Name_Of_Card = "TurtleShield_Defence_Card";
                    Card.name = defenceCard.Name_Of_Card;

                    defenceCard.Cost_of_Card = 2;

                    defenceCard.Card_Description = "Defence Card Description";

                    defenceCard.Defence_Value = Random.Range(2, 4);

                    defenceCard.condition = Conditions.none;
                }
                opponentsCards.Add(Card);
            } // end of else if (cardType == 1) // Defence Card

            else if (cardType == 2) // Special Card
            {
                GameObject Card = SpecialCardPrefab;

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();

                int specialPortraitIndex = Random.Range(0, SpecialCardPortrait.Count);

                specialCard.Card_Portrait = SpecialCardPortrait[specialPortraitIndex];
                Card.GetComponent<SpriteRenderer>().sprite = specialCard.Card_Portrait;

                if (specialPortraitIndex == 0)
                {
                    specialCard.Name_Of_Card = "FlintLockPistol_Special_Card";
                    Card.name = specialCard.Name_Of_Card;

                    specialCard.Cost_of_Card = 6;

                    specialCard.Card_Description = "Special Card Description";

                    //specialCard.Special_Effect = "Special Effect Description";

                    specialCard.condition = Conditions.none;
                }
                else if (specialPortraitIndex == 1)
                {
                    specialCard.Name_Of_Card = "Reflecitve_Mirror_Special_Card";
                    Card.name = specialCard.Name_Of_Card;

                    specialCard.Cost_of_Card = 6;

                    specialCard.Card_Description = "Reduces damage taken by the rolled value and reflects that amount back at the attacker, the remaining damage goes through as normal (unless blocked by another shield)";

                    //specialCard.Special_Effect = "Special Effect Description";

                    specialCard.condition = Conditions.none;
                }
                opponentsCards.Add(Card);
            } // end of else if (cardType == 2) // Special Card
        }
        return opponentsCards;
    }
}