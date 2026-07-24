using UnityEngine;

public class D6_DiceRoll : MonoBehaviour
{
    [SerializeField] int dice_Roll_Debug_Value = 0; // for testing purposes, set this value to a number between 1 and 6 to simulate a dice roll
    public int RollD6()
    {
        // get the animator controller components dice_value in order to set the animation/frame to the correct dice value rolled
        Animator animator = GetComponent<Animator>();

        int diceRoll = Random.Range(1, 7);
        Debug.Log("D6 Dice Roll Result: " + diceRoll);
        Debug.Log("D6 Debug Dice Roll Result: " + dice_Roll_Debug_Value);

        if (diceRoll == 1 || dice_Roll_Debug_Value == 1)
        {
            animator.SetInteger("DiceValue", 1);
            Debug.Log("You rolled a 1! Critical fail!");
            return diceRoll;
        }
        else if (diceRoll == 2 || dice_Roll_Debug_Value == 2)
        {
            animator.SetInteger("DiceValue", 2);
            Debug.Log("You rolled a 2! Not great.");
            return diceRoll;
        }
        else if (diceRoll == 3 || dice_Roll_Debug_Value == 3)
        {
            animator.SetInteger("DiceValue", 3);
            Debug.Log("You rolled a 3! Average roll.");
            return diceRoll;
        }
        else if (diceRoll == 4 || dice_Roll_Debug_Value == 4)
        {
            animator.SetInteger("DiceValue", 4);
            Debug.Log("You rolled a 4! Good roll.");
            return diceRoll;
        }
        else if (diceRoll == 5 || dice_Roll_Debug_Value == 5)
        {
            animator.SetInteger("DiceValue", 5);
            Debug.Log("You rolled a 5! Great roll!");
            return diceRoll;
        }
        else if (diceRoll == 6 || dice_Roll_Debug_Value == 6)
        {
            animator.SetInteger("DiceValue", 6);
            Debug.Log("You rolled a 6! Critical success!");
            return diceRoll;
        }
        else
        {
            Debug.LogError("Invalid dice roll value: " + diceRoll);
            return 0;
        }
    }
}
