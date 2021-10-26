using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private LevelGenerator _instance;

    public LevelGenerator Instance { get { return _instance; } }

    [Tooltip("An Array of Chunks to spawn.")]
    public GameObject[] levelChunks; // Chunks to spawn

    // The chunk you spawn at
    private GameObject spawnChunk;

    // The Chunk the player was last on before jumping through collider
    private GameObject previousChunk;

    [Tooltip("The starting spawn position.")]
    public Vector3 spawnOrigin;

    private Vector3 spawnPosition; // Position to spawn next chunk

    private bool hasSpawned = false;

    private bool isFirst = true;

    private int num = 0;

    private Queue<GameObject> passedChunks;


    /// <summary>
    /// Singleton Pattern
    /// </summary>
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        passedChunks = new Queue<GameObject>();
        spawnChunk = GameObject.FindWithTag("Spawn");
        previousChunk = spawnChunk;
        spawnPosition = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        //For testing
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnNextChunk();
        }*/
    }

    /// <summary>
    /// Calls SpawnNextChunk when player jumps through collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Respawn" && !hasSpawned)
        {
            hasSpawned = true;
            Invoke("SpawnNextChunk", .5f);
            
        }

        if(other.tag == "Reset")
        {
            if(passedChunks.Count > 0)
            {
                Destroy(passedChunks.Peek());
                passedChunks.Dequeue();
            }
            hasSpawned = false;
        }

    }


    /// <summary>
    /// Spawns next chunk and deletes previous chunk
    /// </summary>
    public void SpawnNextChunk()
    {
        passedChunks.Enqueue(previousChunk);
        spawnPosition += new Vector3(0, 0, -110f);
        
        var rand = Random.Range(0, levelChunks.Length);
        GameObject nextChunk = levelChunks[rand];
        GameObject clone = Instantiate(nextChunk, spawnPosition + spawnOrigin, Quaternion.identity);
        
        previousChunk = clone;
        
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }
}
