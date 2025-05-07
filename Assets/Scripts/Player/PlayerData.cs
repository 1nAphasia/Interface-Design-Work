using UnityEngine;

[CreateAssetMenu(menuName = "Character/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float attackDamage = 10f;
}