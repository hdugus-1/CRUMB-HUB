using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public asteroid[] droid;

    asteroid asteroids;
    public float spawnRate = 3.0f;
    public float trajectory = 15.0f;
    public int spawnAmount = 1;

    private void Start()
    {

    }

    public void startSpawning()
    {
        InvokeRepeating(nameof(spawnAsteroid), spawnRate, spawnRate);
    }

    public void stopSpawning()
    {
        CancelInvoke();
    }




    private void spawnAsteroid()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            float distvec = 0;
            Vector3 flattenedpos;
            Vector3 asteroidspawnDirection = Vector3.one;
            Vector3 asteroidspawnPoint = Vector3.one;
            flattenedpos = UnityEngine.Random.onUnitSphere * 40;
            flattenedpos.y = 1.8f;
            asteroidspawnDirection = flattenedpos;
            asteroidspawnPoint = (GameObject.FindGameObjectWithTag("Spaceship").transform.position) + asteroidspawnDirection;
            distvec = Vector3.Distance(asteroidspawnPoint, GameObject.FindGameObjectWithTag("Spaceship").transform.position);
            while (distvec < 30)
            {
                flattenedpos = UnityEngine.Random.onUnitSphere * 40;
                flattenedpos.y = 1.8f;
                asteroidspawnDirection = flattenedpos;
                asteroidspawnPoint = (GameObject.FindGameObjectWithTag("Spaceship").transform.position) + asteroidspawnDirection;
                distvec = Vector3.Distance(asteroidspawnPoint, GameObject.FindGameObjectWithTag("Spaceship").transform.position);
            }

            float asteroidvariance = UnityEngine.Random.Range(-this.trajectory, this.trajectory);
            Quaternion asteroidrotation = Quaternion.AngleAxis(asteroidvariance, Vector3.up);
            int asteroidchoice = UnityEngine.Random.Range(0, droid.Length);
            asteroid asteroidprefab = Instantiate(droid[asteroidchoice], asteroidspawnPoint, asteroidrotation);
            asteroidprefab.size = UnityEngine.Random.Range(asteroidprefab.minsize, asteroidprefab.maxsize);
            asteroidprefab.SetTrajectory(asteroidrotation * -asteroidspawnDirection);

        }

    }
}
