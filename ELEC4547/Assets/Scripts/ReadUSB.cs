// This plugin read the data streaming from VRduino and attach the read
// quaternion values to the corresponding object.
//
// This plugin is initially written by Vasanth Mohan, and modified by
// Varsha Sankar and Sagar Honnungar to be compatible with Windows.
using System;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class ReadUSB : MonoBehaviour
{
    const int baudrate = 115200;
    const string portName = "COM10";

    SerialPort serialPort = new SerialPort(portName, baudrate);

    void Start()
    {

        serialPort.ReadTimeout = 100;
        serialPort.Open();
        if (!serialPort.IsOpen)
        {
            Debug.LogError("Couldn't open " + portName);
        }
    }

    void Update()
    {

        /**List<byte> buffer = new List<byte>();

        // Read 40 bytes (39 = 3(QC ) + 4 * 9(1 float+ ))
        for (int i = 0; i < 40; i++)
        {
            buffer.Add((byte)serialPort.ReadByte());
        }

        // Convert list of bytes to string
        string text = System.Text.Encoding.UTF8.GetString(buffer.ToArray());


        // Split string into lines
        string[] lines = text.Split('\n');
        string[] line = lines[0].Split(' ');

        if (line[0] == "QC")
        {
            float quat_x = HexToFloat(line[1]);
            float quat_y = HexToFloat(line[2]);
            float quat_z = HexToFloat(line[3]);
            float quat_w = HexToFloat(line[4]);

            Quaternion q = new Quaternion(-quat_y, -quat_z, -quat_x, -quat_w);

            q.Normalize();

            // Convert the quaternion to Euler angles and add 180 to the z component
            Vector3 euler = q.eulerAngles;
            euler.z += 180;

            // Convert the Euler angles back to a quaternion and assign it to the transform
            transform.rotation = Quaternion.Euler(euler);
        }**/
        if (serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                Debug.Log("IMU Data: " + data);
                string[] line = data.Split(' ');
                if (line[0] == "QC")
                {
                    float quat_x = HexToFloat(line[1]);
                    float quat_y = HexToFloat(line[2]);
                    float quat_z = HexToFloat(line[3]);
                    float quat_w = HexToFloat(line[4]);

                    Quaternion q = new Quaternion(-quat_y, -quat_z, -quat_x, -quat_w);

                    q.Normalize();

                    // Convert the quaternion to Euler angles and add 180 to the z component
                    Vector3 euler = q.eulerAngles;
                    euler.z += 180;

                    // Convert the Euler angles back to a quaternion and assign it to the transform
                    transform.rotation = Quaternion.Euler(euler);
                }
            }
            catch (System.Exception) { }
        }
    }

    void OnGUI()
    {
        string euler = "Euler angle: " + transform.eulerAngles.x + ", " +
                        transform.eulerAngles.y + ", " + transform.eulerAngles.z;
    }

    public static float HexToFloat(string hexVal)
    {
        byte[] data = new byte[hexVal.Length / 2];
        for (int i = 0; i < data.Length; ++i)
        {
            data[i] = Convert.ToByte(hexVal.Substring(i * 2, 2), 16);
        }
        return BitConverter.ToSingle(data, 0);
    }
}