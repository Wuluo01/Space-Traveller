using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosion : MonoBehaviour//para desaparecer por la bomba
{
  void DestruirExplosion()
    {
        Destroy(gameObject);
    }
}
