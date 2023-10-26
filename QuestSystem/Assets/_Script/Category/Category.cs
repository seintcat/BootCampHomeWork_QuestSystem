using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Category", fileName = "category")]
public class Category : ScriptableObject, IEquatable<Category>
{
    [SerializeField]
    private string id;
    [SerializeField]
    private string _name;

    public string ID => id;
    public string Name => _name;

    public bool Equals(Category other)
    {
        if(other == null) return false;
        if(ReferenceEquals(this, other)) return true;
        if(GetType() != other.GetType()) return false;
        return id == other.id;
    }

    public override int GetHashCode() => (id, _name).GetHashCode();

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public static bool operator == (Category c, string id)
    {
        if(c == null)
            return ReferenceEquals(id, null);
        return c.id == id;
    }
    public static bool operator !=(Category c, string id) => !(c == id);
}
