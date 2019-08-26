using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 3;
    public float size = 0;
    public int cameraIncreaseIncrement = 5; // how much the size needs to crease before the camera gets larger
    public Camera camera;
    public Vector3 movingVector = Vector3.zero;

    float invulnerabilityTime = 0;
    float invulnerabilityTimer = 0;
    bool canTakeDamage = true;
    int previousSize = 0;
    int sizeIncreaseDifference = 0;

    SpriteRenderer sr;
    private IEnumerator flashC;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        size = 15;
        previousSize = (int) size;
        camera.orthographicSize = 5 * (size / 25);
    }

    // Update is called once per frame
    void Update()
    {
        sizeIncreaseDifference += Mathf.Abs((int)size - previousSize);

        //When the player press left mouse they move towards the mouse position
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            movingVector = -(transform.position - mousePos) / 10;
            transform.position += movingVector;
        }

        //If invulnerability is activated the player will not be able to take any damage
        if(invulnerabilityTimer < invulnerabilityTime){
            invulnerabilityTimer += Time.deltaTime;
            canTakeDamage = false;
        } else{
            canTakeDamage = true;
            sr.enabled = true;
        }

        //When the players health is 0 or less they will die
        if(health <= 0){
            Death();
        }

        //When the player has increase in size enough the camera will change size
        if (sizeIncreaseDifference >= cameraIncreaseIncrement)
        {
            camera.orthographicSize = Vector3.Slerp(new Vector3(camera.orthographicSize, 0, 0), new Vector3(5 * (size / 25), 0, 0), 0.1f).x;
            print(camera.orthographicSize + " " + 5 * (size / 25));
            //Makes sure the camera is the correct size before resetting the counter
            if(camera.orthographicSize >= (5 * (size / 25))-0.05f)
            {
                sizeIncreaseDifference = 0;
            }

        }
        //The players size will chance immediatly
        transform.localScale = new Vector3((size / 50) * 2, (size / 50) * 2, (size / 50) * 2);
        previousSize = (int) size;
    }

    //Called when the player dies. It currently reloads the scene. This will need to be changed later
    void Death(){
        //Application.LoadLevel(0);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //Removed X amount of health from the player
    public void Damage(int amount){
        health -= amount;
    }

    //Called when the player takes damage and activates the invulnerability
    public void Invulnerability(float time){
        invulnerabilityTime = time;
        //Enables the blinking effect
        flashC = Flash(time);
        StartCoroutine(flashC);
        Flash(time);
    }

    //When the player touches an enemy the Danger and Invulnerability functions are called
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy_Basic>() != null)
        {
            Enemy_Basic eb = collision.gameObject.GetComponent<Enemy_Basic>();
            //If the enemies size is more than the playes, the player takes damage
            //If the enemies size is less than the players, the enemy is destroyed and the players size increases
            if(eb.size > size){
                Damage(1);
                Invulnerability(2);
            } else if(eb.size < size){
                size += eb.size / 5;
                if(size > 50){
                    size = 50;
                }

                Spawning.respawn(collision.gameObject, this.gameObject);

               
                //Destroy(collision.gameObject);
            }

        }
    }

    /*
     * An IEnumerator is used so that other processs can run while the player is blinking
     * instead of waiting until it has finished.
     * The player swithced between 25% and 100% alpha every 0.1 seconds
     */
    IEnumerator Flash(float time)
    {
        for (int n = 0; n < time/0.2f; n++)
        {
            sr.color = new Color(255, 255, 255, 0.25f);
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(0.1f);
        }
        sr.color = new Color(255, 255, 255, 1);
        StopCoroutine(flashC);
    }
}
