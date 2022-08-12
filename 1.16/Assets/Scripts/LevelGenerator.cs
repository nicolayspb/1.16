using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public int MinPlat;
    public int MaxPlat;
    public float DistanceBetweenPlat;
    public Transform FinishPlat;
    public Transform CylinderRoot;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.levelIndex;
        Random random = new Random(levelIndex);
        int platformCount = RandomRange(random, MinPlat, MaxPlat + 1);

        for (int i = 0; i < platformCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platform = Instantiate(PlatformPrefabs[prefabIndex], transform);
            platform.transform.localPosition = Calculate(i);
            if(i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }

        FinishPlat.localPosition = Calculate(platformCount);

        CylinderRoot.localScale = new Vector3(0.25f, platformCount * 0.22f + 0.2f, 0.25f);
    }

    private int RandomRange(Random random, int min, int max)
    {
        int number = random.Next();
        int length = max - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 Calculate(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlat * platformIndex, 0);
    }
}

