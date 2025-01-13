using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Vector3 teleportLocation;
    public Transform orient;

    public void Teleport()
    {
        orient.position = teleportLocation;
    }


    public void TeleportScene()
    {
        PlayerPrefs.SetFloat("TeleportX", teleportLocation.x);
        PlayerPrefs.SetFloat("TeleportY", teleportLocation.y);
        PlayerPrefs.SetFloat("TeleportZ", teleportLocation.z);
    }
}
