using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DinoFight;

public partial class BettingForm : Form
{
    public string? SelectedDino { get; private set; }
    public int BetAmount { get; private set; }

    protected static readonly Color BgDark =
        Color.FromArgb(15, 12, 8);

    protected static readonly Color BgCard =
        Color.FromArgb(38, 30, 18);

    protected static readonly Color AccentA =
        Color.FromArgb(80, 220, 100);

    protected static readonly Color AccentB =
        Color.FromArgb(255, 170, 30);

    protected static readonly Color TextLight =
        Color.FromArgb(240, 230, 200);

    protected static readonly Color TextDim =
        Color.FromArgb(140, 125, 100);

    private readonly int _chips;
    private string? _picked;

    public BettingForm(int chips)
    {
        _chips = chips;

        InitializeComponent();

        DoubleBuffered = true;

        ApplyTheme();

        lblChips.Text = chips.ToString();

        SetupButtons();

        _numBet.Minimum = 1;
        _numBet.Maximum = chips;
        _numBet.Value = Math.Min(10, chips);

        _numBet.ValueChanged += (_, _) => UpdatePayout();

        btn10.Click += (_, _) => SetBet(10);
        btn25.Click += (_, _) => SetBet(25);
        btn50.Click += (_, _) => SetBet(50);
        btnAllIn.Click += (_, _) => SetBet(_chips);

        _btnA.Click += (_, _) => Pick("A");
        _btnB.Click += (_, _) => Pick("B");

        _btnConfirm.Click += BtnConfirm_Click;

        _btnConfirm.Enabled = false;
    }

    private void ApplyTheme()
    {
        BackColor = BgDark;

        Label[] labels =
        {
            lblTitle,
            lblSub,
            lblChipsTitle,
            lblChips,
            lblPick,
            lblBet,
            _lblPayout
        };

        foreach (Label lbl in labels)
        {
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = TextLight;
        }

        lblTitle.ForeColor = Color.Gold;
        lblChips.ForeColor = Color.Gold;

        lblSub.ForeColor = TextDim;
        lblPick.ForeColor = TextDim;
        lblBet.ForeColor = TextDim;
        lblChipsTitle.ForeColor = TextDim;

        _numBet.BackColor = BgCard;
        _numBet.ForeColor = TextLight;
        _numBet.BorderStyle = BorderStyle.FixedSingle;

        _btnConfirm.BackColor = Color.FromArgb(45, 45, 45);
        _btnConfirm.ForeColor = TextDim;

        _btnConfirm.FlatStyle = FlatStyle.Flat;
        _btnConfirm.FlatAppearance.BorderSize = 1;
        _btnConfirm.FlatAppearance.BorderColor =
            Color.FromArgb(80, 80, 80);
    }

    private void SetupButtons()
    {
        ConfigureDinoButton(
            _btnA,
            "🦖 T-Rex\n\nDaño: 10–100 | Evasión: 25%\n| Vida: 1000",
            AccentA);

        ConfigureDinoButton(
            _btnB,
            "🦕 Brachiosaurus\n\nDaño: 10–120 | Evasión: 20%\n| Vida: 1000",
            AccentB);

        ConfigureQuickButton(btn10, "10");
        ConfigureQuickButton(btn25, "25");
        ConfigureQuickButton(btn50, "50");
        ConfigureQuickButton(btnAllIn, "TODO");
    }

    private void ConfigureDinoButton(
        Button btn,
        string text,
        Color accent)
    {
        btn.Text = text;

        btn.Font =
            new System.Drawing.Font(
                "Segoe UI",
                9F,
                FontStyle.Bold);

        btn.ForeColor = TextLight;
        btn.BackColor = BgCard;

        btn.FlatStyle = FlatStyle.Flat;

        btn.Cursor = Cursors.Hand;

        btn.TextAlign =
            ContentAlignment.MiddleCenter;

        btn.FlatAppearance.BorderSize = 1;

        btn.FlatAppearance.BorderColor =
            Color.FromArgb(60, accent);

        btn.MouseEnter += (_, _) =>
        {
            btn.BackColor =
                Color.FromArgb(
                    Math.Min(accent.R + 20, 255),
                    Math.Min(accent.G + 20, 255),
                    Math.Min(accent.B + 20, 255));
        };

        btn.MouseLeave += (_, _) =>
        {
            if ((_picked == "A" && btn == _btnA) ||
                (_picked == "B" && btn == _btnB))
                return;

            btn.BackColor = BgCard;
        };
    }

    private void ConfigureQuickButton(
        Button btn,
        string text)
    {
        btn.Text = text;

        btn.BackColor = BgCard;

        btn.ForeColor = TextLight;

        btn.FlatStyle = FlatStyle.Flat;

        btn.Font =
            new System.Drawing.Font(
                "Segoe UI",
                8F,
                FontStyle.Bold);

        btn.FlatAppearance.BorderSize = 1;

        btn.FlatAppearance.BorderColor =
            Color.FromArgb(80, 80, 80);

        btn.Cursor = Cursors.Hand;

        btn.MouseEnter += (_, _) =>
        {
            btn.BackColor =
                Color.FromArgb(70, 50, 25);
        };

        btn.MouseLeave += (_, _) =>
        {
            btn.BackColor = BgCard;
        };
    }

    private void Pick(string dino)
    {
        _picked = dino;

        _btnA.BackColor =
            dino == "A"
            ? AccentA
            : BgCard;

        _btnB.BackColor =
            dino == "B"
            ? AccentB
            : BgCard;

        _btnA.ForeColor =
            dino == "A"
            ? Color.Black
            : TextLight;

        _btnB.ForeColor =
            dino == "B"
            ? Color.Black
            : TextLight;

        _btnConfirm.Enabled = true;

        _btnConfirm.BackColor =
            dino == "A"
            ? AccentA
            : AccentB;

        _btnConfirm.ForeColor = Color.Black;

        UpdatePayout();
    }

    private void UpdatePayout()
    {
        if (_picked == null)
            return;

        int bet = (int)_numBet.Value;

        int payout = (int)(bet * 1.9);

        string name =
            _picked == "A"
            ? "T-Rex"
            : "Brachiosaurus";

        _lblPayout.Text =
            $"Si {name} gana → cobras {payout} fichas";

        _lblPayout.ForeColor =
            _picked == "A"
            ? AccentA
            : AccentB;
    }

    private void SetBet(int n)
    {
        _numBet.Value =
            Math.Max(1, Math.Min(n, _chips));

        UpdatePayout();
    }

    private void BtnConfirm_Click(
        object? sender,
        EventArgs e)
    {
        SelectedDino = _picked;

        BetAmount =
            (int)_numBet.Value;

        Hide();

        MainForm main =
            new MainForm();

        main.ShowDialog();

        Close();
    }

    protected override void OnPaint(
        PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using LinearGradientBrush brush =
            new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(18, 18, 18),
                Color.FromArgb(45, 30, 10),
                90F);

        g.FillRectangle(
            brush,
            ClientRectangle);

        using Pen pen =
            new Pen(
                Color.FromArgb(
                    15,
                    255,
                    255,
                    255),
                1);

        for (int y = 0;
             y < ClientSize.Height;
             y += 4)
        {
            g.DrawLine(
                pen,
                0,
                y,
                ClientSize.Width,
                y);
        }
    }

    private void _btnConfirm_Click(object sender, EventArgs e)
    {
        SelectedDino = _picked;
        BetAmount = (int)_numBet.Value;
        DialogResult = DialogResult.OK;
        Close();
    }
}