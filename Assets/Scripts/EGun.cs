using UnityEngine;

public class EGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform player;
    [SerializeField] private float FireRate = 1f;
    [SerializeField] private Transform shootPosition;
    private float nextFire;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = player.position - transform.position;
        var dir = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(dir, Vector3.forward),
            1.25f * Time.deltaTime);
        if (!(ShootArea(dir) < 5f)) return;
        if (!(Time.time > nextFire)) return;
        nextFire = Time.time + Random.Range(FireRate, FireRate + 1f);
        var go = Instantiate(bullet, shootPosition.position, Quaternion.AngleAxis(dir, Vector3.forward));
        go.GetComponent<Bullet>().targetTag = "Player";
        Debug.Log("Shoot");
    }

    private float ShootArea(float dir)
    {
        return Mathf.Abs(WrapAngle(transform.eulerAngles.z) - dir);
    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}