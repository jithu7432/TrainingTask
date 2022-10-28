package com.jithin.batteryapp

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper


class DatabaseHandler(context: Context, factory: SQLiteDatabase.CursorFactory?) : SQLiteOpenHelper(context, "BatteryApp", factory, 1) {
    private val sqlTable: String = "BatteryDaemon"
    private val sqlColTimestamp: String = "TimeStamp"
    private val sqlColPlugged: String = "Plugged"
    private val sqlColCurrentLevel: String = "CurrentLevel"

    override fun onCreate(db: SQLiteDatabase) {
        val query =
            "CREATE TABLE $sqlTable ($sqlColTimestamp INTEGER NOT NULL, $sqlColCurrentLevel INTEGER NOT NULL, $sqlColPlugged INTEGER NOT NULL)"
        db.execSQL(query)
    }

    override fun onUpgrade(db: SQLiteDatabase, p1: Int, p2: Int) {
        onCreate(db)
    }

    fun appendData(timestamp: Long, currentLevel: Int, plugged: Int) {
        val db = this.writableDatabase
        val contentValues = ContentValues()
        contentValues.put(sqlColTimestamp, timestamp)
        contentValues.put(sqlColCurrentLevel, currentLevel)
        contentValues.put(sqlColPlugged, plugged)
        db.insert(sqlTable, null, contentValues)
        db.close()
    }

    fun getData(): MutableList<BatteryInstant> {
        val db = this.writableDatabase
        val cursor = db.rawQuery(/* sql = */ "SELECT * FROM $sqlTable", /* selectionArgs = */ null)

        val batteryList: MutableList<BatteryInstant> = mutableListOf<BatteryInstant>(BatteryInstant(1, 1, 1))
        if (cursor == null) {
            throw NullPointerException("Cursor is null!")
        }
        while (cursor.moveToNext()) {
            val plugged = cursor.getString(cursor.getColumnIndex("Plugged") ?: 0).toInt()
            val currentLevel = cursor.getString(cursor.getColumnIndex("CurrentLevel") ?: 1).toInt()
            val timestamp = cursor.getString(cursor.getColumnIndex("TimeStamp") ?: 2).toLong()
            val battery = BatteryInstant(timestamp, currentLevel, plugged)
            batteryList.add(battery)
        }
        cursor.close();
        db.close()
        return batteryList
    }
}