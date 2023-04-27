using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chinczyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int wynik;
        int player = 1;

        public Player player1 = new Player(1);
        public Player player2 = new Player(2);

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        private void Wynik_Click(object sender, RoutedEventArgs e)
        {
            int numer = RandomNumberGenerator.GetInt32(1, 7);
            Dice.Text = numer.ToString();
            wynik = numer;
            PawnpositionChange(player, wynik);
            Playercolorchange(player);
        }
        public void Playercolorchange(int id)
        {
            switch (id)
            {
                case 1:
                    PlayerColor.Background = Brushes.Red;
                    player = 2;
                    break;
                case 2:
                    PlayerColor.Background = Brushes.Blue;
                    player = 1;
                    break;
            }
        }
        public void PawnpositionChange(int id, int wynik)
        {
            int fieldposition;
            string fieldbox;
            TextBox foundTextBox;

            switch (id)
            {
                case 1:
                    ClearOldField(id);

                    //Upgrading old results
                    player1.pawnposition += wynik;
                    player1.progress += wynik;
                    IfWinner(player);

                    //New position block
                    fieldposition = player1.pawnposition;
                    fieldbox = "_" + fieldposition.ToString();

                    foundTextBox = (TextBox)FindName(fieldbox);
                    foundTextBox.Background = Brushes.Blue;
                    break;

                case 2:
                    //clearing old field
                    ClearOldField(id);

                    //Upgrading old results
                    player2.pawnposition += wynik;
                    player2.progress += wynik;
                    IfWinner(player);

                    //New position block
                    fieldposition = player2.pawnposition;
                    fieldbox = "_" + fieldposition.ToString();

                    foundTextBox = (TextBox)FindName(fieldbox);
                    foundTextBox.Background = Brushes.Red;
                    break;
            }
        }

        private void ClearOldField(int id)
        {
            int fieldposition;
            string fieldbox;
            TextBox foundTextBox;
            switch (id) 
            { 
                case 1:
                    fieldposition = player1.pawnposition;
                    fieldbox = "_" + fieldposition.ToString();

                    foundTextBox = (TextBox)FindName(fieldbox);
                    foundTextBox.Background = Brushes.White;
                    break;
                case 2:

                    fieldposition = player2.pawnposition;
                    fieldbox = "_" + fieldposition.ToString();

                    foundTextBox = (TextBox)FindName(fieldbox);
                    foundTextBox.Background = Brushes.White;
                    break;
            
            }
            
        }

        public void IfWinner(int id)
        {
            switch (id)
            {
                case 1:
                    if (player1.pawnposition > 40)
                        player1.pawnposition -= 40;
                    if (player1.progress >= 40)
                    {
                        MessageBox.Show("Player 1 Wins (Blue)");
                        NewGame();
                    }
                    break;
                case 2:
                    if (player2.pawnposition > 40)
                        player2.pawnposition -= 40;
                    if (player2.progress >= 40)
                    {
                        MessageBox.Show("Player 2 Wins (Red)");
                        NewGame();
                    }
                    break;

            }
        }

        private void NewGame()
        {
            player1.progress = 0;
            player2.progress = 0;
            ClearOldField(1);
            ClearOldField(2);

            player1.pawnposition = player1.startposition;
            player2.pawnposition = player2.startposition;

            PawnpositionChange(1, 0);
            PawnpositionChange(2, 0);

        }

    }
}