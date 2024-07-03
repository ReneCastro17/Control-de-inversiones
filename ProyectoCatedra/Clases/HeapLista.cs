using ProyectoCatedra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Text.RegularExpressions;
using System.Collections;

namespace ProyectoCatedra
{
    //La clase más importante, contiene la lista estatica que se usa en todos los forms
    public class HeapLista
    {
        //Declaramos nuestra lista estática vacía.
        static public List<Inversionista> ListaHeap { get; set; } = new List<Inversionista>();
        //Metodo recursivo que reasigna cada posicion dentro de la lista
        static public void HeapSort(List<Inversionista> List, ListSortDirection Direccion)
        //Se usa la propiedad direccion de List para saber el sentido que llevan sus punteros y ordenarlo en función de ello.
        {
            //Hacemos uso de la propiedad .Count para saber cuantos nodos lleva la lista
            int n = List.Count;
            //Ordenamiento parcial de la lista desde la mitad hacia el comienzo.
            for (int i = (n / 2) - 1; i >= 0; i--)
                OrdenarMayor(List, n, i, Direccion);
            //Hacemos el ordenamiento desde el final hasta el comienzo e intercambiamos el ultimo valor del heap con el primero de la lista.
            for (int i = n - 1; i >= 0; i--)
            {
                //Declaramos al nodo temporal al comienzo de la lista
                Inversionista temp = List[0];
                List[0] = List[i];
                List[i] = temp;
                OrdenarMayor(List, i, 0, Direccion);
            }
        }
        //
        static public void OrdenarMayor(List<Inversionista> a, int n, int i, ListSortDirection Direccion)
        {
            //Ordenamiento, es un metodo recursivo y comprueba los valores a la izquierda y a la derecha.
            int izquierdo = (2 * i) + 1;
            int derecho = (2 * i) + 2;
            int mayor = i;
            if (Direccion == ListSortDirection.Ascending)
            {
            /*Hace comparaciones en base a N que es el numero de elementos de la lista,
             Izquierdo y derecho representan posiciones, para luego encontrar al mayor.
            */
            //Se compara en base al parametro monto.
                if (izquierdo < n && a[izquierdo].Monto > a[mayor].Monto)
                    mayor = izquierdo;
                if (derecho < n && a[derecho].Monto > a[mayor].Monto)
                    mayor = derecho;
            }
            else
            {
                if (izquierdo < n && a[izquierdo].Monto < a[mayor].Monto)
                    mayor = izquierdo;
                if (derecho < n && a[derecho].Monto < a[mayor].Monto)
                    mayor = derecho;
            }
            /*Si el valor del nodo actual no es el mayor, se intercambia con el valor del nodo mayor o menor, con
             * la lista temporal hacemos que no se pierdan las posiciones en ningún momento y volvemos a llamar
             * a OrdenarMayor para asegurar que se cumpla el orden luego del intercambio.
            */
            if (mayor != i)
            {
                Inversionista temp = a[i];
                a[i] = a[mayor];
                a[mayor] = temp;
                OrdenarMayor(a, n, mayor, Direccion);
            }
        }
    }
}
