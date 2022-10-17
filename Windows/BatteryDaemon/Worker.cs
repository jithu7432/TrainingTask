using System.Management;
using System.Data.SqlClient;
using System.Runtime.Versioning;

namespace BatteryAnalytics;

[SupportedOSPlatform("windows")]
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly string WqlCommand = "SELECT * FROM WIN32_BATTERY";
    private readonly string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Battery;Integrated Security=True";
    public SqlConnection _conn;


    public Worker(ILogger<Worker> logger) {
        _logger = logger;
        _conn = new SqlConnection(ConnectionString);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {
            var TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            string _msg = $"Worker running at: {TimeStamp}";
            _logger.LogInformation(_msg);

            var WqlQuery = new ObjectQuery(WqlCommand);
            var Response = new ManagementObjectSearcher(WqlQuery);
            var Results = Response.Get();

            foreach (ManagementObject mo in Results) {
                var CurrentLevel = mo.Properties["EstimatedChargeRemaining"].Value;
                var ChargingStatus = mo.Properties["BatteryStatus"].Value;
                try {
                    _conn.Open();
                    string _query = @"INSERT INTO Daemon(TimeStamp,ChargingStatus,CurrentLevel) VALUES (@TimeStamp ,@ChargingStatus ,@CurrentLevel)";
                    var cmd = new SqlCommand(_query, _conn);
                    cmd.Parameters.AddWithValue("@TimeStamp", Convert.ToInt64(TimeStamp));
                    cmd.Parameters.AddWithValue("@ChargingStatus", Convert.ToInt32(ChargingStatus));
                    cmd.Parameters.AddWithValue("@CurrentLevel", Convert.ToInt32(CurrentLevel));
                    cmd.ExecuteNonQuery();
                    _conn.Close();
                    _msg = $"Wrote {TimeStamp} to Database";
                    _logger.LogInformation(_msg);
                }
                catch (Exception e) {
                    _conn.Close();
                    Console.WriteLine(e.Message);
                }

            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}


