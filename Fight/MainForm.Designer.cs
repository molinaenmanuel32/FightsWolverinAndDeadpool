namespace DinoFight;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null!;

    // ── Palette ───────────────────────────────────────────────────────────────
    private static readonly Color BgDark = Color.FromArgb(15, 12, 8);
    private static readonly Color BgMid = Color.FromArgb(28, 22, 14);
    private static readonly Color BgCard = Color.FromArgb(38, 30, 18);
    private static readonly Color AccentA = Color.FromArgb(80, 220, 100);
    private static readonly Color AccentB = Color.FromArgb(255, 170, 30);
    private static readonly Color AccentBtn = Color.FromArgb(220, 60, 40);
    private static readonly Color TextLight = Color.FromArgb(240, 230, 200);
    private static readonly Color TextDim = Color.FromArgb(140, 125, 100);

    // ── Controls ──────────────────────────────────────────────────────────────
    private Panel _cardA = null!;
    private Panel _cardB = null!;
    private Panel _vsPanel = null!;
    private Label _lblNameA = null!;
    private Label _lblNameB = null!;
    private Label _lblHpA = null!;
    private Label _lblHpB = null!;
    private Panel _barBgA = null!;
    private Panel _barFgA = null!;
    private Panel _barBgB = null!;
    private Panel _barFgB = null!;
    private Label _lblEmojiA = null!;
    private Label _lblEmojiB = null!;
    private Label _lblStatsA = null!;
    private Label _lblStatsB = null!;
    private RichTextBox _log = null!;
    private Button _btnStart = null!;
    private Button _btnReset = null!;
    private Button _btnBet = null!;
    private Label _lblTurn = null!;
    private Label _lblWinner = null!;
    private Label _lblVs = null!;
    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private System.Windows.Forms.Timer _timer = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _lblTurn = new Label();
        _lblWinner = new Label();
        _lblEmojiA = new Label();
        _lblNameA = new Label();
        _lblHpA = new Label();
        _barFgA = new Panel();
        _barBgA = new Panel();
        _lblStatsA = new Label();
        _cardA = new Panel();
        _lblEmojiB = new Label();
        _lblNameB = new Label();
        _lblHpB = new Label();
        _barFgB = new Panel();
        _barBgB = new Panel();
        _lblStatsB = new Label();
        _cardB = new Panel();
        _lblVs = new Label();
        _vsPanel = new Panel();
        _log = new RichTextBox();
        _btnStart = new Button();
        _btnReset = new Button();
        _btnBet = new Button();
        _timer = new System.Windows.Forms.Timer(components);
        lblTitle = new Label();
        lblSubtitle = new Label();

        _barBgA.SuspendLayout();
        _cardA.SuspendLayout();
        _barBgB.SuspendLayout();
        _cardB.SuspendLayout();
        _vsPanel.SuspendLayout();
        SuspendLayout();

        // ── _lblTurn ──────────────────────────────────────────────────────────
        _lblTurn.BackColor = Color.Transparent;
        _lblTurn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        _lblTurn.Location = new Point(0, 93);
        _lblTurn.Name = "_lblTurn";
        _lblTurn.Size = new Size(850, 29);
        _lblTurn.TabIndex = 2;
        _lblTurn.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblWinner ────────────────────────────────────────────────────────
        _lblWinner.BackColor = Color.Transparent;
        _lblWinner.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        _lblWinner.ForeColor = Color.Gold;
        _lblWinner.Location = new Point(0, 120);
        _lblWinner.Name = "_lblWinner";
        _lblWinner.Size = new Size(850, 35);
        _lblWinner.TabIndex = 3;
        _lblWinner.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblEmojiA ────────────────────────────────────────────────────────
        _lblEmojiA.BackColor = Color.Transparent;
        _lblEmojiA.Font = new Font("Segoe UI", 52F);
        _lblEmojiA.Location = new Point(0, 13);
        _lblEmojiA.Name = "_lblEmojiA";
        _lblEmojiA.Size = new Size(263, 93);
        _lblEmojiA.TabIndex = 0;
        _lblEmojiA.Text = "\U0001f996";
        _lblEmojiA.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblNameA ─────────────────────────────────────────────────────────
        _lblNameA.BackColor = Color.Transparent;
        _lblNameA.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        _lblNameA.Location = new Point(0, 109);
        _lblNameA.Name = "_lblNameA";
        _lblNameA.Size = new Size(263, 35);
        _lblNameA.TabIndex = 1;
        _lblNameA.Text = "T-REX";
        _lblNameA.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblHpA ───────────────────────────────────────────────────────────
        _lblHpA.BackColor = Color.Transparent;
        _lblHpA.Font = new Font("Segoe UI", 10F);
        _lblHpA.Location = new Point(0, 144);
        _lblHpA.Name = "_lblHpA";
        _lblHpA.Size = new Size(263, 27);
        _lblHpA.TabIndex = 2;
        _lblHpA.Text = "1000 / 1000";
        _lblHpA.TextAlign = ContentAlignment.MiddleCenter;

        // ── _barFgA ───────────────────────────────────────────────────────────
        _barFgA.Location = new Point(0, 0);
        _barFgA.Margin = new Padding(3, 4, 3, 4);
        _barFgA.Name = "_barFgA";
        _barFgA.Size = new Size(226, 29);
        _barFgA.TabIndex = 0;

        // ── _barBgA ───────────────────────────────────────────────────────────
        _barBgA.BackColor = Color.FromArgb(40, 40, 40);
        _barBgA.Controls.Add(_barFgA);
        _barBgA.Location = new Point(18, 176);
        _barBgA.Margin = new Padding(3, 4, 3, 4);
        _barBgA.Name = "_barBgA";
        _barBgA.Size = new Size(226, 29);
        _barBgA.TabIndex = 3;

        // ── _lblStatsA ────────────────────────────────────────────────────────
        _lblStatsA.BackColor = Color.Transparent;
        _lblStatsA.Font = new Font("Segoe UI", 8.5F);
        _lblStatsA.Location = new Point(0, 219);
        _lblStatsA.Name = "_lblStatsA";
        _lblStatsA.Size = new Size(263, 187);
        _lblStatsA.TabIndex = 4;
        _lblStatsA.Text = "⚔  Daño: 10 – 100\n🛡  Evasión: 25%\n❤  Vida: 1000";
        _lblStatsA.TextAlign = ContentAlignment.MiddleCenter;

        // ── _cardA ────────────────────────────────────────────────────────────
        _cardA.Controls.Add(_lblEmojiA);
        _cardA.Controls.Add(_lblNameA);
        _cardA.Controls.Add(_lblHpA);
        _cardA.Controls.Add(_barBgA);
        _cardA.Controls.Add(_lblStatsA);
        _cardA.Location = new Point(18, 160);
        _cardA.Margin = new Padding(3, 4, 3, 4);
        _cardA.Name = "_cardA";
        _cardA.Size = new Size(263, 427);
        _cardA.TabIndex = 4;
        _cardA.Paint += CardA_Paint;

        // ── _lblEmojiB ────────────────────────────────────────────────────────
        _lblEmojiB.BackColor = Color.Transparent;
        _lblEmojiB.Font = new Font("Segoe UI", 52F);
        _lblEmojiB.Location = new Point(0, 13);
        _lblEmojiB.Name = "_lblEmojiB";
        _lblEmojiB.Size = new Size(263, 93);
        _lblEmojiB.TabIndex = 0;
        _lblEmojiB.Text = "\U0001f995";
        _lblEmojiB.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblNameB ─────────────────────────────────────────────────────────
        _lblNameB.BackColor = Color.Transparent;
        _lblNameB.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        _lblNameB.Location = new Point(0, 109);
        _lblNameB.Name = "_lblNameB";
        _lblNameB.Size = new Size(263, 35);
        _lblNameB.TabIndex = 1;
        _lblNameB.Text = "BRACHIOSAURUS";
        _lblNameB.TextAlign = ContentAlignment.MiddleCenter;

        // ── _lblHpB ───────────────────────────────────────────────────────────
        _lblHpB.BackColor = Color.Transparent;
        _lblHpB.Font = new Font("Segoe UI", 10F);
        _lblHpB.Location = new Point(0, 144);
        _lblHpB.Name = "_lblHpB";
        _lblHpB.Size = new Size(263, 27);
        _lblHpB.TabIndex = 2;
        _lblHpB.Text = "1000 / 1000";
        _lblHpB.TextAlign = ContentAlignment.MiddleCenter;

        // ── _barFgB ───────────────────────────────────────────────────────────
        _barFgB.Location = new Point(0, 0);
        _barFgB.Margin = new Padding(3, 4, 3, 4);
        _barFgB.Name = "_barFgB";
        _barFgB.Size = new Size(226, 29);
        _barFgB.TabIndex = 0;

        // ── _barBgB ───────────────────────────────────────────────────────────
        _barBgB.BackColor = Color.FromArgb(40, 40, 40);
        _barBgB.Controls.Add(_barFgB);
        _barBgB.Location = new Point(18, 176);
        _barBgB.Margin = new Padding(3, 4, 3, 4);
        _barBgB.Name = "_barBgB";
        _barBgB.Size = new Size(226, 29);
        _barBgB.TabIndex = 3;

        // ── _lblStatsB ────────────────────────────────────────────────────────
        _lblStatsB.BackColor = Color.Transparent;
        _lblStatsB.Font = new Font("Segoe UI", 8.5F);
        _lblStatsB.Location = new Point(0, 219);
        _lblStatsB.Name = "_lblStatsB";
        _lblStatsB.Size = new Size(263, 187);
        _lblStatsB.TabIndex = 4;
        _lblStatsB.Text = "⚔  Daño: 10 – 120\n🛡  Evasión: 20%\n❤  Vida: 1000";
        _lblStatsB.TextAlign = ContentAlignment.MiddleCenter;

        // ── _cardB ────────────────────────────────────────────────────────────
        _cardB.Controls.Add(_lblEmojiB);
        _cardB.Controls.Add(_lblNameB);
        _cardB.Controls.Add(_lblHpB);
        _cardB.Controls.Add(_barBgB);
        _cardB.Controls.Add(_lblStatsB);
        _cardB.Location = new Point(569, 160);
        _cardB.Margin = new Padding(3, 4, 3, 4);
        _cardB.Name = "_cardB";
        _cardB.Size = new Size(263, 427);
        _cardB.TabIndex = 6;
        _cardB.Paint += CardB_Paint;

        // ── _lblVs ────────────────────────────────────────────────────────────
        _lblVs.BackColor = Color.Transparent;
        _lblVs.Dock = DockStyle.Fill;
        _lblVs.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        _lblVs.Location = new Point(0, 0);
        _lblVs.Name = "_lblVs";
        _lblVs.Size = new Size(251, 427);
        _lblVs.TabIndex = 0;
        _lblVs.Text = "VS";
        _lblVs.TextAlign = ContentAlignment.MiddleCenter;

        // ── _vsPanel ──────────────────────────────────────────────────────────
        _vsPanel.BackColor = Color.Transparent;
        _vsPanel.Controls.Add(_lblVs);
        _vsPanel.Location = new Point(299, 160);
        _vsPanel.Margin = new Padding(3, 4, 3, 4);
        _vsPanel.Name = "_vsPanel";
        _vsPanel.Size = new Size(251, 427);
        _vsPanel.TabIndex = 5;

        // ── _log ──────────────────────────────────────────────────────────────
        _log.BorderStyle = BorderStyle.None;
        _log.Font = new Font("Consolas", 8.5F);
        _log.Location = new Point(18, 608);
        _log.Margin = new Padding(3, 4, 3, 4);
        _log.Name = "_log";
        _log.ReadOnly = true;
        _log.ScrollBars = RichTextBoxScrollBars.Vertical;
        _log.Size = new Size(814, 240);
        _log.TabIndex = 7;
        _log.Text = "";

        // ── _btnBet ───────────────────────────────────────────────────────────
        _btnBet.BackColor = Color.FromArgb(100, 70, 10);
        _btnBet.Cursor = Cursors.Hand;
        _btnBet.FlatAppearance.BorderSize = 0;
        _btnBet.FlatStyle = FlatStyle.Flat;
        _btnBet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnBet.ForeColor = Color.White;
        _btnBet.Location = new Point(18, 860);
        _btnBet.Margin = new Padding(3, 4, 3, 4);
        _btnBet.Name = "_btnBet";
        _btnBet.Size = new Size(814, 44);
        _btnBet.TabIndex = 10;
        _btnBet.Text = "🎰  APOSTAR  (100 fichas disponibles)";
        _btnBet.UseVisualStyleBackColor = false;
        _btnBet.Click += BtnBet_Click;

        // ── _btnStart ─────────────────────────────────────────────────────────
        _btnStart.BackColor = Color.FromArgb(60, 60, 60);
        _btnStart.Cursor = Cursors.Hand;
        _btnStart.FlatAppearance.BorderSize = 0;
        _btnStart.FlatStyle = FlatStyle.Flat;
        _btnStart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnStart.ForeColor = Color.White;
        _btnStart.Location = new Point(18, 916);
        _btnStart.Margin = new Padding(3, 4, 3, 4);
        _btnStart.Name = "_btnStart";
        _btnStart.Size = new Size(398, 48);
        _btnStart.TabIndex = 8;
        _btnStart.Text = "⚔  INICIAR BATALLA";
        _btnStart.UseVisualStyleBackColor = false;
        _btnStart.Click += BtnStart_Click;

        // ── _btnReset ─────────────────────────────────────────────────────────
        _btnReset.BackColor = Color.FromArgb(55, 55, 55);
        _btnReset.Cursor = Cursors.Hand;
        _btnReset.FlatAppearance.BorderSize = 0;
        _btnReset.FlatStyle = FlatStyle.Flat;
        _btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _btnReset.ForeColor = Color.White;
        _btnReset.Location = new Point(434, 916);
        _btnReset.Margin = new Padding(3, 4, 3, 4);
        _btnReset.Name = "_btnReset";
        _btnReset.Size = new Size(398, 48);
        _btnReset.TabIndex = 9;
        _btnReset.Text = "↺  REINICIAR";
        _btnReset.UseVisualStyleBackColor = false;
        _btnReset.Click += BtnReset_Click;

        // ── _timer ────────────────────────────────────────────────────────────
        _timer.Interval = 1000;
        _timer.Tick += Timer_Tick;

        // ── lblTitle ──────────────────────────────────────────────────────────
        lblTitle.BackColor = Color.Transparent;
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 13);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(850, 51);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "\U0001f995  DINO FIGHT  \U0001f996";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;

        // ── lblSubtitle ───────────────────────────────────────────────────────
        lblSubtitle.BackColor = Color.Transparent;
        lblSubtitle.Font = new Font("Segoe UI", 9F);
        lblSubtitle.Location = new Point(0, 61);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(850, 27);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Sistema de Combate por Turnos";
        lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

        // ── MainForm ──────────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(848, 976);
        BackColor = BgDark;
        ForeColor = TextLight;
        Controls.Add(lblTitle);
        Controls.Add(lblSubtitle);
        Controls.Add(_lblTurn);
        Controls.Add(_lblWinner);
        Controls.Add(_cardA);
        Controls.Add(_vsPanel);
        Controls.Add(_cardB);
        Controls.Add(_log);
        Controls.Add(_btnBet);
        Controls.Add(_btnStart);
        Controls.Add(_btnReset);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(866, 1024);
        MinimumSize = new Size(866, 1018);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "\U0001f995  DINO FIGHT  \U0001f996";

        _barBgA.ResumeLayout(false);
        _cardA.ResumeLayout(false);
        _barBgB.ResumeLayout(false);
        _cardB.ResumeLayout(false);
        _vsPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Paint de tarjetas ─────────────────────────────────────────────────────
    private void CardA_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(80, AccentA), 2f);
        e.Graphics.DrawRectangle(pen, 1, 1, _cardA.Width - 2, _cardA.Height - 2);
    }

    private void CardB_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(80, AccentB), 2f);
        e.Graphics.DrawRectangle(pen, 1, 1, _cardB.Width - 2, _cardB.Height - 2);
    }
}