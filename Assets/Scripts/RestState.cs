using UnityEngine;

public class RestState : IState
{
    EcosystemManager _animal;
    GameObject _restZone;

    public RestState(EcosystemManager animal) { _animal = animal; }

    public void OnEnter()
    {
        _restZone = _animal.BuscarRecursoOptimo("Rest");
    }

    public void OnUpdate()
    {
        if (_restZone != null && Vector3.Distance(_animal.transform.position, _restZone.transform.position) > 2f)
        {
            _animal.AddForce(_animal.Seek(_restZone.transform.position));
        }
        else
        {
            _animal.StopMovement();
            _animal.energy += Time.deltaTime * 15f;
        }

        if (_animal.energy >= 100f)
        {
            _animal.energy = 100f;
            _animal._fsm.ChangeState("Free");
        }
    }
    public void OnExit() { }
}
