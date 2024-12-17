using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] GameObject playerSword;
    [SerializeField] GameObject playerCharacter;
    [SerializeField] int maxSwords;
    int swords = 0;

    void OnFire()
    {
        if (swords < maxSwords)
        {
            GameObject Sword = Instantiate(playerSword, playerCharacter.transform.position, playerCharacter.transform.rotation);
            swords++;
        }
    }
    public void RemoveSword(GameObject sword)
    {
        if (swords > 0)
        {
            swords--;
        }
    }
}