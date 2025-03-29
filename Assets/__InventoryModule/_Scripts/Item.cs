﻿using System;
using UnityEngine;

public abstract class Item
{
    private String name;
    private String description;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }
    public event Action OnDestroy;
    
    // метод, в котором должно вызываться инстанцирование MonoBehaviour-объекта
    // с координатами position и размером size - отображение объекта, соответствующее объекту данного типа
    public abstract void InstantiateMonoBehaviourObject(Vector3 position);

    // метод, вызываемый при использовании предмета из инвентаря
    public abstract void ApplyOneTime();

    // метод, в котором должно вызываться перемещение MonoBehaviour-объекта в координаты position
    //public abstract void ChangePosition(Vector3 position);
    
    // метод, который должен быть вызван при удалении объекта данного типа, он очистит поле в инвентаре
    protected virtual void Destroy()
    {
        OnDestroy?.Invoke();
    }
}
