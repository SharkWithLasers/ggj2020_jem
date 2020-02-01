using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/Meta")]
public class PlayerMeta : ScriptableObject
{
    [SerializeField] private int playerId = 1;
    public int PlayerId { get { return playerId; } }

    public string InputPrefix => $"Player{playerId}_";
}
