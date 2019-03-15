using UnityEngine;

public class TerrainGene : MonoBehaviour
{
    public int width = 500;
    public int height = 500;
    public int depth = 50;

    public float scale = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = generateTerrain(terrain.terrainData);
    }

    TerrainData generateTerrain(TerrainData terrainData) {
        terrainData.heightmapResolution = width;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, generateHeight());
        return terrainData;
    }

    float[,] generateHeight() {
        float[,] heights = new float[width, height];
        for (int a = 0; a < width; a++) {
            for (int b = 0; b < height; b++){
                heights[a, b] = calculateHeight(a, b);
            }
        }
        return heights;
    }

    float calculateHeight(int a, int b) {
        float xCoord = (float) a / width * scale;
        float yCoord = (float) b / height * scale;

        return Mathf.PerlinNoise(xCoord, yCoord); 
    }
}
