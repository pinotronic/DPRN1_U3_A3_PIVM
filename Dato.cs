using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DPRN1_U3_A3_PIVM
{
    class Dato
    {
        private String ruta;
        public Dato(String ruta)
        {
            this.ruta = ruta;
        }
        public void serializar(List<Solicitante> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public List<Solicitante> deserializar()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Solicitante> lista = (List<Solicitante>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }

    }
}
