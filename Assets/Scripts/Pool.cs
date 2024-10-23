using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Warrior _wariorPrefab;

    private Stack<Warrior> _warriors = new Stack<Warrior>();

    public void Return(Warrior warrior)
    {
       warrior.gameObject.SetActive(false);

       _warriors.Push(warrior);
    }

    public Warrior GetWarrior(Vector3 position) 
    {
        if (_warriors.TryPop(out Warrior warrior))
        {
            warrior.transform.position = position;
            warrior.gameObject.SetActive(true);

            return warrior;
        }

        return Instantiate(_wariorPrefab, position, Quaternion.identity);
    }
}