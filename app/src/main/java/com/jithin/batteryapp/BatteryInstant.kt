package com.jithin.batteryapp

import android.os.BatteryManager

class BatteryAdapter(batteryManager: BatteryManager) {
    val currentLevel: Int = batteryManager.getIntProperty(BatteryManager.BATTERY_PROPERTY_CAPACITY)
    val plugged: Int = if (batteryManager.isCharging) 1 else 0
    val timestamp: Long = System.currentTimeMillis()
}

// Represents each row of the database.
data class BatteryInstant(
    val timestamp: Long,
    val currentLevel: Int,
    val plugged: Int,
)



