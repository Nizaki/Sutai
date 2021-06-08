using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) transform.DOShakePosition(0.25f, 1.5f, 35).OnComplete(test);
    }

    private void test()
    {
    }
}