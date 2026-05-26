using System.Drawing;
using System.Drawing.Drawing2D;

namespace DinoFight;

public partial class MainForm : Form
{
    // ── Estado batalla ────────────────────────────────────────────────────────
    private BattleEngine? _engine;
    private bool _battleRunning;
    private Dinosaur? _winner;

    // ── Estado apuestas ───────────────────────────────────────────────────────
    private int _playerChips = 100;
    private string? _betSelection;
    private int _betAmount;

    public MainForm()
    {
        InitializeComponent();
        ResetState();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Estado
    // ─────────────────────────────────────────────────────────────────────────
    private void ResetState()
    {
        var rex = new Dinosaur(
            name: "T-Rex",
            emoji: "🦖",
            health: 1000,
            minDamage: 10,
            maxDamage: 100,
            evasionChance: 0.25,
            color: "#50DC64");

        var spino = new Dinosaur(
            name: "Brachiosaurus",
            emoji: "🦕",
            health: 1000,
            minDamage: 10,
            maxDamage: 120,
            evasionChance: 0.20,
            color: "#FFAA1E");

        _engine = new BattleEngine(rex, spino);
        _battleRunning = false;
        _winner = null;

        RefreshCard(_lblNameA, _lblEmojiA, _lblHpA, _barBgA, _barFgA, _lblStatsA, rex, AccentA);
        RefreshCard(_lblNameB, _lblEmojiB, _lblHpB, _barBgB, _barFgB, _lblStatsB, spino, AccentB);

        _lblTurn.Text = "";
        _lblWinner.Text = "";

        _log.Clear();
        _log.BackColor = Color.FromArgb(12, 10, 8);
        _log.ForeColor = TextLight;

        LogLine("═══════════════════════════════════════════════════════", TextDim);
        LogLine("  🦕  Bienvenido al DINO FIGHT  🦖", Color.Gold);
        LogLine("  Presiona 🎰 APOSTAR primero, luego ⚔ INICIAR.", TextLight);
        LogLine("═══════════════════════════════════════════════════════", TextDim);

        _btnStart.Enabled = false;
        _btnStart.BackColor = Color.FromArgb(60, 60, 60);
        _btnReset.Enabled = true;

        _btnBet.Text = $"🎰  APOSTAR  ({_playerChips} fichas disponibles)";
        _btnBet.BackColor = Color.FromArgb(100, 70, 10);
        _btnBet.ForeColor = Color.White;
        _btnBet.Enabled = true;
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Tarjetas / HP
    // ─────────────────────────────────────────────────────────────────────────
    private static void RefreshCard(
        Label lblName,
        Label lblEmoji,
        Label lblHp,
        Panel barBg,
        Panel barFg,
        Label lblStats,
        Dinosaur dino,
        Color accent)
    {
        lblEmoji.Text = dino.Emoji;
        lblName.Text = dino.Name.ToUpper();

        UpdateHpDisplay(lblHp, barBg, barFg, dino, accent);

        lblStats.Text =
            $"⚔  Daño: {dino.MinDamage} – {dino.MaxDamage}\n" +
            $"🛡  Evasión: {dino.EvasionChance * 100:0}%\n" +
            $"❤  Vida inicial: {dino.MaxHealth:0}\n\n" +
            $"• Golpe máximo aturde al rival\n" +
            $"• Regen normal: 5% vida actual\n" +
            $"• Regen aturdido: 10% vida actual";
    }

    private static void UpdateHpDisplay(
        Label lblHp,
        Panel barBg,
        Panel barFg,
        Dinosaur dino,
        Color accent)
    {
        lblHp.Text = $"{dino.Health:0} / {dino.MaxHealth:0}";

        double pct = Math.Max(0, dino.HealthPercent / 100.0);

        barFg.Width = (int)(barBg.Width * pct);

        barFg.BackColor =
            pct > 0.5 ? accent :
            pct > 0.25 ? Color.Orange :
            Color.FromArgb(220, 40, 40);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Eventos botones
    // ─────────────────────────────────────────────────────────────────────────
    private void BtnBet_Click(object? sender, EventArgs e)
    {
        using var bet = new BettingForm(_playerChips);

        if (bet.ShowDialog(this) != DialogResult.OK)
            return;

        _betSelection = bet.SelectedDino;
        _betAmount = bet.BetAmount;

        string dinoName =
            _betSelection == "A"
            ? "T-Rex 🦖"
            : "Brachiosaurus 🦕";

        _btnBet.Text =
            $"🎰  {_betAmount} fichas por {dinoName}  (cambiar)";

        _btnBet.BackColor =
            _betSelection == "A"
            ? AccentA
            : AccentB;

        _btnBet.ForeColor = Color.Black;

        _btnStart.Enabled = true;
        _btnStart.BackColor = AccentBtn;

        LogLine(
            $"  🎰 Apuesta registrada: {_betAmount} fichas por {dinoName}",
            Color.Gold);
    }

    private void BtnStart_Click(object? sender, EventArgs e)
    {
        if (_engine == null || _betSelection == null)
            return;

        _battleRunning = true;

        _btnStart.Enabled = false;
        _btnStart.BackColor = Color.FromArgb(60, 60, 60);

        _btnBet.Enabled = false;
        _btnReset.Enabled = false;

        LogLine("");
        LogLine("⚔  ¡QUE COMIENCE LA BATALLA!", AccentBtn);
        LogLine("───────────────────────────────────────────────────────", TextDim);

        _timer.Start();
    }

    private void BtnReset_Click(object? sender, EventArgs e)
    {
        _timer.Stop();

        _betSelection = null;
        _betAmount = 0;

        ResetState();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Timer
    // ─────────────────────────────────────────────────────────────────────────
    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_engine == null || _engine.IsOver)
        {
            _timer.Stop();
            return;
        }

        var result = _engine.SimulateNextTurn();

        if (result == null)
        {
            _timer.Stop();
            return;
        }

        _lblTurn.Text = $"TURNO {result.TurnNumber}";

        UpdateHpDisplay(
            _lblHpA,
            _barBgA,
            _barFgA,
            _engine.DinoA,
            AccentA);

        UpdateHpDisplay(
            _lblHpB,
            _barBgB,
            _barFgB,
            _engine.DinoB,
            AccentB);

        LogLine($"\n── Turno {result.TurnNumber} ─────────────────────", TextDim);

        foreach (var ev in result.Events)
            LogTurnEvent(ev, _engine.DinoA, _engine.DinoB);

        if (_engine.IsOver)
        {
            _timer.Stop();
            ShowWinner();
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Eventos batalla
    // ─────────────────────────────────────────────────────────────────────────
    private void LogTurnEvent(TurnEvent ev, Dinosaur dinoA, Dinosaur dinoB)
    {
        var attackerColor =
            ev.AttackerName == dinoA.Name
            ? AccentA
            : AccentB;

        var defenderColor =
            ev.AttackerName == dinoA.Name
            ? AccentB
            : AccentA;

        switch (ev.Type)
        {
            case TurnEventType.Stunned:

                LogLine(
                    $"😵 {ev.AttackerName} está aturdido.",
                    attackerColor);

                break;

            case TurnEventType.Evaded:

                LogLine(
                    $"💨 {ev.DefenderName} esquivó el ataque.",
                    defenderColor);

                break;

            case TurnEventType.MaxHit:

                LogLine(
                    $"💥 GOLPE MÁXIMO de {ev.AttackerName}",
                    attackerColor);

                LogLine(
                    $"→ {ev.DamageTaken} daño",
                    Color.White);

                break;

            case TurnEventType.NormalHit:

                LogLine(
                    $"⚔ {ev.AttackerName} golpea a {ev.DefenderName}",
                    attackerColor);

                LogLine(
                    $"→ {ev.DamageTaken} daño",
                    Color.White);

                break;
        }
    }

    private void ShowWinner()
    {
        _winner = _engine?.Winner();

        _btnReset.Enabled = true;

        LogLine("");
        LogLine("═══════════════════════════════════════════════════════", Color.Gold);

        if (_winner != null)
        {
            LogLine(
                $"🏆 {_winner.Name.ToUpper()} GANA LA BATALLA",
                Color.Gold);

            _lblWinner.Text =
                $"🏆 {_winner.Name} GANA";
        }
        else
        {
            LogLine("💀 EMPATE", TextLight);

            _lblWinner.Text = "💀 EMPATE";
        }

        LogLine("═══════════════════════════════════════════════════════", Color.Gold);

        if (_betSelection != null)
        {
            string winnerKey =
                _winner == null
                ? "TIE"
                : _winner == _engine?.DinoA ? "A" : "B";

            using var result = new BetResultForm(
                _betSelection,
                winnerKey,
                _betAmount,
                _playerChips);

            result.ShowDialog(this);

            _playerChips = result.ChipsAfter;

            _betSelection = null;
            _betAmount = 0;

            if (_playerChips <= 0)
            {
                _btnBet.Text = "💀 Sin fichas";
                _btnBet.BackColor = Color.DarkRed;
                _btnBet.Enabled = false;
            }
            else
            {
                _btnBet.Text =
                    $"🎰  APOSTAR  ({_playerChips} fichas disponibles)";

                _btnBet.BackColor =
                    Color.FromArgb(100, 70, 10);

                _btnBet.Enabled = true;
            }
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Log
    // ─────────────────────────────────────────────────────────────────────────
    private void LogLine(string text, Color? color = null)
    {
        _log.SelectionStart = _log.TextLength;
        _log.SelectionLength = 0;

        _log.SelectionColor = color ?? TextLight;

        _log.AppendText(text + Environment.NewLine);

        _log.SelectionColor = TextLight;

        _log.ScrollToCaret();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Paint
    // ─────────────────────────────────────────────────────────────────────────
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using (LinearGradientBrush brush =
            new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(10, 10, 10),
                Color.FromArgb(35, 20, 5),
                90F))
        {
            g.FillRectangle(brush, ClientRectangle);
        }

        using var pen =
            new Pen(Color.FromArgb(12, 255, 255, 255), 1);

        for (int y = 0; y < ClientSize.Height; y += 4)
        {
            g.DrawLine(
                pen,
                0,
                y,
                ClientSize.Width,
                y);
        }
    }
}