using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField]
    public Unit PlayerUnitPrefab { get; private set; }
    [field: SerializeField]
    public Transform PlayerUnitSpawnPoint { get; private set; }
}
