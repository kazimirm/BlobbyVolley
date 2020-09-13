using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scenes
{
    /*
     * Every Blobby must implement this interface
     */
    interface BlobbyInterface
    {
        void Start();
        void Update();
        void OnTriggerEnter2D(Collider2D col);

    }
}
