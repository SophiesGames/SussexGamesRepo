using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pair : MonoBehaviour
{

    public GameObject pair_1;
    private Enemy_Basic pair_1Basic;
    public GameObject pair_2;
    private Enemy_Basic pair_2Basic;
    public GameObject beam;
    public GameObject radarBeam;

    private Radar radar;
    private Radar.Blip pair_1Blip;
    private Radar.Blip pair_2Blip;

    public float attackDelay = 5;
    public float attackTime = 3;
    public float maxPairDist = 10;

    public bool attacking = false;
    private float attackStartTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        radar = GameObject.Find("Radar").GetComponent<Radar>();
        attackDelay = Random.Range(3, 10) + attackTime;
        pair_1Basic = pair_1.GetComponent<Enemy_Basic>();
        pair_2Basic = pair_2.GetComponent<Enemy_Basic>();
        radar.createBlip(pair_1, new Color(255, 0, 0, 1), radarBeam);
        pair_1Blip = radar.blips[radar.blips.Count - 1];
        radar.createBlip(pair_2, new Color(255, 0, 0, 1), null);
        pair_2Blip = radar.blips[radar.blips.Count - 1];
        pair_1Basic.setSize(25);
        pair_2Basic.setSize(25);
        Spawning.enemies.Add(pair_1);
        Spawning.enemies.Add(pair_2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(pair_1.transform.position, pair_2.transform.position) > maxPairDist)
        {
            pair_1Basic.dir = -(pair_1.transform.position - pair_2.transform.position).normalized;
            pair_2Basic.dir = -(pair_2.transform.position - pair_1.transform.position).normalized;
        }

        if (Mathf.RoundToInt(GameInfo.timer)%attackDelay == 0)
        {
            attacking = true;
            
        }
        if (attacking == true)
        {
            if (attackStartTime == 0)
            {
                attackStartTime = GameInfo.timer;
            }
            
            pair_1Basic.freeze = true;
            pair_2Basic.freeze = true;

            pair_1Basic.dir = (pair_1.transform.position - pair_2.transform.position).normalized;
            pair_2Basic.dir = (pair_2.transform.position - pair_1.transform.position).normalized;

            Vector3 beamDir = pair_1.transform.position - pair_2.transform.position;
            float dist = beamDir.magnitude;

            beam.active = true;
            beam.transform.position = pair_2.transform.position + (beamDir/2);
            float angle = Mathf.Atan2(beamDir.y, beamDir.x) * Mathf.Rad2Deg;
            beam.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            beam.transform.localScale = new Vector3(0.25f, dist, 0);
            pair_1Blip.beam.active = true;
            pair_1Blip.updateBeam(pair_2Blip);
        }

        if ((GameInfo.timer - attackStartTime) >= attackTime && GameInfo.timer > attackTime && attacking == true)
        {
            print((GameInfo.timer - attackStartTime) + " " + attackStartTime);
            attacking = false;

            pair_1Basic.freeze = false;
            pair_2Basic.freeze = false;
            attackStartTime = 0;
            beam.active = false;
            attackDelay = Random.Range(3, 10) + attackTime;
            pair_1Basic.setSize(25);
            pair_2Basic.setSize(25);
            pair_1Blip.beam.active = false;
        }
    }
    
}
