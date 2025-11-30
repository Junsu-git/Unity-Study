using TMPro;
using UnityEngine;

public class CarrotMove : MonoBehaviour
{
    public float carrotSpeed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * carrotSpeed * Time.deltaTime);

        if (transform.position.x < -9) 
            gameObject.SetActive(false);
        // destroy 로 되어있는 경우 가 있어요
        // 인보크 리피팅을 썻기 때문에 -> 무한으로 복사를 하는거거든요?

        // 그래서 이제 넘어가면 안보이게 바꾸고, 다시 풀 매니저에서 원래 위치로 이동시켜주는 역핧을 한다.
    }
    
    // on enable은 우리가 인보크 리피팅을 했잖아요 < 새로 복제될때 그 시점을 기준으로 위치가 되는거에요.
    // 오브젝트 풀링같은 경우는, 맨 처음에 복제를 다 해놓잖아요.

    // 그럼 사라지고 나서도 같은 위치에서만 생겨요.

    public void CarrotInit()
    {
        transform.position = new Vector2(9f, Random.Range(-2.2f, 2.2f));
    }
}