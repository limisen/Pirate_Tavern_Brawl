public class AttackCard : CardClass
{
    public int Damage;
    public void Attack(int DMG, int Cost, CardClass.Conditions con)
    {
        Damage = DMG;
        Cost_of_Card = Cost;
        condition = con;
    }
}