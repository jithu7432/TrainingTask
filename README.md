# Installation
### Database
```sql
CREATE DATABASE Battery
USE Battery
CREATE TABLE Daemon(
TimeStamp BIGINT NOT NULL,
ChargingStatus int NOT NULL,
CurrentLevel int NOT NULL)
```
1. Configure the `ConnectionString` at `/BatteryDaemon/Worker.cs`
1. Compile using `dotnet build` (`BatteryDaemon` directory) and set up the `exe` for autostart at boot.
1. Run `BatteryAppGUI` using `dotnet run` (from the `BatteryGUI` directory) 

