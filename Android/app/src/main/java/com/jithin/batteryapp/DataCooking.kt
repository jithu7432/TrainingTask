package com.jithin.batteryapp

import java.util.Date
import java.text.DateFormat.getDateTimeInstance

class DataCooking(_database: DatabaseHandler) {
    private val database = _database
    private var badCount: Int = 0
    private var optimalCount: Int = 0
    private var spotCount: Int = 0
    private var drop: Int = 0
    private var timeTaken: Int = 0
    private var timeframe: String = ""
    private var lastUpdated: String = getDateTimeInstance().format(Date())

    private fun getChargingData() {
        this.badCount++
        this.optimalCount++
        this.spotCount++
    }

    private fun getDischargingData() {
        this.timeTaken++
        this.drop++
    }

    fun getCookedData(): List<String> {
        this.getChargingData()
        this.getDischargingData()
        return listOf("$badCount", "$optimalCount", "$spotCount", "$drop %", "$timeTaken second(s)", timeframe, lastUpdated)
    }
}