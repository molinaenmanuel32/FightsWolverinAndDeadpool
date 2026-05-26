namespace DinoFight;

public class Dinosaur
{
    public string Name { get; private set; }
    public string Emoji { get; private set; }
    public double Health { get; private set; }
    public double MaxHealth { get; private set; }
    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public double EvasionChance { get; private set; }
    public bool SkipNextTurn { get; set; }
    public string Color { get; private set; }

    private static readonly Random _rng = new();

    public bool IsAlive => Health > 0;
    public double HealthPercent => Health / MaxHealth * 100.0;

    public Dinosaur(
        string name,
        string emoji,
        double health,
        int minDamage,
        int maxDamage,
        double evasionChance,
        string color)
    {
        Name = name;
        Emoji = emoji;
        Health = health;
        MaxHealth = health;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        EvasionChance = evasionChance;
        SkipNextTurn = false;
        Color = color;
    }

    public int RollDamage() => _rng.Next(MinDamage, MaxDamage + 1);
    public bool TryEvade() => _rng.NextDouble() < EvasionChance;

    public AttackResult ReceiveAttack(int incomingDamage, bool isMaxDamage)
    {
        // Evade check
        if (TryEvade())
            return new AttackResult(DamageTaken: 0, Evaded: true, Stunned: false, RegenAmount: 0);

        // Aplicar daño
        Health -= incomingDamage;
        Health = Math.Max(0, Health);

        bool stunned = false;
        double regenAmount = 0;

        if (isMaxDamage)
        {
            // Golpe máximo: aturde + regenera 10% de la vida ACTUAL
            SkipNextTurn = true;
            stunned = true;
            regenAmount = Health * 0.10;
        }
        else
        {
            // Golpe normal: regenera 5% de la vida ACTUAL
            regenAmount = Health * 0.05;
        }

        // Aplicar regeneración
        Health += regenAmount;
        Health = Math.Min(MaxHealth, Health);

        return new AttackResult(
            DamageTaken: incomingDamage,
            Evaded: false,
            Stunned: stunned,
            RegenAmount: regenAmount);
    }
}

public record AttackResult(
    int DamageTaken,
    bool Evaded,
    bool Stunned,
    double RegenAmount);