using System;
using System.IO.Ports;
using UnityEngine;

/// <summary>
/// Handles the Input from the Arduino using a Serial Communicator.
/// </summary>
public class Arduino : MonoBehaviour
{
    [SerializeField]
    private int commPort;
    private SerialPort serial = null;
    public static string cardTag;

    private void Start()
    {
        ConnectToSerial();
    }

    private void Update()
    {
        cardTag = GetArduinoInput(); // Stores the RFID tag as a string called cardTag
        Debug.Log(GetArduinoInput());
    }

    private void ConnectToSerial()
    {
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
    }

    /// <summary>
    /// When the RFID cards are tapped against the reader a string of mixed characters should be produced by the arduino.
    /// </summary>
    /// <returns>String</returns>
    private string GetArduinoInput()
    {
        String value = ReadFromArduino(50);

        if (value != null)
        {
            return value;
        }

        return null;
    }

    private float GetArduinoMeterInput()
    {
        WriteToArduino("O");
        String value = ReadFromArduino(50);

        if (value != null)
        {
            return float.Parse(value);
        }

        return 0;
    }

    private void WriteToArduino(string message)
    {
        serial.WriteLine(message);
        serial.BaseStream.Flush();
    }
    /// <summary>Reads whatever the Arduino has printed to the Serial lane.</summary>
    /// <param name="timeout">Stops reading after a certain time.</param>
    /// <returns>A string from the Arduino.</returns>
    private string ReadFromArduino(int timeout = 0)
    {
        serial.ReadTimeout = timeout;

        try
        {
            return serial.ReadLine();
        }

        catch
        {
            return null;
        }
    }

    private void OnDestroy()
    {
        serial.Close();
    }
}