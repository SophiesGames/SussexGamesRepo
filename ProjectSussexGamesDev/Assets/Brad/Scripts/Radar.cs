using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{

    public GameObject player;
    public float range = 10;

    public GameObject enemyBlip;
    public GameObject playerBlip;
    [SerializeField]
    private Transform blipParent;
    private List<Blip> blips = new List<Blip>();
    private Player playerObj;

    private void Start()
    {
        playerObj = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Blip blip in blips)
        {
            blip.update(player.transform, range);
        }
        playerBlip.transform.localScale = new Vector2(playerObj.size/25, playerObj.size / 25);
    }

    public void createBlip(GameObject enemy)
    {
        Vector3 pos = player.transform.position - enemy.transform.position;
        blips.Add(new Blip(enemy, enemyBlip, blipParent));
    }

    class Blip
    {

        public GameObject enemy;
        public Enemy_Basic enemyBasic;
        public GameObject blip;
        public Transform blipParent;
        public Image blipImage;

        public Blip(GameObject enemy, GameObject blipPrefab, Transform blipParent)
        {
            this.enemy = enemy;
            this.blipParent = blipParent;
            this.enemyBasic = enemy.GetComponent<Enemy_Basic>();
            

            this.blip = Instantiate(blipPrefab, Vector2.zero, Quaternion.identity, blipParent);
            this.blipImage = this.blip.GetComponent<Image>();
        }

        public void update(Transform target, float maxDist)
        {
            float dist = Vector3.Distance(target.position, enemy.transform.position);
            blip.transform.localScale = new Vector2(enemyBasic.size/50, enemyBasic.size/50);
            Vector3 pos = new Vector3(0, -300, 0);
            if (dist <= maxDist)
            {
                pos = (enemy.transform.position - target.position) * (100/maxDist);
                blipImage.color = new Color(255, 255, 255, 3 - (dist / maxDist) * 3);
            }
            
            blip.transform.position = pos+blipParent.transform.position;
        }
    }

}


