using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

   [System.Serializable]
   public class ArenaGroup
    {
        public string tag;
        public List<GameObject> enemies;
    }

    [SerializeField]
    List<ArenaGroup> arenaGroups;

    Dictionary<string, List<GameObject>> arenaGroupsDictionary;

    void Start()
    {
        arenaGroupsDictionary = new Dictionary<string, List<GameObject>>();

        foreach (ArenaGroup arenagroup in arenaGroups)
        {
            foreach(GameObject enemy in arenagroup.enemies)
            {
                enemy.SetActive(false);
            }
            arenaGroupsDictionary.Add(arenagroup.tag, arenagroup.enemies);
        }

    }

    public void SpawnEnemies(string tag)
    {
        foreach (GameObject enemy in arenaGroupsDictionary[tag])
        {
           GameObject particle =  ObjectPooler.instance.SpawnFromPool("EnemySpawnParticles", enemy.transform.position + new Vector3(0,0,-2), transform.rotation);
            particle.transform.parent = enemy.transform;
            particle.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            enemy.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SpawnEnemies("Arena_1");
        }
    }
}
