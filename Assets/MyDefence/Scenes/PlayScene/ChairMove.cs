using UnityEngine;

public class MoveForward : MonoBehaviour
{

    void Start()
    {
        
    }
     public float speed = 5f; // 이동 속도

    void Update()
    {
        Debug.Log("앞으로 이동하기");

        // 매 프레임마다 앞으로 이동
        transform.position += transform.forward * speed * Time.deltaTime;

        // 디버그 로그로 현재 위치 확인
        Debug.Log("Current Position: " + transform.position);
    }
}