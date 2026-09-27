using UnityEngine;

public class EatState : IState
{
    EcosystemManager _animal;
    GameObject _targetFood;

    public EatState(EcosystemManager animal) { _animal = animal; }

    public void OnEnter()
    {
        _animal.maxVelocity = 6f;
        _targetFood = _animal.BuscarRecursoOptimo("Food");
    }

    public void OnUpdate()
    {
        if (_targetFood == null) { _animal._fsm.ChangeState("Free"); return; }

        _animal.AddForce(_animal.Arrive(_targetFood));

        if (Vector3.Distance(_animal.transform.position, _targetFood.transform.position) < 1.5f)
        {
            Object.Destroy(_targetFood);
            _animal.hunger = 0;
            _animal._fsm.ChangeState("Free");
        }
    }
    public void OnExit() { }
}
