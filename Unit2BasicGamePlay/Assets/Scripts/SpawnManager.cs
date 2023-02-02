using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
   [SerializeField] private GameObject[] animals;
   
   [SerializeField] private float spawnRangeX = 20;
   [SerializeField] private float spawnPosZ = 20f;
   private Vector3 _spawnPos;
   private int _indexToSpawn;

   [SerializeField] private float timeBetweenAnimalSpawn = 2.5f;

   private void Start()
   {
     SpawnAnimal();
   }

   private void SpawnAnimal()
   {
      StartCoroutine(_SpawnAnimalCo());
   }

   private IEnumerator _SpawnAnimalCo()
   {
      yield return new WaitForSeconds(timeBetweenAnimalSpawn);
      
      _indexToSpawn = Random.Range(0, animals.Length);
      _spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnPosZ);

      Instantiate(animals[_indexToSpawn], _spawnPos, animals[_indexToSpawn].transform.rotation);

      StartCoroutine(nameof(_SpawnAnimalCo));
   }
}
