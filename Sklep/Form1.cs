using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SqliteConnection dbConnection;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadShoesFromDatabase();  // Za�adowanie danych o butach z bazy
        }

        // Inicjalizacja bazy danych
        private void InitializeDatabase()
        {
            dbConnection = new SqliteConnection("Data Source=Sklep.db"); // U�ywamy bazy danych Sklep.db
            dbConnection.Open();

            // Zmiana zapytania tworz�cego tabel� buty
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS buty (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    Marka TEXT NOT NULL, 
                    Nazwa TEXT NOT NULL, 
                    Cena REAL NOT NULL, 
                    IloscSztuk INTEGER NOT NULL
                )";

            using (var command = new SqliteCommand(createTableQuery, dbConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Wczytanie but�w z bazy danych
        private void LoadShoesFromDatabase()
        {
            listOfUsers.Items.Clear();

            // Sprawdzenie, czy tabela istnieje
            string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='buty'";
            using (var checkCommand = new SqliteCommand(checkTableQuery, dbConnection))
            {
                var result = checkCommand.ExecuteScalar();

                if (result == null)
                {
                    // Tabela nie istnieje, wi�c j� tworzymy
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS buty (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Marka TEXT NOT NULL, 
                            Nazwa TEXT NOT NULL, 
                            Cena REAL NOT NULL, 
                            IloscSztuk INTEGER NOT NULL
                        )";

                    using (var createCommand = new SqliteCommand(createTableQuery, dbConnection))
                    {
                        createCommand.ExecuteNonQuery();
                    }
                    return; // Nie pr�bujemy wczyta� danych, bo tabela jest pusta
                }
            }

            // Je�li tabela istnieje, wczytujemy dane
            string selectQuery = "SELECT Id, Marka, Nazwa, Cena, IloscSztuk FROM buty";
            using (var command = new SqliteCommand(selectQuery, dbConnection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listOfUsers.Items.Add($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetDouble(3):C} - {reader.GetInt32(4)} szt.");
                }
            }
        }

        // Dodanie buta do bazy po klikni�ciu przycisku
        private void addButton_Click(object sender, EventArgs e)
        {
            string marka = markaTextBox.Text.Trim();
            string nazwa = nazwaTextBox.Text.Trim();
            double cena;
            int iloscSztuk;

            // Sprawdzenie, czy dane s� poprawne
            if (string.IsNullOrWhiteSpace(marka) || string.IsNullOrWhiteSpace(nazwa) ||
                !double.TryParse(cenaTextBox.Text, out cena) || !int.TryParse(iloscTextBox.Text, out iloscSztuk))
            {
                MessageBox.Show("Prosz� wprowadzi� poprawne dane.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Zapytanie do dodania produktu
                string insertQuery = "INSERT INTO buty (Marka, Nazwa, Cena, IloscSztuk) VALUES (@Marka, @Nazwa, @Cena, @IloscSztuk)";
                using (var command = new SqliteCommand(insertQuery, dbConnection))
                {
                    command.Parameters.AddWithValue("@Marka", marka);
                    command.Parameters.AddWithValue("@Nazwa", nazwa);
                    command.Parameters.AddWithValue("@Cena", cena);
                    command.Parameters.AddWithValue("@IloscSztuk", iloscSztuk);
                    command.ExecuteNonQuery();
                }

                LoadShoesFromDatabase();  // Od�wie�enie listy but�w po dodaniu
                markaTextBox.Clear();
                nazwaTextBox.Clear();
                cenaTextBox.Clear();
                iloscTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d: {ex.Message}", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchIdButton_Click(object sender, EventArgs e)
        {
            string id = searchIdTextBox.Text.Trim();

            if (!int.TryParse(id, out int shoeId))
            {
                MessageBox.Show("Prosz� wprowadzi� poprawne ID.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listOfUsers.Items.Clear();

            string selectQuery = "SELECT Id, Marka, Nazwa, Cena, IloscSztuk FROM buty WHERE Id = @Id";
            using (var command = new SqliteCommand(selectQuery, dbConnection))
            {
                command.Parameters.AddWithValue("@Id", shoeId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        listOfUsers.Items.Add($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetDouble(3):C} - {reader.GetInt32(4)} szt.");
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono buta o takim ID.", "Brak wynik�w", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void searchMarkaButton_Click(object sender, EventArgs e)
        {
            string marka = searchMarkaTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(marka))
            {
                MessageBox.Show("Prosz� wprowadzi� nazw� marki.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listOfUsers.Items.Clear();

            string selectQuery = "SELECT Id, Marka, Nazwa, Cena, IloscSztuk FROM buty WHERE Marka LIKE @Marka";
            using (var command = new SqliteCommand(selectQuery, dbConnection))
            {
                command.Parameters.AddWithValue("@Marka", "%" + marka + "%");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listOfUsers.Items.Add($"{reader.GetInt32(0)} - {reader.GetString(1)} {reader.GetString(2)} - {reader.GetDouble(3):C} - {reader.GetInt32(4)} szt.");
                    }
                }
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            LoadShoesFromDatabase(); // Wywo�anie metody �aduj�cej wszystkie buty
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string idText = idToDeleteTextBox.Text.Trim();

            if (!int.TryParse(idText, out int shoeId))
            {
                MessageBox.Show("Prosz� wprowadzi� poprawne ID.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string deleteQuery = "DELETE FROM buty WHERE Id = @Id";
                using (var command = new SqliteCommand(deleteQuery, dbConnection))
                {
                    command.Parameters.AddWithValue("@Id", shoeId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("But zosta� usuni�ty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono buta o takim ID.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadShoesFromDatabase(); // Od�wie�enie listy but�w po usuni�ciu
                idToDeleteTextBox.Clear(); // Czyszczenie pola tekstowego
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� b��d: {ex.Message}", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Zamkni�cie po��czenia przy zamykaniu aplikacji
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            dbConnection?.Close();
            dbConnection?.Dispose();
            base.OnFormClosed(e);
        }

        
    }
}
