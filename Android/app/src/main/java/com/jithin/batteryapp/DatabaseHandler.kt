package com.jithin.batteryapp

import android.content.ContentValues
import android.content.Context
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import android.util.Log
import kotlin.system.exitProcess


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

    fun getCursor(): Cursor? {
        val db = this.writableDatabase
        return db.rawQuery("SELECT * FROM $sqlTable", null)
    }

    fun getData() {
        val cursor = this.getCursor()
        var i = 0
        if (cursor != null) {
            while (cursor.moveToNext()) {
                var plugged = cursor.getString(cursor.getColumnIndex("Plugged") ?: 1)
                var level = cursor.getString(cursor.getColumnIndex("CurrentLevel") ?: 1)
                var timestamp = cursor.getString(cursor.getColumnIndex("TimeStamp") ?: 1)
                println(listOf(i, level, plugged, timestamp.toLong() / 1000))
                i++
            }
            cursor.close();
        }
    }
}