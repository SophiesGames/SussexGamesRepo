using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float maxViewDst = 3;
    public Transform player;
    public GameObject backgroundImage;

    int chunkSize;
    int chunksVisibleInViewDst;

    Dictionary<Vector2, BackgroundChunk> BackgroundChunkDictionary = new Dictionary<Vector2, BackgroundChunk>();
    List<BackgroundChunk> BackgroundChunksVisibleLastUpdate = new List<BackgroundChunk>();

    void Start()
    {
        chunkSize = 10;
        chunksVisibleInViewDst = Mathf.RoundToInt(maxViewDst / chunkSize);
    }

    void Update()
    {
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {

        for (int i = 0; i < BackgroundChunksVisibleLastUpdate.Count; i++)
        {
            BackgroundChunksVisibleLastUpdate[i].SetVisible(false);
        }
        BackgroundChunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(player.position.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(player.position.y / chunkSize);

        for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (BackgroundChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    BackgroundChunkDictionary[viewedChunkCoord].UpdateBackgroundChunk(player, maxViewDst);
                    if (BackgroundChunkDictionary[viewedChunkCoord].IsVisible())
                    {
                        BackgroundChunksVisibleLastUpdate.Add(BackgroundChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    BackgroundChunkDictionary.Add(viewedChunkCoord, new BackgroundChunk(viewedChunkCoord, chunkSize, transform, backgroundImage));
                }

            }
        }
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
            SetVisible(false);
        }

        public void UpdateBackgroundChunk(Transform player, float maxViewDst)
        {
            float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(player.position));
            bool visible = viewerDstFromNearestEdge <= maxViewDst;
            SetVisible(visible);
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }

    }

}
