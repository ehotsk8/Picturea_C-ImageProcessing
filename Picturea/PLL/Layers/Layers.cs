using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public class Layers
    {
        public Layer[] LayersArray { get { return layers.ToArray(); } }
        public static Layer CurrentLayer { get; set; }

        public event ChangeEvent SomeEvent;
        public delegate void ChangeEvent();

        private List<Layer> layers = new List<Layer>();

        public Layers() { }

        public Layers(Layer layer)
        {
            AddLayer(layer);
        }

        public Layer GetLayerByName(string layerName)
        {
            return layers.FirstOrDefault(f => f.Name == layerName);
        }

        public void AddLayer(Layer layer)
        {
            layers.Add(layer);
            SetCurrentLayer(layer);
            if (SomeEvent != null)
                SomeEvent();
        }

        public void SetCurrentLayer(Layer layer)
        {
            CurrentLayer = layer;
        }
    }
}
