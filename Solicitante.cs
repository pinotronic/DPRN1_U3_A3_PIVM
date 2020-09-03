using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A3_PIVM
{
    [Serializable()]
    public class Solicitante
    {
        string _iniciales;
        string _nombre;
        string _apellidos; 
        int _fechNacimiento;
        int _tipo;
        int _costo;
        int _vigencia;
        bool _requisitos;

        public string iniciales {  get => _iniciales; set => _iniciales = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellidos { get => _apellidos; set => _apellidos = value; }
        public int fechNacimiento { get => _fechNacimiento; set => _fechNacimiento = value; }
        public int tipo { get => _tipo; set => _tipo = value; }
        public int costo { get => _costo; set => _costo = value; }
        public int vigencia { get => _vigencia; set => _vigencia = value; }
        public bool requisitos { get => _requisitos; set => _requisitos = value; }

    }
}
