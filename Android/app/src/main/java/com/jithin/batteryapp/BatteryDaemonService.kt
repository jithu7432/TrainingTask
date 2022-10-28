package com.jithin.batteryapp

import android.app.Service
import android.content.Intent
import android.os.BatteryManager
import android.os.IBinder
import java.util.concurrent.TimeUnit

class BatteryDaemonService : Service() {
    override fun onStartCommand(intent: Intent?, flags: Int, startId: Int): Int {
        onTaskRemoved(intent)
        val batteryManager: BatteryManager = applicationContext.getSystemService(BATTERY_SERVICE) as BatteryManager
        val battery = Battery(batteryManager)
        val database = DatabaseHandler(this, null)
        database.appendData(battery.timestamp, battery.currentLevel, battery.plugged)
        TimeUnit.SECONDS.sleep(1)
        return START_STICKY
    }

    override fun onTaskRemoved(rootIntent: Intent?) {
        val restartServiceIntent = Intent(applicationContext, this.javaClass)
        restartServiceIntent.setPackage(packageName)
        startService(restartServiceIntent)
        super.onTaskRemoved(rootIntent)
    }

    override fun onBind(intent: Intent): IBinder? {
        throw UnsupportedOperationException("BatteryDaemonService::onBind not implemented!")
    }

}