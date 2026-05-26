namespace DinoFight;

public class BattleEngine
{
    public Dinosaur DinoA { get; private set; }
    public Dinosaur DinoB { get; private set; }
    public int Turn { get; private set; }
    public bool IsOver => !DinoA.IsAlive || !DinoB.IsAlive;

    public event Action<TurnResult>? TurnCompleted;

    public BattleEngine(Dinosaur dinoA, Dinosaur dinoB)
    {
        DinoA = dinoA;
        DinoB = dinoB;
        Turn = 0;
    }

    public TurnResult? SimulateNextTurn()
    {
        if (IsOver) return null;

        Turn++;
        var events = new List<TurnEvent>();

        ProcessAttack(DinoA, DinoB, events);

        if (!DinoB.IsAlive)
        {
            var r = new TurnResult(Turn, events, DinoA.Health, DinoB.Health, DinoA, DinoB);
            TurnCompleted?.Invoke(r);
            return r;
        }

        ProcessAttack(DinoB, DinoA, events);

        var result = new TurnResult(Turn, events, DinoA.Health, DinoB.Health, DinoA, DinoB);
        TurnCompleted?.Invoke(result);
        return result;
    }

    private static void ProcessAttack(Dinosaur attacker, Dinosaur defender, List<TurnEvent> events)
    {
        if (attacker.SkipNextTurn)
        {
            attacker.SkipNextTurn = false;
            events.Add(new TurnEvent(attacker.Name, defender.Name,
                TurnEventType.Stunned, 0, false, false, 0));
            return;
        }

        int dmg = attacker.RollDamage();
        bool isMax = dmg == attacker.MaxDamage;
        var res = defender.ReceiveAttack(dmg, isMax);

        events.Add(new TurnEvent(
            attacker.Name, defender.Name,
            res.Evaded ? TurnEventType.Evaded :
            res.Stunned ? TurnEventType.MaxHit : TurnEventType.NormalHit,
            res.DamageTaken, res.Evaded, res.Stunned, res.RegenAmount));
    }

    public Dinosaur? Winner()
    {
        if (!IsOver) return null;
        if (!DinoA.IsAlive && !DinoB.IsAlive) return null;
        return DinoA.IsAlive ? DinoA : DinoB;
    }
}

public enum TurnEventType { NormalHit, MaxHit, Evaded, Stunned }

public record TurnEvent(
    string AttackerName,
    string DefenderName,
    TurnEventType Type,
    int DamageTaken,
    bool Evaded,
    bool Stunned,
    double RegenAmount);

public record TurnResult(
    int TurnNumber,
    List<TurnEvent> Events,
    double HealthA,
    double HealthB,
    Dinosaur DinoA,
    Dinosaur DinoB);