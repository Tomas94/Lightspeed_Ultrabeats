using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResources
{
    public void SpentResource(int quantity);
    public void GainResource(int quantity);
}
