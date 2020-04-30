using System;
using System.IO.Ports;
using UnityEngine;


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
        cardTag = GetArduinoInput();
        Debug.Log(GetArduinoInput());
    }

    private void ConnectToSerial()
    {
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
    }


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