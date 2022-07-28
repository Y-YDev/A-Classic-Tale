using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
	public string teleporterTag;
	public GameObject spawnPoint;
    public string targetScene = "Scene1";


	private void OnTriggerEnter2D(Collider2D collided)
	{
		if (collided.tag == "Player")
		{
			SceneManager.LoadScene(targetScene);
			GameManager.Instance.teleporterTag = teleporterTag;
		}
	}
}