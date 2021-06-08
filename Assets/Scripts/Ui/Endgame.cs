using UnityEngine;

public class Endgame : MonoBehaviour
{
    public RoomTemplates rt;

    public GameObject endscene;

    // Start is called before the first frame update
    private void Start()
    {
        rt.onRoomClear.AddListener(CheckEndGame);
    }

    private void CheckEndGame()
    {
        if (rt.rooms.Count == rt.cleared) endscene.SetActive(true);
    }
}