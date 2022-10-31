package com.jithin.batteryapp

import android.icu.text.SimpleDateFormat
import java.text.DateFormat.getDateTimeInstance
import java.util.*

class DataCooking(_database: DatabaseHandler) {
    private lateinit var batteryList: MutableList<BatteryInstant>
    private var _db: DatabaseHandler = _database
    private var badCount: Int = 0
    private var optimalCount: Int = 0
    private var spotCount: Int = 0
    private var drop: Int = 0
    private var timeTaken: Int = 0
    private lateinit var timeframe: String
    private lateinit var lastUpdated: String


    private fun cookChargingData() {
        // BadCount & Optimal Count O(N)
        var count = 0
        for (i in 1 until this.batteryList.size) {
            val current = this.batteryList[i]
            if ((current.plugged == 1) && (current.currentLevel > 99)) {
                count++
            } else {
                if (count > 0) {
                    if (count > 30) this.badCount++ else this.optimalCount++
                    count = 0
                }
            }
        }
        // Device is still plugged in
        if (count > 0) if (count > 30) this.badCount++ else this.optimalCount++

        // SpotCount O(N)
        count = 0
        for (i in 1 until this.batteryList.size) {
            val current = this.batteryList[i]
            if ((current.plugged == 1) && current.currentLevel < 100) {
                count++
            } else {
                if (count > 0) this.spotCount++
                count = 0
            }
        }
    }

    private fun sourceValues() {
        this.drop = 0
        this.badCount = 0
        this.spotCount = 0
        this.timeTaken = 0
        this.optimalCount = 0
        this.batteryList = this._db.getData()
    }

    private fun getBoundsForTheHour(): List<Long> {
        val format = SimpleDateFormat("yyyy.MM.dd HH:mm", Locale.US)
        // HH:00:00.000
        format.calendar.set(Calendar.MINUTE, 0)
        format.calendar.set(Calendar.SECOND, 0)
        format.calendar.set(Calendar.MILLISECOND, 0)
        val leftBound = format.calendar.timeInMillis
        // HH:59:59.999
        format.calendar.set(Calendar.MINUTE, 59)
        format.calendar.set(Calendar.SECOND, 59)
        format.calendar.set(Calendar.MILLISECOND, 999)
        val rightBound = format.calendar.timeInMillis
        return listOf(leftBound, rightBound)
    }

    private fun convertLongToTime(time: Long): String {
        val date = Date(time)
        val format = SimpleDateFormat("hh:mm", Locale.US)
        return format.format(date)
    }

    private fun setTimeframe(bounds: List<Long>) {
        this.timeframe = "${convertLongToTime(bounds[0])} - ${convertLongToTime(bounds[1])}"
    }


    private fun cookDischargingData() {
        val bounds = getBoundsForTheHour()
        this.setTimeframe(bounds)
        // Finding the starting point.
        var j = 0
        while (this.batteryList[j].timestamp < bounds[0]) {
            j++
        }
        var previous = this.batteryList[j]
        var toggled = false
        // Computing drop and time_taken O(N)
        for (i in j until this.batteryList.size) {
            val current = this.batteryList[i]
            if (current.currentLevel < previous.currentLevel) {
                toggled = true
            }
            else if(current.currentLevel > previous.currentLevel){
                toggled = false
            }
            if(toggled){
                this.drop += (previous.currentLevel - current.currentLevel)
                this.timeTaken++
            }
            previous = current
        }
    }

    fun getCookedData(): List<String> {
        this.sourceValues()
        this.cookDischargingData()
        this.cookChargingData()
        this.lastUpdated = getDateTimeInstance().format(Date())
        return listOf(
            this.badCount.toString(),
            this.optimalCount.toString(),
            this.spotCount.toString(),
            "${this.drop} %",
            "%.2f minute(s)".format(this.timeTaken.toDouble() / 60.toDouble()),
            this.timeframe,
            this.lastUpdated
        )
    }
}