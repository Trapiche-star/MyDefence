using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;  // Cube (종점)
    public float speed = 2f;

    void Update()
    {
        // Cube 쪽으로 이동
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Cube에 거의 도착했는지 확인
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            Debug.Log("종점 도착!!!"); // 콘솔에 출력
            Destroy(gameObject);       // Enemy 오브젝트 삭제
        }
    }
}