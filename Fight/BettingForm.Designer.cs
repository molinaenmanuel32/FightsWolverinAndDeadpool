using System.Drawing;
using System.Windows.Forms;

namespace DinoFight;

partial class BettingForm
{
    private Button _btnA;
    private Button _btnB;
    private NumericUpDown _numBet;
    private Label _lblPayout;
    private Button _btnConfirm;

    private Label lblTitle;
    private Label lblSub;
    private Label lblChipsTitle;
    private Label lblChips;
    private Label lblPick;
    private Label lblBet;

    private Button btn10;
    private Button btn25;
    private Button btn50;
    private Button btnAllIn;

    private void InitializeComponent()
    {
        _btnA = new Button();
        _btnB = new Button();
        _numBet = new NumericUpDown();
        _lblPayout = new Label();
        _btnConfirm = new Button();
        lblTitle = new Label();
        lblSub = new Label();
        lblChipsTitle = new Label();
        lblChips = new Label();
        lblPick = new Label();
        lblBet = new Label();
        btn10 = new Button();
        btn25 = new Button();
        btn50 = new Button();
        btnAllIn = new Button();
        ((System.ComponentModel.ISupportInitialize)_numBet).BeginInit();
        SuspendLayout();
        // 
        // _btnA
        // 
        _btnA.Location = new Point(30, 152);
        _btnA.Name = "_btnA";
        _btnA.Size = new Size(220, 108);
        _btnA.TabIndex = 5;
        // 
        // _btnB
        // 
        _btnB.Location = new Point(270, 152);
        _btnB.Name = "_btnB";
        _btnB.Size = new Size(220, 108);
        _btnB.TabIndex = 6;
        // 
        // _numBet
        // 
        _numBet.Location = new Point(195, 293);
        _numBet.Name = "_numBet";
        _numBet.Size = new Size(130, 27);
        _numBet.TabIndex = 8;
        _numBet.TextAlign = HorizontalAlignment.Center;
        // 
        // _lblPayout
        // 
        _lblPayout.Location = new Point(0, 333);
        _lblPayout.Name = "_lblPayout";
        _lblPayout.Size = new Size(520, 22);
        _lblPayout.TabIndex = 13;
        _lblPayout.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _btnConfirm
        // 
        _btnConfirm.Location = new Point(30, 358);
        _btnConfirm.Name = "_btnConfirm";
        _btnConfirm.Size = new Size(460, 48);
        _btnConfirm.TabIndex = 14;
        _btnConfirm.Text = "⚔ CONFIRMAR APUESTA";
        _btnConfirm.Click += _btnConfirm_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(0, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(520, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "🎰 CASA DE APUESTAS";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSub
        // 
        lblSub.Location = new Point(0, 60);
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(520, 22);
        lblSub.TabIndex = 1;
        lblSub.Text = "Elige tu dinosaurio y apuesta tus fichas antes de la batalla";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblChipsTitle
        // 
        lblChipsTitle.Location = new Point(160, 92);
        lblChipsTitle.Name = "lblChipsTitle";
        lblChipsTitle.Size = new Size(160, 24);
        lblChipsTitle.TabIndex = 2;
        lblChipsTitle.Text = "💰 Fichas disponibles:";
        lblChipsTitle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblChips
        // 
        lblChips.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblChips.Location = new Point(326, 92);
        lblChips.Name = "lblChips";
        lblChips.Size = new Size(80, 24);
        lblChips.TabIndex = 3;
        // 
        // lblPick
        // 
        lblPick.Location = new Point(0, 126);
        lblPick.Name = "lblPick";
        lblPick.Size = new Size(520, 22);
        lblPick.TabIndex = 4;
        lblPick.Text = "¿Por quién apuestas?";
        lblPick.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBet
        // 
        lblBet.Location = new Point(0, 268);
        lblBet.Name = "lblBet";
        lblBet.Size = new Size(520, 22);
        lblBet.TabIndex = 7;
        lblBet.Text = "Fichas a apostar:";
        lblBet.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btn10
        // 
        btn10.Location = new Point(336, 293);
        btn10.Name = "btn10";
        btn10.Size = new Size(42, 32);
        btn10.TabIndex = 9;
        // 
        // btn25
        // 
        btn25.Location = new Point(382, 293);
        btn25.Name = "btn25";
        btn25.Size = new Size(42, 32);
        btn25.TabIndex = 10;
        // 
        // btn50
        // 
        btn50.Location = new Point(428, 293);
        btn50.Name = "btn50";
        btn50.Size = new Size(42, 32);
        btn50.TabIndex = 11;
        // 
        // btnAllIn
        // 
        btnAllIn.Location = new Point(474, 293);
        btnAllIn.Name = "btnAllIn";
        btnAllIn.Size = new Size(42, 32);
        btnAllIn.TabIndex = 12;
        // 
        // BettingForm
        // 
        ClientSize = new Size(520, 420);
        Controls.Add(lblTitle);
        Controls.Add(lblSub);
        Controls.Add(lblChipsTitle);
        Controls.Add(lblChips);
        Controls.Add(lblPick);
        Controls.Add(_btnA);
        Controls.Add(_btnB);
        Controls.Add(lblBet);
        Controls.Add(_numBet);
        Controls.Add(btn10);
        Controls.Add(btn25);
        Controls.Add(btn50);
        Controls.Add(btnAllIn);
        Controls.Add(_lblPayout);
        Controls.Add(_btnConfirm);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "BettingForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "🎰 Casa de Apuestas — DinoFight";
        ((System.ComponentModel.ISupportInitialize)_numBet).EndInit();
        ResumeLayout(false);
    }
}