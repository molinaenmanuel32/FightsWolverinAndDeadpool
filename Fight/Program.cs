namespace DinoFight;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Abrir la casa de apuestas antes que nada
        using var bet = new BettingForm(100);
        if (bet.ShowDialog() != DialogResult.OK) return;
    }
}