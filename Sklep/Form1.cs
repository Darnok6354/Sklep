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
            LoadShoesFromDatabase();  
        }

        
        private void InitializeDatabase()
        {
            dbConnection = new SqliteConnection("Data Source=Sklep.db"); 
            dbConnection.Open();

            
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

        
        private void LoadShoesFromDatabase()
        {
            listOfUsers.Items.Clear();

            
            string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='buty'";
            using (var checkCommand = new SqliteCommand(checkTableQuery, dbConnection))
            {
                var result = checkCommand.ExecuteScalar();

                if (result == null)
                {
                    
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
                    return; 
                }
            }

            
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

        
        private void addButton_Click(object sender, EventArgs e)
        {
            string marka = markaTextBox.Text.Trim();
            string nazwa = nazwaTextBox.Text.Trim();
            double cena;
            int iloscSztuk;

            
            if (string.IsNullOrWhiteSpace(marka) || string.IsNullOrWhiteSpace(nazwa) ||
                !double.TryParse(cenaTextBox.Text, out cena) || !int.TryParse(iloscTextBox.Text, out iloscSztuk))
            {
                MessageBox.Show("Proszê wprowadziæ poprawne dane.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                string insertQuery = "INSERT INTO buty (Marka, Nazwa, Cena, IloscSztuk) VALUES (@Marka, @Nazwa, @Cena, @IloscSztuk)";
                using (var command = new SqliteCommand(insertQuery, dbConnection))
                {
                    command.Parameters.AddWithValue("@Marka", marka);
                    command.Parameters.AddWithValue("@Nazwa", nazwa);
                    command.Parameters.AddWithValue("@Cena", cena);
                    command.Parameters.AddWithValue("@IloscSztuk", iloscSztuk);
                    command.ExecuteNonQuery();
                }

                LoadShoesFromDatabase();  
                markaTextBox.Clear();
                nazwaTextBox.Clear();
                cenaTextBox.Clear();
                iloscTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchIdButton_Click(object sender, EventArgs e)
        {
            string id = searchIdTextBox.Text.Trim();

            if (!int.TryParse(id, out int shoeId))
            {
                MessageBox.Show("Proszê wprowadziæ poprawne ID.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Nie znaleziono buta o takim ID.", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void searchMarkaButton_Click(object sender, EventArgs e)
        {
            string marka = searchMarkaTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(marka))
            {
                MessageBox.Show("Proszê wprowadziæ nazwê marki.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadShoesFromDatabase(); 
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string idText = idToDeleteTextBox.Text.Trim();

            if (!int.TryParse(idText, out int shoeId))
            {
                MessageBox.Show("Proszê wprowadziæ poprawne ID.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("But zosta³ usuniêty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono buta o takim ID.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadShoesFromDatabase(); 
                idToDeleteTextBox.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ b³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            dbConnection?.Close();
            dbConnection?.Dispose();
            base.OnFormClosed(e);
        }

        
    }
}
