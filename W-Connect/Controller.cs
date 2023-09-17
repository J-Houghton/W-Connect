using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Newtonsoft.Json;
using static W_Connect.MainWindow;
using System.Net.NetworkInformation;

namespace W_Connect
{
    public class Controller
    {
        private string sqliteFilePath = ""; // Store the path for reuse

        public Dictionary<string, StrimmerEffect> EffectDataDictionary;

        public StrimmerController strimmer;

        public Controller()
        {
            EffectDataDictionary = new Dictionary<string, StrimmerEffect>();
        }
        public string SqliteFilePath
        {
            get => sqliteFilePath;
            set => sqliteFilePath = value;
            
        }

        

        // When user imports the file:
        public void ImportData()
        {
            // Assuming user picked a .backup file and you've renamed it to .sqlite and set path to `sqliteFilePath`
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={SqliteFilePath};Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText = "Select key, value From appinfo";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string key = reader.GetString(0);
                            string json = reader.GetString(1);

                            if (key.Contains("StrimerLightEfferct"))
                            {
                                try
                                {
                                    StrimmerEffect effect = JsonConvert.DeserializeObject<StrimmerEffect>(json);
                                    if (effect != null)
                                    {
                                        EffectDataDictionary.Add(key, effect);
                                    }
                                } catch (Exception e)
                                {

                                }
                                
                            }
                            else if (key.Contains("StrimerController"))
                            {
                                try
                                {
                                    strimmer = JsonConvert.DeserializeObject<StrimmerController>(json);
                                } catch (Exception ex)
                                {

                                }
                            }
/*                          else if (key.Contains("SLInfLightEffect"))
                            {

                            }*/
                        }
                    }
                    conn.Close();
                }
            } catch (Exception ex)
            {
                ex.ToString();
            }
        }

        // When user decides to save changes:
        private void UpdateData()
        {
            // TODO: Serialize data from GUI elements into JSON

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={sqliteFilePath};Version=3;"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE appinfo SET value = @newValue WHERE key = @keyValue", conn))
                {
                    cmd.Parameters.AddWithValue("@newValue", "YourNewJsonValueFromGUI");
                    cmd.Parameters.AddWithValue("@keyValue", "StrimmerLightEffect-effectname");
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        // When user wants to export the modified data:
        private void ExportData()
        {
            string backupPath = System.IO.Path.ChangeExtension(sqliteFilePath, ".backup");
           // File.Move(sqliteFilePath, backupPath);

            // Notify user of successful export or any other post-actions
        }

    }
}
