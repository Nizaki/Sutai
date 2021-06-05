using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    public List<GameObject> doors;

    public void ShowDoor()
    {
        doors.ForEach(door => door.SetActive(true));
    }

    public void HideDoor()
    {
        doors.ForEach(door => door.SetActive(false));
    }
}