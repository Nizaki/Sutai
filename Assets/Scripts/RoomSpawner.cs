using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class RoomSpawner : MonoBehaviour
{
    public RoomDirection openingDirection;
    public bool spawned;
    private int rand;
    private Transform root;
    private RoomTemplates template;

    private void Start()
    {
        template = GameObject.FindGameObjectWithTag("Template").GetComponent<RoomTemplates>();
        root = GameObject.FindGameObjectWithTag("RootRoom").transform;
        Invoke(nameof(SpawnRoom), 0.2f);
        DataBank.score += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomSpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) Destroy(gameObject);

            spawned = true;
        }
    }

    // Update is called once per frame
    private void SpawnRoom()
    {
        if (spawned)
            return;
        GameObject go = null;
        switch (openingDirection)
        {
            case RoomDirection.Bottom:
                rand = Random.Range(0, template.bottomRooms.Length);
                go = Instantiate(template.bottomRooms[rand], transform.position,
                    template.bottomRooms[rand].transform.rotation);
                break;
            case RoomDirection.Top:
                rand = Random.Range(0, template.topRooms.Length);
                go = Instantiate(template.topRooms[rand], transform.position,
                    template.topRooms[rand].transform.rotation);
                break;
            case RoomDirection.Left:
                rand = Random.Range(0, template.leftRooms.Length);
                go = Instantiate(template.leftRooms[rand], transform.position,
                    template.leftRooms[rand].transform.rotation);
                break;
            case RoomDirection.Right:
                rand = Random.Range(0, template.rightRooms.Length);
                go = Instantiate(template.rightRooms[rand], transform.position,
                    template.rightRooms[rand].transform.rotation);
                break;
            default:
                Debug.Log("Out of range");
                break;
        }

        if (go != null)
        {
            go.transform.parent = root;
            var room = go.AddComponent<Room>();
            room.spawnable = true;
            room.rt = template;
            template.rooms.Add(room);
        }

        spawned = true;
    }
}

public enum RoomDirection
{
    Top,
    Bottom,
    Left,
    Right
}