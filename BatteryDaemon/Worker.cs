using System.Management;
using System.Data.SQLite;
using System.Runtime.Versioning;
using System.Drawing.Printing;
using System.Data;

namespace BatteryAnalytics;

[SupportedOSPlatform("windows")]
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly string WqlCommand = "SELECT * FROM WIN32_BATTERY";
    private readonly string database_path = "D://Windows//BatteryDaemon.sqlite";
    private readonly string CreateTable = "CREATE TABLE Daemon(Timestamp BIGINT NOT NULL,Plugged int NOT NULL,CurrentLevel int NOT NULL)";
    public SQLiteConnection _conn;



    public Worker(ILogger<Worker> logger) {

        _logger = logger;
        if (!File.Exists(database_path)) {
            // Create an sqlite file if ! exists
            SQLiteConnection.CreateFile(database_path);
            _conn = new($"Data Source={database_path};Version=3;", true);
            _conn.Open();
            SQLiteCommand command = new(CreateTable, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        } else {
            _conn = new($"Data Source={database_path};Version=3;", true);
        }

    }



    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {
            var TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string LogMessage = $"Worker running at: {TimeStamp}";
            _logger.LogInformation(LogMessage);

            var WqlQuery = new ObjectQuery(WqlCommand);
            var Response = new ManagementObjectSearcher(WqlQuery);
            var Results = Response.Get();

            foreach (ManagementObject mo in Results) {
                var CurrentLevel = mo.Properties["EstimatedChargeRemaining"].Value;
                var ChargingStatus = mo.Properties["BatteryStatus"].Value;
                try {
                    _conn.Open();
                    string _query = @"INSERT INTO Daemon(Timestamp,Plugged,CurrentLevel) VALUES (@Timestamp ,@Plugged ,@CurrentLevel)";
                    var cmd = new SQLiteCommand(_query, _conn);
                    cmd.Parameters.AddWithValue("@Timestamp", Convert.ToInt64(TimeStamp));
                    cmd.Parameters.AddWithValue("@Plugged", Convert.ToInt32(ChargingStatus) - 1);
                    cmd.Parameters.AddWithValue("@CurrentLevel", Convert.ToInt32(CurrentLevel));
                    cmd.ExecuteNonQuery();
                    _conn.Close();
                } catch (Exception e) {
                    _conn.Close();
                    Console.WriteLine(e.Message);
                }
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}


