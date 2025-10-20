using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool alive;
    [SerializeField] private bool hostile;

    [SerializeField] private Movement characterMovement;
    [SerializeField] private bool isPlayer;
    /*
     * [SerializeField] private Weapon[] weapons
     * [SerializeField] private Weapon activeWeapon;
     * [SerializeField] private Skill[] skills;
     * [SerializeField] private Skill activeSkill;
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Die()
    {
        alive = false;
    }
    public bool Alive
    {
        get
        {
            return alive;
        }
        set
        {
            alive = value;
        }
    }
    public Movement CharacterMovement
    {
        get { return characterMovement; }
    }
}
