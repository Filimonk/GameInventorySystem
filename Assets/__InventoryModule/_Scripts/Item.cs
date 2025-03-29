using System;
using UnityEngine;

public abstract class Item
{
    public event Action OnDestroy;
    
    // метод, в котором должно вызываться инстанцирование MonoBehaviour-объекта
    // с координатами position и размером size - отображение объекта, соответствующее объекту данного типа
    public abstract void InstantiateMonoBehaviourObject(Vector3 position, Vector2 size);

    // метод, вызываемый при использовании предмета из инвентаря
    public abstract void ApplyOneTime();

    public abstract void ChangePosition(Vector2 position);
    
    // метод, который должен быть вызван при удалении объекта данного типа, он очистит поле в инвентаре
    protected virtual void Destroy()
    {
        OnDestroy?.Invoke();
    }
}
