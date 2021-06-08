using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public List<Room> rooms;
    public int cleared;
    public UnityEvent onRoomClear;

    private void Start()
    {
        onRoomClear ??= new UnityEvent();
    }

    public void clear()
    {
        cleared += 1;
        onRoomClear.Invoke();
    }
}