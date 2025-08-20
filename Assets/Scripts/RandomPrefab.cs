using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPrefab : MonoBehaviour
{
    /*
    public ItemBaseInfo prefabs; 
    public Vector3 spawnAreaMin; 
    public Vector3 spawnAreaMax; 
    public int totalSpawnCount = 10;  //本次垃圾总量
    private int currentSpawnCount = 0; //已生成数量

    void Start()
    {
        //生成垃圾
        InvokeRepeating("SpawnPrefab", 0f, 0.9f);
    }

    void SpawnPrefab()
    {
        if (currentSpawnCount < totalSpawnCount)
        {
            int randomIndex = Random.Range(0, prefabs.Items.Count);
            GameObject selectedPrefab = prefabs.Items[randomIndex].Prefab;
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
            GameObject game = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            game.GetComponent<Draggable>().SetItem(prefabs.Items[randomIndex]);
            currentSpawnCount++;
        }
        else
        {
            //数量达标后停止
            CancelInvoke("SpawnPrefab");
        }
    }
    */

 
    public GameObject[] prefabs; // 预制体列表
    public Vector3 spawnAreaMin; // 生成范围的最小值（左下角）
    public Vector3 spawnAreaMax; // 生成范围的最大值（右上角）
    public int TotalSpawnCount;  // 总共要生成的预制体数量
    public int currentSpawnCount = 0; // 当前已经生成的预制体数量
    public float Interval = 1.2f;//间隔
    public float Intervall = 1.5f;//间隔零食
    public float Intervallz = 1.2f;//暂缓间隔
    public bool Shenchansu = true;
    public static RandomPrefab Instance;


    void Start()
    {
        Instance = this;
        InvokeRepeating("SpawnPrefab", 0f, Interval);
        FindObjectOfType<Switch>().Pause += Suspended;
        FindObjectOfType<Switch>().Runtime += functioning;
        FindObjectOfType<Switch>().Zanhuansud += Zanhuan;
        FindObjectOfType<Switch>().HfZanhuansud += FyZanhuan;
        FindObjectOfType<Reboot>().RebootL += Initialize;
       //s UImanager.Instance.Billing(TotalSpawnCount);

    } 
    public void Zanhuan()
    {
        Shenchansu = false;
        CancelInvoke("SpawnPrefab");
        InvokeRepeating("SpawnPrefab", 0.7f, Intervallz);
    }
    public void FyZanhuan()
    {
        Shenchansu = true;
        CancelInvoke("SpawnPrefab");
        InvokeRepeating("SpawnPrefab", 0.7f, Interval);
    }

    public void Initialize() 
    {
        currentSpawnCount = 0;
        InvokeRepeating("SpawnPrefab", 0.5f, Interval);
    }
    public void Suspended() 
    {
        CancelInvoke("SpawnPrefab");
    }
    public void functioning()
    {
        InvokeRepeating("SpawnPrefab", 0.5f, Interval);
    }
    void SpawnPrefab()
    {
        if (currentSpawnCount < TotalSpawnCount)
        {
            // 从预制体列表中随机选择一个
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject selectedPrefab = prefabs[randomIndex];
            // 在指定范围内随机生成一个位置
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
            // 实例化选中的预制体
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            currentSpawnCount++;
        }
        else
        {            
            //UImanager.Instance.finishes(totalSpawnCount);
            CancelInvoke("SpawnPrefab");
          //  Invoke("UImanager.Instance.finishes(totalSpawnCount)", 0.6f);
        }
    }
    public void Update()
    {
        if(currentSpawnCount==1)
        {
            Switch.Instance.gays();
        }
    }
    public void Currej()
    {
        currentSpawnCount++;
    }
}