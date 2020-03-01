using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EmptyObject;
    public GameObject[] defWall;
    public GameObject[] defBackground;
    public GameObject[] defDecor;
    public GameObject[] defBlock;
    public GameObject defdoor;
    public GameObject deffloor;
    public GameObject[] enemies;
    public int w;
    public int h;
    public bool[] doorsOpen;


    void Start()
    {
        GenerateRoom(w, h, defWall, defDecor, defBackground, defdoor, deffloor, doorsOpen, defBlock, EmptyObject, enemies);
    }

    public void GenerateRoom(int width, int height, GameObject[] Wall, GameObject[] Decor, GameObject[] Background, GameObject door, GameObject floor, bool[] doors, GameObject[] blocks, GameObject emptyboy, GameObject[] newEnemies){
        GameObject papa = (GameObject) Instantiate(emptyboy, (new Vector2(0,0)), Quaternion.identity);
        w = width;
        h = height;
        defWall = Wall;
        defDecor = Decor;
        defBackground = Background;
        defdoor = door;
        deffloor = floor;
        defBlock = blocks;
        doorsOpen = doors;
        EmptyObject = emptyboy;
        enemies = newEnemies;
        for(int x = -30; x < 30; x++){
            for(int y = -30; y < 30; y++){
                GameObject beans = (GameObject) Instantiate(Background[Random.Range(0,Background.Length)], (new Vector2(x,y)), Quaternion.identity);
                beans.transform.parent = papa.transform;
            }
        }

        for(float x = (float) -width; x <= width; x += 0.5f){
            Vector2 top = new Vector2(x, (float) height);
            Vector2 bot = new Vector2(x, (float) -height);
            GameObject bean = (GameObject) Instantiate(Wall[Random.Range(0, Wall.Length)], top, Quaternion.identity);
            GameObject beany = (GameObject) Instantiate(Wall[Random.Range(0, Wall.Length)], bot, Quaternion.identity);
            bean.transform.parent = papa.transform;
            beany.transform.parent = papa.transform;
        }

        for(float y = (float) -height; y < height; y+= 0.5f){
            Vector2 lef = new Vector2((float) -width, y);
            Vector2 rig = new Vector2((float) width, y);
            GameObject AwBeans = (GameObject) Instantiate(Wall[Random.Range(0, Wall.Length)], lef, Quaternion.identity);
            GameObject AwShucks = (GameObject) Instantiate(Wall[Random.Range(0, Wall.Length)], rig, Quaternion.identity);
            AwBeans.transform.parent = papa.transform;
            AwShucks.transform.parent = papa.transform;
        }
        for(float y = (float) -height*2; y < height*2; y += 0.5f){
            for(float x = (float) -width*2; x < width*2; x += 0.5f){
                if((x < -width || x > width || y < -height || y > height)){
                    GameObject bean = (GameObject) Instantiate(floor, (new Vector2(x,y)), Quaternion.identity);
                    bean.transform.parent = papa.transform;
                }
            }
        }

        if(doors[0]){
            GameObject hoi = (GameObject) Instantiate(door, (new Vector2(0, height)), Quaternion.identity);
            hoi.transform.parent = papa.transform;
        }
        if(doors[1]){
            GameObject hoi = (GameObject) Instantiate(door, (new Vector2(width, 0)), Quaternion.identity);
            hoi.transform.parent = papa.transform;
        }
        if(doors[2]){
            GameObject hoi = (GameObject) Instantiate(door, (new Vector2(0, -height)), Quaternion.identity);
            hoi.transform.parent = papa.transform;
        }
        if(doors[3]){
            GameObject hoi = (GameObject) Instantiate(door, (new Vector2(-width, 0)), Quaternion.identity);
            hoi.transform.parent = papa.transform;
        }

        for(float x = (float) -width+2; x < width-2; x += 0.5f){
            for(float y = (float) -height+2; y < height-2; y += 0.5f){
                int chance = Random.Range(0,99);
                if(!(x == 0f && y == 0f)){
                    if(chance < 5){
                        GameObject bean = (GameObject) Instantiate(blocks[Random.Range(0, blocks.Length)], (new Vector2(x, y)), Quaternion.identity);
                        bean.transform.parent = papa.transform;
                    } else if (chance <= 10 ){
                        GameObject evilBean = (GameObject) Instantiate(enemies[Random.Range(0, enemies.Length)], (new Vector2(x, y)), Quaternion.identity);
                        evilBean.transform.parent = papa.transform;
                    }
                }
            }
        }
    }
}
