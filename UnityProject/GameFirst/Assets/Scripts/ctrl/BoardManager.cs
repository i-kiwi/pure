using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManager : MonoBehaviour
{
    public void SetupScene(int level)
    {
        BoardSetup();
    }


    void BoardSetup()
    {
        // 加载Resources中的Prefab并将clone对象放到字典中
        GameObject mapGrid = Instantiate(PrefabFactory.GetGameObject(PrefabFactory.PREFAB + "MapGrid"), Vector3.zero, Quaternion.identity);
        PrefabFactory.SetGameObject(PrefabFactory.PREFAB + "MapGrid", mapGrid);
        GameObject player1 = Instantiate(PrefabFactory.GetGameObject(PrefabFactory.PREFAB + "player1"), Vector3.zero, Quaternion.identity);
        PrefabFactory.SetGameObject(PrefabFactory.PREFAB + "player1", player1);
    }

}
