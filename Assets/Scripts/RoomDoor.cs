using System.Collections.Generic;
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