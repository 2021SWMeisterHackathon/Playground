using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    [Serializable]
    private struct RandomPositionRange
    {
        public float MinX;
        public float MaxX;
        public float MinY;
        public float MaxY;
    }

    [SerializeField] private RandomPositionRange spawnArea;
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        var spawnPosition = new Vector2(Random.Range(spawnArea.MinX, spawnArea.MaxX),
            Random.Range(spawnArea.MinY, spawnArea.MaxY));

        PhotonNetwork.Instantiate($"Prefabs/{playerPrefab.name}", spawnPosition, Quaternion.identity);
    }
}
