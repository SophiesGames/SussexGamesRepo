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
    [HideInInspector]
    public List<Blip> blips = new List<Blip>();
    private Player playerObj;

    private void Start()
    {
        playerObj = player.GetComponent<Player>();
        gameObject.transform.position = new Vector2(Screen.width/2, 250);
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

    public void createBlip(GameObject enemy, Color color, GameObject beam)
    {
        Vector3 pos = player.transform.position - enemy.transform.position;
        Blip newBlip = new Blip(enemy, enemyBlip, blipParent, color, beam);
        blips.Add(newBlip);
    }

    public class Blip
    {

        public GameObject enemy;
        public Enemy_Basic enemyBasic;
        public GameObject blip;
        public Transform blipParent;
        public Image blipImage;
        public Color color;
        public GameObject beam;
        public RectTransform beamTransform;

        public Blip(GameObject enemy, GameObject blipPrefab, Transform blipParent, Color color, GameObject beam)
        {
            this.enemy = enemy;
            this.blipParent = blipParent;
            this.enemyBasic = enemy.GetComponent<Enemy_Basic>();
            this.color = color;
            if (beam != null)
            {
                this.beam = Instantiate(beam, Vector2.zero, Quaternion.identity, blipParent);
                beamTransform = this.beam.GetComponent<RectTransform>();
            }
            
            

            this.blip = Instantiate(blipPrefab, Vector2.zero, Quaternion.identity, blipParent);
            this.blipImage = this.blip.GetComponent<Image>();
        }

        public void update(Transform target, float maxDist)
        {
            float dist = Vector3.Distance(target.position, enemy.transform.position);
            blip.transform.localScale = new Vector2(enemyBasic.size/50, enemyBasic.size/50);
            Vector3 pos = new Vector3(0, -10000, 0);
            if (dist <= maxDist)
            {
                pos = (enemy.transform.position - target.position) * (200/maxDist);
                color.a = 3 - (dist / maxDist) * 3;
                blipImage.color = color;
            }
            
            blip.transform.position = pos+blipParent.transform.position;
        }

        public void updateBeam(Blip otherBlip)
        {
            Vector3 pos = otherBlip.blip.transform.position;
            Vector3 beamDir = blip.transform.position - pos;
            float dist = beamDir.magnitude;
            beam.transform.position = pos + (beamDir / 2);

            float angle = Mathf.Atan2(beamDir.y, beamDir.x) * Mathf.Rad2Deg;
            beam.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            beamTransform.sizeDelta = new Vector3(5, dist/2, 0);

        }
    }

}


