package com.jithin.batteryapp

import android.os.BatteryManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)


        val cookButton = findViewById<Button>(R.id.btn_cook)
        val clearButton = findViewById<Button>(R.id.btn_clear)

        val textView = findViewById<TextView>(R.id.textView)

        val batteryManager: BatteryManager = applicationContext.getSystemService(BATTERY_SERVICE) as BatteryManager
        fun getCurrentLevel(): Int {
            return batteryManager.getIntProperty(BatteryManager.BATTERY_PROPERTY_CAPACITY)
        }
        fun getTimeStamp(): Long {
            return System.currentTimeMillis() / 1000
        }

        cookButton.setOnClickListener{
            var string = "${getCurrentLevel()} at ${getTimeStamp()}"
            textView.text = string
        }

        clearButton.setOnClickListener{
            var string = "${getCurrentLevel()} at ${getTimeStamp()}"
            textView.text = "@+string/appname"

        }
    }
}