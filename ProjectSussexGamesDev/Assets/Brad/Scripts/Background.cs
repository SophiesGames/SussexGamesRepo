using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float maxViewDst = 3;
    public Transform player;
    public GameObject backgroundImage;
    public int poolSize = 20;

    int chunkSize;
    int chunksVisibleInViewDst;

    int previousChunkCoordX = 0;
    int previousChunkCoordY = 0;

    Player playerObj;

    Queue<Vector2> pool = new Queue<Vector2>();
    Dictionary<Vector2, BackgroundChunk> BackgroundChunkDictionary = new Dictionary<Vector2, BackgroundChunk>();

    void Start()
    {
        playerObj = player.GetComponent<Player>();
        chunkSize = 10;
        chunksVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);
    }

    void Update()
    {

        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {

        int currentChunkCoordX = Mathf.RoundToInt(player.position.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(player.position.y / chunkSize);

        bool changePreviousCoords = false;
        
        for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                if (BackgroundChunkDictionary.Count < poolSize) {
                    addToPool(viewedChunkCoord);
                }
                if (currentChunkCoordX != previousChunkCoordX || currentChunkCoordY != previousChunkCoordY) {
                    Vector2 key = pool.Dequeue();
                    BackgroundChunkDictionary[key].setNewPosition(viewedChunkCoord, chunkSize);
                    pool.Enqueue(key);
                    changePreviousCoords = true;
                }

            }
        }
        if (changePreviousCoords == true)
        {
            previousChunkCoordX = currentChunkCoordX;
            previousChunkCoordY = currentChunkCoordY;
        }
        
    }

    void addToPool(Vector2 viewedChunkCoord)
    {
        BackgroundChunkDictionary.Add(viewedChunkCoord, new BackgroundChunk(viewedChunkCoord, chunkSize, transform, backgroundImage));
        pool.Enqueue(viewedChunkCoord);
    }

    public class BackgroundChunk
    {

        GameObject meshObject;
        Vector2 position;
        Bounds bounds;


        public BackgroundChunk(Vector2 coord, int size, Transform parent, GameObject backgroundImage)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, position.y, 400);

            meshObject = Instantiate(backgroundImage);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size / 7.5f;
            meshObject.transform.parent = parent;
        }

        public void setNewPosition(Vector2 coord, int size){
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, position.y, 400);

            meshObject.transform.position = positionV3;
        }

    }

}
