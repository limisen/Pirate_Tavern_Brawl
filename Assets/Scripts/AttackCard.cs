public class AttackCard : CardClass
{
    public int minDamage;
    public int maxDamage;
    public void Attack(int minDMG, int maxDMG, int Cost, CardClass.Conditions con)
    {
        minDamage = minDMG;
        maxDamage = maxDMG;
        Cost_of_Card = Cost;
        condition = con;
    }
}