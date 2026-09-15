using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiArbolito2
{
    public class Arbol
    {
        public Nodo raiz { get; set; }

        public Arbol() {
            raiz = null;
        }

        public void insertar(int valor) {
            raiz = insertarRecursivo(raiz, valor);
        }

        public Nodo insertarRecursivo(Nodo nodoActual, int valor) {
            if (nodoActual == null) {
                return new Nodo(valor);
            }
            if (valor < nodoActual.valor) {
                nodoActual.izquierdo = insertarRecursivo(nodoActual.izquierdo, valor);
            } else if (valor > nodoActual.valor) {
                nodoActual.derecho = insertarRecursivo(nodoActual.derecho, valor);
            }
            
            return nodoActual;
        }

        public bool buscar(int valor) {
            return buscarRecursivo(raiz, valor);
        }

        public bool buscarRecursivo(Nodo nodoActual, int valor) {
            if (nodoActual == null) {
                return false;
            }
            if (nodoActual.valor == valor)
            {
                return true;
            }
            
            if (valor < nodoActual.valor) {
                return buscarRecursivo(nodoActual.izquierdo, valor);
            }
            else {
                return buscarRecursivo(nodoActual.derecho, valor);
            }

        }



    }
}
