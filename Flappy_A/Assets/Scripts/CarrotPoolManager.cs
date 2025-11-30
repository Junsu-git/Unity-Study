using NUnit.Framework.Constraints;
using UnityEngine;

public class CarrotPoolManager : MonoBehaviour
{
    // 당근 복제품
    public CarrotMove carrtPref;

    // 게임 매니저 내부 필드(객체 안 변수) 사용을 위한 퍼블릭 변수
    public GameManager gm;
    // 미리 생성할 크기 (현재는 10이지만 인스펙터에서 조절해서 3)
    public int poolSize = 10;
    // 당근 배열
    CarrotMove[] carrotPool; // 여러개의 당근을 저장할 수 있는 그릇이에요. 접근자는 인덱스 > []
    // 시작 딜레이
    float startDelay = 0.1f;
    // 게임 타임 (게임 시작 이후 일정 시간 후에 나오게끔)
    float gameTime = 0f;
    // 생성 시간
    float createTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 풀링 코드 (미리 당근을 준비 시키는 코드)
        carrotPool = new CarrotMove[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            CarrotMove carrot = Instantiate(carrtPref);
            carrotPool[i] = carrot;
            carrot.gameObject.SetActive(false); // 생성한 당근 안보이게
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 준비가 안되면 생성하지 말아라 (시작할 때 탭 하지 않았을 때)
        if (gm.ready) return;
        // 게임이 끝나면 생성하지 말아라
        if (gm.end) return;

        // 시간이 증가됨
        gameTime += Time.deltaTime;

        // 만약 시작 딜레이를 넘지 않았다면 생성하지 말아라
        if (gameTime <= startDelay)
            return;

        // 생성 시간 증가
        createTime += Time.deltaTime;
        // 1.5초마다 생성
        if (createTime >= 1.5f)
        {
            for(int i = 0; i < poolSize; i++)
            {
                CarrotMove carrot = carrotPool[i];
                if(carrot.gameObject.activeSelf == false)
                {
                    carrot.gameObject.SetActive(true); // 당근 보이게 하고
                    // carrot.CarrotInit(); // 랜덤 위치로 이동시킴
                    createTime = 0;
                    break;
                }
            }
        }
    }
}
