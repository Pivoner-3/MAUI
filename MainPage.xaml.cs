namespace Laba18_MAUI
{
    public partial class MainPage : ContentPage
    {
        private bool superAttackUse = false;
        private float PlayerHealth = 100;
        private float MonsterHealth = 80;
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Colors.White;
        }

        private void OnNewGameClick(object sender, EventArgs e)
        {
            battleLog.Text = "Начало нового боя!\n";
            PlayerHealth = 100;
            MonsterHealth = 80;
            UpdateHealthBars();
            Attack.IsEnabled = true;
            Heall.IsEnabled = true;
            SuperAttack.IsEnabled = true;
            superAttackUse = false;
        }
        private void AtackMonster()
        {
            float MonsterDamege = 15;
            PlayerHealth -= MonsterDamege;
            battleLog.Text += $"Монстр нанес вам {MonsterDamege} урона! Возможно нужно подлечиться!\n";
            if (PlayerHealth < 50)
                battleLog.Text += "У вас меньше 50 здоровья, нужно подлечиться!\n";
            UpdateHealthBars();
            CheckEnd();
        }
        private void OnAttackClick(object? sender, EventArgs e)
        {
            float damage = 10;
            MonsterHealth -= damage;
            battleLog.Text += $"Вы нанесли монстру {damage} урона!\n";
            UpdateHealthBars();
            CheckEnd();
            AtackMonster();
        }
        private void OnHealClick(object? sender, EventArgs e)
        {
            float heall = 5;
            PlayerHealth += heall;
            battleLog.Text += $"Вы восстановили себе {heall} здоровья! Продолжайте бой!\n";
            UpdateHealthBars();
        }
        private void OnSuperAttackClick(object? sender, EventArgs e)
        {
            if (!superAttackUse)
            {
                float superDamage = 25;
                MonsterHealth -= superDamage;
                battleLog.Text += $"Вы нанесли монстру {superDamage} критического урона!\n";
                superAttackUse = true;
                SuperAttack.IsEnabled = false;
                CheckEnd();
                UpdateHealthBars();
                AtackMonster();
            }
        }
        private void UpdateHealthBars()
        {
            PlayerBar.Progress = PlayerHealth / 100;
            MonsterBar.Progress = MonsterHealth / 100;
        }

        private void CheckEnd()
        {
            if (MonsterHealth < 0 || PlayerHealth < 0)
                End();
        }
        private void End()
        {
            Attack.IsEnabled = false;
            Heall.IsEnabled = false;
            SuperAttack.IsEnabled = false;

            if (MonsterHealth < 0 && PlayerHealth > 0)
                battleLog.Text += "Монстр повержен, вы победили!\n";
            else if (PlayerHealth < 0)
                battleLog.Text += "Игрок повержен... Можете начать новый бой.\n";
        }
    }
}
