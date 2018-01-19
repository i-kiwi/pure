using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    // 柏林噪声
    public float heightScale = 1.0F;
    public float xScale = 1.0F;

    void Update() {
        float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0F);
        Vector3 pos = transform.position;
        pos.y = height;
        transform.position = pos;
    }

    //序列化
    void serializeEntity()
    {
        Kiwi kk = new Kiwi("kkk", 18);
        byte[] data = SerializeHelper.SerializeToBinary(kk);
        FileUtils.write(data, System.Environment.CurrentDirectory + "/data/", "map.data");
        Debug.Log("over");
        byte[] readData = FileUtils.read(System.Environment.CurrentDirectory + "/data/map.data");
        Kiwi kiwi = SerializeHelper.DeserializeWithBinary<Kiwi>(readData);
        Debug.Log(kiwi.ToString());
    }
}