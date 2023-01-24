using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipComponents
{
    public pa ShipComponentBase
    {
        // Get whether the component is active
        public bool getActive();
        
        // Set whether the component is active
        public void setActive(bool active);

        // Get the ship component layer. Lowest layer is 0.
        public int getLayer();

        // Set the ship component layer. Lowest layer is 0.
        protected void _setLayer(int layer);

        // Set the ship component layer. Lowest layer is 0.
        public void setLayer(int layer) {
            if (layer < 0) {
                layer = 0;
            }
            _setLayer(layer);
        }

        // The ship component size
        public Vector2 GetSize();
    }
}