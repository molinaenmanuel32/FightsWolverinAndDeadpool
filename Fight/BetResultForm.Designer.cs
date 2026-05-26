using System.Drawing;
using System.Windows.Forms;

namespace DinoFight;

partial class BetResultForm
{
    private Label lblEmoji;
    private Label lblHeadline;
    private Panel card;
    private Label lblTotal;
    private Button btnClose;

    private void InitializeComponent()
    {
        lblEmoji = new Label();
        lblHeadline = new Label();
        card = new Panel();
        lblTotal = new Label();
        btnClose = new Button();

        SuspendLayout();

        // FORM
        ClientSize = new Size(420, 370);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        BackColor = BgDark;
        ForeColor = TextLight;
        Font = new System.Drawing.Font("Segoe UI", 9F);

        // lblEmoji
        lblEmoji.Size = new Size(420, 90);
        lblEmoji.Location = new Point(0, 16);
        lblEmoji.TextAlign = ContentAlignment.MiddleCenter;
        lblEmoji.BackColor = Color.Transparent;

        // lblHeadline
        lblHeadline.Size = new Size(420, 40);
        lblHeadline.Location = new Point(0, 110);
        lblHeadline.TextAlign = ContentAlignment.MiddleCenter;
        lblHeadline.BackColor = Color.Transparent;

        // card
        card.Size = new Size(360, 130);
        card.Location = new Point(30, 162);
        card.BackColor = BgCard;

        // lblTotal
        lblTotal.Size = new Size(420, 30);
        lblTotal.Location = new Point(0, 304);
        lblTotal.TextAlign = ContentAlignment.MiddleCenter;
        lblTotal.BackColor = Color.Transparent;

        // btnClose
        btnClose.Size = new Size(360, 40);
        btnClose.Location = new Point(30, 318);
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.Cursor = Cursors.Hand;

        Controls.Add(lblEmoji);
        Controls.Add(lblHeadline);
        Controls.Add(card);
        Controls.Add(lblTotal);
        Controls.Add(btnClose);

        ResumeLayout(false);
    }
}