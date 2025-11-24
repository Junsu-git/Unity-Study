using NUnit.Framework.Constraints;
using UnityEngine;

public class CarrotPoolManager : MonoBehaviour
{
    public CarrotMove carrotPref;
    public GameManager gm;
    public int poolSize = 10;
    CarrotMove[] carrotPool;
    float startDelay = 0.1f;
    float gameTime = 0f;
    float createTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carrotPool = new CarrotMove[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            CarrotMove carrot = Instantiate(carrotPref);
            carrotPool[i] = carrot;
            carrot.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.ready) return;
        if (gm.end) return;
        gameTime += Time.deltaTime;
        if (gameTime <= startDelay)
            return;


        createTime += Time.deltaTime;
        if (createTime >= 1.5f)
        {
            for(int i = 0; i < poolSize; i++)
            {
                CarrotMove carrot = carrotPool[i];
                if(carrot.gameObject.activeSelf == false)
                {
                    carrot.gameObject.SetActive(true);
                    carrot.CarrotInit();
                    createTime = 0;
                    break;
                }
            }
        }
    }
}
