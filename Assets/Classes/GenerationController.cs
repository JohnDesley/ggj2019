using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerationController : MonoBehaviour
{
    public List<GameObject> tilemaps;
    public GameObject tilemapClone;

    private void Start()
    {
        
        SortTilemaps();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tilemaps.Count <= 0) {
            return;
        }

        if(this.transform.position.x < tilemaps[1].transform.position.x) { // less then lowest generate and remove old
            AddTilemap(0);
            RemoveTilemap(tilemaps.Count - 1);
            SortTilemaps();
        } else if (this.transform.position.x > tilemaps[3].transform.position.x){ // more then generate and remove old
            AddTilemap(tilemaps.Count - 1);
            RemoveTilemap(0);
            SortTilemaps();
        }
    }

    private void AddTilemap(int index) {
        float x = tilemaps[index].transform.position.x;
        float y = tilemaps[index].transform.position.y;

        if(index > 0) {
            x += 8.83f;
            y += 4.35f;
        } else {
            x += -8.83f;
            y += -4.35f;
        }

        GameObject tilemap = Instantiate(tilemapClone, new Vector3(x, y, 0.0f), Quaternion.identity);
        tilemaps.Insert(index, tilemap);
    }

    private void SortTilemaps() {
        tilemaps.Sort((a, b) => a.transform.position.x.CompareTo(b.transform.position.x));
    }

    private void RemoveTilemap(int index) {
        Destroy(tilemaps[index]);
        tilemaps.RemoveAt(index);
    }
}
