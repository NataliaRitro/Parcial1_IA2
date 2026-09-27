using UnityEngine;

public class FreeState : IState
{
    EcosystemManager _animal;
    Vector3 _wanderTarget;

    public FreeState(EcosystemManager animal) { _animal = animal; }

    public void OnEnter() { GetNewRandomPoint(); }

    public void OnUpdate()
    {
        if (_animal.thirst >= _animal.limitThirst) { _animal._fsm.ChangeState("Drink"); return; }
        if (_animal.hunger >= _animal.limitHunger) { _animal._fsm.ChangeState("Eat"); return; }
        if (_animal.energy <= _animal.limitEnergy) { _animal._fsm.ChangeState("Rest"); return; }

        if (Vector3.Distance(_animal.transform.position, _wanderTarget) < 1.5f)
            GetNewRandomPoint();

        _animal.AddForce(_animal.Seek(_wanderTarget));
    }

    public void OnExit() { }

    void GetNewRandomPoint()
    {
        _animal.maxVelocity = 3f;
        _wanderTarget = _animal.transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
