package com.jithin.batteryapp

import android.content.Intent
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import androidx.appcompat.app.AppCompatActivity
import androidx.core.database.getStringOrNull

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //service
        val serviceIntent: Intent = Intent(this, BatteryDaemonService::class.java)

        //Views
        val clearButton = findViewById<Button>(R.id.btn_clear)
        val cookButton = findViewById<Button>(R.id.btn_cook)
        val propertyView = findViewById<ListView>(R.id.lv_property)
        val valueView = findViewById<ListView>(R.id.lv_value)

        // Button Listeners

        val database = DatabaseHandler(this, null)
        val cookedData = DataCooking(database)

        clearButton.setOnClickListener { updateTableValues(valueView, null) }
        cookButton.setOnClickListener { updateTableValues(valueView, cookedData.getCookedData()) }

        // Starting service
        startService(serviceIntent)
        // Populating the table
        populateProperties(propertyView)
        // Initializing all values with N/A
        updateTableValues(valueView, null)
    }

    private fun updateTableValues(listview: ListView, values: List<String>?) {
        val propertyNames: List<String> = values ?: List(7) { "NA" }
        val arrayAdapter: ArrayAdapter<String> = ArrayAdapter(this, android.R.layout.simple_list_item_1, propertyNames)
        listview.adapter = arrayAdapter
    }

    private fun populateProperties(listview: ListView) {
        val propertyNames = listOf("Bad Count", "Optimal Count", "Spot Count", "Dropped %", "Time Consumed", "Time Frame", "Last Updated")
        val arrayAdapter: ArrayAdapter<String> = ArrayAdapter(this, android.R.layout.simple_list_item_1, propertyNames)
        listview.adapter = arrayAdapter
    }
}

