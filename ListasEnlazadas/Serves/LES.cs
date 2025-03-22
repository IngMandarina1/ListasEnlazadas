namespace ListasEnlazadas.Serves
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacio()
        {
            return UltimoNodo == null;
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Insercion con éxito";
        }

        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Insercion con éxito";
        }

        public string AgregarAntesDatoX(string datoX, Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            if (PrimerNodo.Informacion == datoX) 
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                return "Nodo insertado antes de " + datoX;
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null && actual.Referencia.Informacion != datoX)
            {
                actual = actual.Referencia;
            }

            if (actual.Referencia == null) return "Dato no encontrado";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;
            return "Nodo insertado antes de " + datoX;
        }

        public string AgregarDespuesDatoX(string datoX, Nodo nuevoNodo)
        {
            Nodo actual = PrimerNodo;
            while (actual != null && actual.Informacion != datoX)
            {
                actual = actual.Referencia;
            }

            if (actual == null) return "Dato no encontrado";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (actual == UltimoNodo) UltimoNodo = nuevoNodo;

            return "Nodo insertado despues de " + datoX;
        }

        public string AgregarEnPosicion(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 0) return "Posicion invalida";

            if (posicion == 0) return AgregarNodoInicio(nuevoNodo);

            Nodo actual = PrimerNodo;
            int indice = 0;

            while (actual != null && indice < posicion - 1)
            {
                actual = actual.Referencia;
                indice++;
            }

            if (actual == null) return "Posicion fuera de rango";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (nuevoNodo.Referencia == null) UltimoNodo = nuevoNodo;

            return "Nodo insertado en posicion " + posicion;
        }

        public string AgregarAntesDePosicion(int posicion, Nodo nuevoNodo)
        {
            return AgregarEnPosicion(posicion - 1, nuevoNodo);
        }

        public string AgregarDespuesDePosicion(int posicion, Nodo nuevoNodo)
        {
            return AgregarEnPosicion(posicion + 1, nuevoNodo);
        }

        public void RecorrerRecursivo(Nodo? nodo)
        {
            if (nodo == null) return;

            Console.WriteLine(nodo.Informacion);
            RecorrerRecursivo(nodo.Referencia);
        }

        public Nodo? BuscarElemento(string valor)
        {
            Nodo actual = PrimerNodo;
            while (actual != null)
            {
                if (actual.Informacion == valor) return actual;
                actual = actual.Referencia;
            }
            return null;
        }
    }
}
