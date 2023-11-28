using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] LeftHandPoints;
    public GameObject[] RightHandPoints;


    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        if (data.Length != 0)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            string[] points = data.Split(',');
            if (points.Count() == 64)
            {
                if (points[0].Substring(1, 1) == "L")
                {
                    string[] leftPoints = points.Skip(1).Take(63).ToArray();
                    print(leftPoints.Count());
                    for (int i = 0; i < 21; i++)
                    {

                        float x = 7 - float.Parse(leftPoints[i * 3]) / 100;
                        float y = float.Parse(leftPoints[i * 3 + 1]) / 100;
                        float z = float.Parse(leftPoints[i * 3 + 2]) / 100;

                        LeftHandPoints[i].transform.localPosition = new Vector3(x, y, z);

                    }
                }
                else if (points[0].Substring(1, 1) == "R")
                {
                    string[] rightPoints = points.Skip(1).Take(63).ToArray();
                    for (int i = 0; i < 21; i++)
                    {

                        float x = 7 - float.Parse(rightPoints[i * 3]) / 100;
                        float y = float.Parse(rightPoints[i * 3 + 1]) / 100;
                        float z = float.Parse(rightPoints[i * 3 + 2]) / 100;

                        RightHandPoints[i].transform.localPosition = new Vector3(x, y, z);

                    }
                }
            }
            else
            {
                string[] leftPoints;
                string[] rightPoints;
                if (points[0].Substring(1,1) == "L")
                {
                    leftPoints = points.Skip(1).Take(63).ToArray();
                    rightPoints = points.Skip(65).Take(63).ToArray();
                }
                else
                {
                    leftPoints = points.Skip(65).Take(63).ToArray();
                    rightPoints = points.Skip(1).Take(63).ToArray();
                }
                for (int i = 0; i < 21; i++)
                {

                    float left_x = 7 - float.Parse(leftPoints[i * 3]) / 100;
                    float left_y = float.Parse(leftPoints[i * 3 + 1]) / 100;
                    float left_z = float.Parse(leftPoints[i * 3 + 2]) / 100;
                    float right_x = 7 - float.Parse(rightPoints[i * 3]) / 100;
                    float right_y = float.Parse(rightPoints[i * 3 + 1]) / 100;
                    float right_z = float.Parse(rightPoints[i * 3 + 2]) / 100;

                    LeftHandPoints[i].transform.localPosition = new Vector3(left_x, left_y, left_z);
                    RightHandPoints[i].transform.localPosition = new Vector3(right_x, right_y, right_z);

                }
            }
        }
    }
}
