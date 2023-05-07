# IDED_Scripting_202310_Parcial3
 
 * Juan Pablo Correa
 * Manuela Cuervo
 * Jose Miguel Lopez
 ##
 
 ## Código

1 - En los scripts *RefactoredGameController, RefactoredPlayerController, RefactoredUIManager y RefactoredObstacleSpawner* Implementan el patrón *Singletone* el cúal permite que el objeto solo se instancie una sola vez, y al intentar acceder o crear uno nuevo, siempre nos llevará al que se instanció de primero.

2 y 3 - Aquí comenzaron los verdaderos problemas:

* Queda cómo evidencia que hubo un intento de aplicar el patrón *Observer* en la ruta **Assets ---> Scripts ---> CommunicationProtocol** Fue al principio una implementación relativamente sencilla que funcionaba, pero se empezaron a presentar problemas debido a el momento de suscribir y desuscribir no solo los eventos, sinó también los observadores, esto se debe a que la única forma que logré estructurar el patrón, no me quedaba claro en que momento o en que sucesión se suscribía o se desuscribía el sujeto o el observador. Debido a esto me puse a investigar en búsqueda de una alternativa hasta que encontré la clase *Actions* del motor de Unity.

Adjunto documentación de dicha Clase de Unity
```csharp

//Attach this script to a GameObject. Attach a Renderer and Button component to the same GameObject for this example.
//This script will change the Color of the GameObject as well as output messages to the Console saying which function was run by the UnityAction.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UnityActionExample : MonoBehaviour
{
    //This is the Button you attach to the GameObject in the Inspector
    Button m_AddButton;
    Renderer m_Renderer;

    private UnityAction m_MyFirstAction;
    //This is the number that the script updates
    float m_MyNumber;

    void Start()
    {
        //Fetch the Button and Renderer components from the GameObject
        m_AddButton = GetComponent<Button>();
        m_Renderer = GetComponent<Renderer>();

        //Make a Unity Action that calls your function
        m_MyFirstAction += MyFunction;
        //Make the Unity Action also call your second function
        m_MyFirstAction += MySecondFunction;
        //Register the Button to detect clicks and call your Unity Action
        m_AddButton.onClick.AddListener(m_MyFirstAction);
    }

    void MyFunction()
    {
        //Add to the number
        m_MyNumber++;
        //Display the number so far with the message
        Debug.Log("First Added : " + m_MyNumber);
    }

    void MySecondFunction()
    {
        //Change the Color of the GameObject
        m_Renderer.material.color = Color.blue;
        //Ouput the message that the second function was played
        Debug.Log("Second Added");
    }
}

```

* De dicha manera implementé el uso de estas clases en Unity para que mis eventos, o ahora Aciones, pudieran estar disponibles de ejecutarse cuando el código lo necesitara, así si fuera el caso, habría un script aparte que estaría pendiente de cúando están ocurrriendo ciertas acciones, sin que los scripts sean dependientes de otros. En mi caso los usé desde la misma función que necesitaba ejecutarlo, pero demuestro esto para validar que es una alternativa al patrón *Observer* ya que suple con la misma necesidad.

 4 - Se completó la funcionalidad de **PoolsBase** de las cuales deriban unas clases cómo **Blue, Green y Red BulletsPool** (Las cuales son utilizadas por *RefactoredPlayerController*); también derivando a **Blue, Green y Red ObstaclePool** (Que son usados por *RefactoredObstacleSpawner*) Donde se almacenan el típo de prefab, y están disponibles para ser instansiados según necesidad.
 
 5 - Se creo el script PoolableObj el cual acciona el reciclado de las instancias que se le pasen a la función, lo cual ayuda a los Poyectiles y a los obstaculos a reciclar sus instancias a necesidad.
 
 6 - No se implementó esta sección
 
 7 - La función **RefactoredObstacleSpawner.SpawnObject()** está implementada y efectivamente utiliza las instancias de los Obstaculos almacenados en los Pools, utilizando los cáda vez que se les invoca.
 
 ## Notas adicionales
 
Lamentamos no haber podido entregar el código de la manera más optima ni más funcional, nos tomó todo el día, tarde y noche del día 6 de Mayo para decidir deshacernos del patrón observador, el resto lo logramos solucionar el día de hoy, pero ya no nos queda sucifiente salú Mental cómo para seguirlo intentando y el resto de los deberes se van acumulando.


![](https://cdn.verbub.com/images/mama-no-puedo-dormir-tengo-miedo-de-mi-futuro-me-aterra-ver-417801.jpg)
