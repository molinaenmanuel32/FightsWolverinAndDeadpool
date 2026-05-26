using System.Drawing;
using System.Windows.Forms;

namespace DinoFight;

public partial class BetResultForm : Form
{
    private static readonly Color BgDark =
        Color.FromArgb(15, 12, 8);

    private static readonly Color BgCard =
        Color.FromArgb(38, 30, 18);

    private static readonly Color AccentA =
        Color.FromArgb(80, 220, 100);

    private static readonly Color AccentB =
        Color.FromArgb(255, 170, 30);

    private static readonly Color TextLight =
        Color.FromArgb(240, 230, 200);

    private static readonly Color TextDim =
        Color.FromArgb(140, 125, 100);

    public int ChipsAfter { get; private set; }

    public BetResultForm(
        string betOnDino,
        string winnerDino,
        int betAmount,
        int chipsBefore)
    {
        InitializeComponent();

        bool tie = winnerDino == "TIE";
        bool won = !tie && betOnDino == winnerDino;

        int payout = tie
            ? 0
            : won
                ? (int)(betAmount * 1.9)
                : -betAmount;

        ChipsAfter = tie
            ? chipsBefore
            : Math.Max(
                0,
                chipsBefore + (won
                    ? payout - betAmount
                    : payout));

        string betName =
            betOnDino == "A"
                ? "T-Rex 🦖"
                : "Brachiosaurus 🦕";

        string winnerName =
            winnerDino == "A"
                ? "T-Rex 🦖"
                : winnerDino == "B"
                    ? "Brachiosaurus 🦕"
                    : "EMPATE 💀";

        Color accentColor =
            tie
                ? TextDim
                : won
                    ? AccentA
                    : Color.FromArgb(220, 80, 60);

        string mainEmoji =
            tie
                ? "💀"
                : won
                    ? "🏆"
                    : "💸";

        string headline =
            tie
                ? "¡EMPATE!"
                : won
                    ? "¡GANASTE LA APUESTA!"
                    : "PERDISTE LA APUESTA";

        Text = "🎰 Resultado de la apuesta";

        SetupUI(
            mainEmoji,
            headline,
            accentColor,
            betName,
            winnerName,
            betAmount,
            payout,
            won,
            tie);
    }

    private void SetupUI(
        string mainEmoji,
        string headline,
        Color accentColor,
        string betName,
        string winnerName,
        int betAmount,
        int payout,
        bool won,
        bool tie)
    {
        lblEmoji.Text = mainEmoji;
        lblEmoji.Font =
            new System.Drawing.Font(
                "Segoe UI",
                48F);

        lblEmoji.ForeColor = accentColor;

        lblHeadline.Text = headline;
        lblHeadline.Font =
            new System.Drawing.Font(
                "Segoe UI",
                18F,
                FontStyle.Bold);

        lblHeadline.ForeColor = accentColor;

        AddRow(
            "Apostaste por:",
            betName,
            8,
            TextLight);

        AddRow(
            "Ganador:",
            winnerName,
            36,
            accentColor);

        AddRow(
            "Apuesta:",
            $"{betAmount} fichas",
            64,
            TextLight);

        AddRow(
            won
                ? "Ganancia:"
                : tie
                    ? "Resultado:"
                    : "Pérdida:",

            tie
                ? "Apuesta devuelta"
                : won
                    ? $"+{payout - betAmount} fichas"
                    : $"-{betAmount} fichas",

            92,
            accentColor);

        lblTotal.Text =
            $"💰 Fichas totales: {ChipsAfter}";

        lblTotal.Font =
            new System.Drawing.Font(
                "Segoe UI",
                12F,
                FontStyle.Bold);

        lblTotal.ForeColor = Color.Gold;

        btnClose.Text =
            ChipsAfter > 0
                ? "Volver a apostar →"
                : "Sin fichas — Reiniciar";

        btnClose.Font =
            new System.Drawing.Font(
                "Segoe UI",
                10F,
                FontStyle.Bold);

        btnClose.ForeColor =
            Color.FromArgb(15, 12, 8);

        btnClose.BackColor =
            ChipsAfter > 0
                ? accentColor
                : TextDim;

        btnClose.FlatAppearance.BorderSize = 0;

        btnClose.Click += (_, _) =>
        {
            DialogResult = DialogResult.OK;
            Close();
        };
    }

    private void AddRow(
        string label,
        string value,
        int y,
        Color valueColor)
    {
        var lblLabel = new Label
        {
            Text = label,
            ForeColor = TextDim,
            BackColor = Color.Transparent,
            Size = new Size(160, 24),
            Location = new Point(12, y),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new System.Drawing.Font(
                "Segoe UI",
                9F)
        };

        var lblValue = new Label
        {
            Text = value,
            ForeColor = valueColor,
            BackColor = Color.Transparent,
            Size = new Size(176, 24),
            Location = new Point(172, y),
            TextAlign = ContentAlignment.MiddleRight,
            Font = new System.Drawing.Font(
                "Segoe UI",
                9F,
                FontStyle.Bold)
        };

        card.Controls.Add(lblLabel);
        card.Controls.Add(lblValue);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using var pen =
            new Pen(
                Color.FromArgb(8, 255, 255, 255),
                1);

        for (int y = 0;
             y < ClientSize.Height;
             y += 4)
        {
            e.Graphics.DrawLine(
                pen,
                0,
                y,
                ClientSize.Width,
                y);
        }
    }
}