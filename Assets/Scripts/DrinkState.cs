using UnityEngine;

public class DrinkState : IState
{
    EcosystemManager _animal;
    GameObject _targetWater;

    public DrinkState(EcosystemManager animal) { _animal = animal; }

    public void OnEnter()
    {
        _animal.maxVelocity = 6f;
        _targetWater = _animal.BuscarRecursoOptimo("Water");
    }

    public void OnUpdate()
    {
        if (_targetWater == null) { _animal._fsm.ChangeState("Free"); return; }

        _animal.AddForce(_animal.Arrive(_targetWater));

        if (Vector3.Distance(_animal.transform.position, _targetWater.transform.position) < 1.5f)
        {
            _animal.StopMovement();
            _animal.thirst -= Time.deltaTime * 50f;

            if (_animal.thirst <= 0)
            {
                _animal.thirst = 0;
                _animal._fsm.ChangeState("Free");
            }
        }
    }
    public void OnExit() { }
}
