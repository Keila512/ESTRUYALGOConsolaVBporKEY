Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq

Class Program
    Shared Sub Main(args As String())
        Dim continuarPrograma As Boolean = True
        Dim data As List(Of Integer) = New List(Of Integer)()

        While continuarPrograma
            Console.WriteLine("Seleccione una estructura de datos:")
            Console.WriteLine("1. Pila")
            Console.WriteLine("2. Cola")
            Console.WriteLine("3. Lista")
            Console.WriteLine("4. Árbol")
            Console.WriteLine("5. Grafo")
            Console.WriteLine("6. Salir")
            Console.WriteLine("7. Menú de Ordenamientos")
            Console.Write("Ingrese el número de la opción: ")
            Dim opcionEstructura As String = Console.ReadLine()

            Select Case opcionEstructura
                Case "1"
                    EjecutarOperacionesPila()
                Case "2"
                    EjecutarOperacionesCola()
                Case "3"
                    EjecutarOperacionesLista()
                Case "4"
                    EjecutarOperacionesArbol()
                Case "5"
                    EjecutarOperacionesGrafo()
                Case "6"
                    continuarPrograma = False
                Case "7"
                    data = ObtenerDatosUsuario()
                    EjecutarMenuOrdenamientos(data)
                Case Else
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.")
            End Select
        End While
    End Sub
    Private Shared Function ObtenerDatosUsuario() As List(Of Integer)
        Console.WriteLine("Ingrese datos (separados por espacios): ")
        Dim input As String() = Console.ReadLine().Split(" "c)
        Dim data As List(Of Integer) = New List(Of Integer)()
        Dim num As Integer = Nothing

        For Each item In input

            If Integer.TryParse(item, num) Then
                data.Add(num)
            Else
                Console.WriteLine($"'{item}' no es un número válido y será ignorado.")
            End If
        Next

        Return data
    End Function

    Private Shared Sub EjecutarMenuOrdenamientos(ByVal data As List(Of Integer))
        Dim continuarMenu As Boolean = True

        While continuarMenu
            Console.WriteLine(vbLf & "Sorting Menu:")
            Console.WriteLine("1. Bubble Sort")
            Console.WriteLine("2. Selection Sort")
            Console.WriteLine("3. Insertion Sort")
            Console.WriteLine("4. QuickSort")
            Console.WriteLine("5. Merge Sort")
            Console.WriteLine("6. Heap Sort")
            Console.WriteLine("7. Shell Sort")
            Console.WriteLine("8. Counting Sort")
            Console.WriteLine("9. Radix Sort")
            Console.WriteLine("10. Exit")
            Console.Write("Seleccione una opción (1-5): ")
            Dim sortingOption As String = Console.ReadLine()

            Select Case sortingOption
                Case "1"
                    BubbleSort(data)
                    MostrarDatos(data)
                Case "2"
                    SelectionSort(data)
                    MostrarDatos(data)
                Case "3"
                    InsertionSort(data)
                    MostrarDatos(data)
                Case "4"
                    QuickSort(data, 0, data.Count - 1)
                    MostrarDatos(data)
                Case "5"
                    MergeSort(data, 0, data.Count - 1)
                    Console.WriteLine("Datos ordenados con MergeSort: " & String.Join(", ", data))
                Case "6"
                    HeapSort(data)
                    MostrarDatos(data)
                Case "7"
                    ShellSort(data)
                    MostrarDatos(data)
                Case "8"
                    CountingSort(data)
                    MostrarDatos(data)
                Case "9"
                    RadixSort(data)
                    MostrarDatos(data)
                Case "10"
                    continuarMenu = False
                Case Else
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.")
            End Select
        End While
    End Sub

    Private Shared Sub MostrarDatos(ByVal data As List(Of Integer))
        Console.WriteLine("Datos ordenados: " & String.Join(", ", data))
    End Sub

    Private Shared Sub BubbleSort(ByVal data As List(Of Integer))
        For i As Integer = 0 To data.Count - 1 - 1

            For j As Integer = 0 To data.Count - i - 1 - 1

                If data(j) > data(j + 1) Then
                    Dim temp As Integer = data(j)
                    data(j) = data(j + 1)
                    data(j + 1) = temp
                End If
            Next
        Next

        Console.WriteLine("Datos ordenados con Bubble Sort.")
    End Sub

    Private Shared Sub SelectionSort(ByVal data As List(Of Integer))
        For i As Integer = 0 To data.Count - 1 - 1
            Dim minIndex As Integer = i

            For j As Integer = i + 1 To data.Count - 1

                If data(j) < data(minIndex) Then
                    minIndex = j
                End If
            Next

            Dim temp As Integer = data(minIndex)
            data(minIndex) = data(i)
            data(i) = temp
        Next

        Console.WriteLine("Datos ordenados con Selection Sort.")
    End Sub

    Private Shared Sub InsertionSort(ByVal data As List(Of Integer))
        For i As Integer = 1 To data.Count - 1
            Dim key As Integer = data(i)
            Dim j As Integer = i - 1

            While j >= 0 AndAlso data(j) > key
                data(j + 1) = data(j)
                j -= 1
            End While

            data(j + 1) = key
        Next

        Console.WriteLine("Datos ordenados con Insertion Sort.")
    End Sub

    Private Shared Sub QuickSort(ByVal data As List(Of Integer), ByVal low As Integer, ByVal high As Integer)
        If low < high Then
            Dim partitionIndex As Integer = Partition(data, low, high)
            QuickSort(data, low, partitionIndex - 1)
            QuickSort(data, partitionIndex + 1, high)
        End If
    End Sub

    Private Shared Function Partition(ByVal data As List(Of Integer), ByVal low As Integer, ByVal high As Integer) As Integer
        Dim pivot As Integer = data(high)
        Dim i As Integer = low - 1

        For j As Integer = low To high - 1

            If data(j) < pivot Then
                i += 1
                Swap(data, i, j)
            End If
        Next

        Swap(data, i + 1, high)
        Return i + 1
    End Function

    Private Shared Sub Swap(ByVal data As List(Of Integer), ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = data(i)
        data(i) = data(j)
        data(j) = temp
    End Sub

    Private Shared Sub MergeSort(ByVal data As List(Of Integer), ByVal left As Integer, ByVal right As Integer)
        If left < right Then
            Dim middle As Integer = (left + right) / 2
            MergeSort(data, left, middle)
            MergeSort(data, middle + 1, right)
            Merge(data, left, middle, right)
        End If
    End Sub

    Private Shared Sub Merge(ByVal data As List(Of Integer), ByVal left As Integer, ByVal middle As Integer, ByVal right As Integer)
        Dim n1 As Integer = middle - left + 1
        Dim n2 As Integer = right - middle
        Dim leftArray As Integer() = New Integer(n1 - 1) {}
        Dim rightArray As Integer() = New Integer(n2 - 1) {}
        Array.Copy(data.ToArray(), left, leftArray, 0, n1)
        Array.Copy(data.ToArray(), middle + 1, rightArray, 0, n2)
        Dim i As Integer = 0, j As Integer = 0, k As Integer = left

        While i < n1 AndAlso j < n2

            If leftArray(i) <= rightArray(j) Then
                data(k) = leftArray(i)
                i += 1
            Else
                data(k) = rightArray(j)
                j += 1
            End If

            k += 1
        End While

        While i < n1
            data(k) = leftArray(i)
            i += 1
            k += 1
        End While

        While j < n2
            data(k) = rightArray(j)
            j += 1
            k += 1
        End While
    End Sub

    Private Shared Sub HeapSort(ByVal data As List(Of Integer))
        Dim n As Integer = data.Count

        For i As Integer = n / 2 - 1 To 0
            Heapify(data, n, i)
        Next

        For i As Integer = n - 1 To 0 + 1
            Dim temp As Integer = data(0)
            data(0) = data(i)
            data(i) = temp
            Heapify(data, i, 0)
        Next
    End Sub

    Private Shared Sub Heapify(ByVal data As List(Of Integer), ByVal n As Integer, ByVal i As Integer)
        Dim largest As Integer = i
        Dim left As Integer = 2 * i + 1
        Dim right As Integer = 2 * i + 2
        If left < n AndAlso data(left) > data(largest) Then largest = left
        If right < n AndAlso data(right) > data(largest) Then largest = right

        If largest <> i Then
            Dim swap As Integer = data(i)
            data(i) = data(largest)
            data(largest) = swap
            Heapify(data, n, largest)
        End If
    End Sub

    Shared Sub ShellSort(data As List(Of Integer))
        Dim n As Integer = data.Count

        For gap As Integer = n \ 2 To 1 Step gap \ 2
            For i As Integer = gap To n - 1
                Dim temp As Integer = data(i)
                Dim j As Integer

                For j = i To gap Step -gap
                    If j >= gap AndAlso data(j - gap) > temp Then
                        data(j) = data(j - gap)
                    Else
                        Exit For
                    End If
                Next

                data(j) = temp
            Next
        Next
    End Sub


    Private Shared Sub ShowData(ByVal data As List(Of Integer))
        Console.Write("Current data: ")

        For Each item In data
            Console.Write($"{item} ")
        Next

        Console.WriteLine()
    End Sub

    Private Shared Sub CountingSort(ByVal data As List(Of Integer))
        Dim n As Integer = data.Count
        Dim output As Integer() = New Integer(n - 1) {}
        Dim max As Integer = data.Max()
        Dim min As Integer = data.Min()
        Dim range As Integer = max - min + 1
        Dim count As Integer() = New Integer(range - 1) {}
        Dim outputData As Integer() = New Integer(n - 1) {}

        For i As Integer = 0 To n - 1
            count(data(i) - min) += 1
        Next

        For i As Integer = 1 To range - 1
            count(i) += count(i - 1)
        Next

        For i As Integer = n - 1 To 0
            output(count(data(i) - min) - 1) = data(i)
            count(data(i) - min) -= 1
        Next

        For i As Integer = 0 To n - 1
            data(i) = output(i)
        Next
    End Sub

    Shared Sub RadixSort(data As List(Of Integer))
        Dim max As Integer = data.Max()

        For exp As Integer = 1 To max
            CountingSortRadix(data, exp)
        Next
    End Sub




    Private Shared Sub CountingSortRadix(ByVal data As List(Of Integer), ByVal exp As Integer)
        Dim n As Integer = data.Count
        Dim output As Integer() = New Integer(n - 1) {}
        Dim count As Integer() = New Integer(9) {}

        For i As Integer = 0 To n - 1
            count((data(i) / exp) Mod 10) += 1
        Next

        For i As Integer = 1 To 10 - 1
            count(i) += count(i - 1)
        Next

        For i As Integer = n - 1 To 0
            output(count((data(i) / exp) Mod 10) - 1) = data(i)
            count((data(i) / exp) Mod 10) -= 1
        Next

        For i As Integer = 0 To n - 1
            data(i) = output(i)
        Next
    End Sub

    Private Shared Sub EjecutarOperacionesPila()
        Console.WriteLine("Operaciones con Pila:")
        Dim pila As Stack(Of Integer) = New Stack(Of Integer)()
        OperacionesPila(pila, "pila")
    End Sub

    Private Shared Sub EjecutarOperacionesCola()
        Console.WriteLine("Operaciones con Cola:")
        Dim cola As Queue(Of String) = New Queue(Of String)()
        OperacionesCola(cola, "cola")
    End Sub

    Private Shared Sub EjecutarOperacionesLista()
        Console.WriteLine("Operaciones con Lista:")
        Dim lista As List(Of Double) = New List(Of Double)()
        OperacionesLista(lista, "lista")
    End Sub

    Private Shared Sub EjecutarOperacionesArbol()
        Console.WriteLine("Operaciones con Árbol:")
        Dim arbol As Arbol = New Arbol()
        LlenarArbolConPrioridades(arbol)
        Console.WriteLine("Recorrido Inorden del árbol con prioridades:")
        arbol.RecorridoInorden()
    End Sub

    Private Shared Sub EjecutarOperacionesGrafo()
        Console.WriteLine("Operaciones con Grafo:")
        Dim grafo As Grafo = New Grafo()
        LlenarGrafo(grafo)
        Console.WriteLine("Representación del Grafo:")
        MostrarGrafo(grafo)
    End Sub

    Private Shared Sub MostrarColeccion(Of T)(ByVal coleccion As IEnumerable(Of T))
        For Each elemento In coleccion.Reverse()
            Console.Write($"{elemento} ")
        Next

        Console.WriteLine()
    End Sub

    Private Shared Sub LlenarArbol(ByVal arbol As Arbol)
        Console.Write("Ingrese elementos para el árbol (separados por espacio): ")
        Dim elementos As String() = Console.ReadLine().Split(" "c)
        Dim num As Integer = Nothing

        For Each elemento In elementos

            If Integer.TryParse(elemento, num) Then
                arbol.Insertar(num, "media")
            End If
        Next
    End Sub

    Private Shared Sub LlenarArbolConPrioridades(ByVal arbol As Arbol)
        Console.Write("Ingrese elementos para el árbol (separados por espacio): ")
        Dim elementos As String() = Console.ReadLine().Split(" "c)
        Dim num As Integer = Nothing

        For Each elemento In elementos

            If Integer.TryParse(elemento, num) Then
                Console.Write($"Ingrese la prioridad para el elemento {num} (alta, media, baja): ")
                Dim prioridad As String = Console.ReadLine().ToLower()

                If prioridad = "alta" OrElse prioridad = "media" OrElse prioridad = "baja" Then
                    arbol.Insertar(num, prioridad)
                Else
                    Console.WriteLine("Prioridad no válida. Se asignará 'media' por defecto.")
                    arbol.Insertar(num, "media")
                End If
            End If
        Next
    End Sub

    Private Shared Sub LlenarGrafo(ByVal grafo As Grafo)
        Console.Write("Ingrese vértices para el grafo (separados por espacio): ")
        Dim vertices As String() = Console.ReadLine().Split(" "c)

        For Each vertice In vertices
            grafo.AgregarVertice(vertice)
        Next

        Console.WriteLine("Ingrese aristas para el grafo (pares de vértices, separados por espacio):")
        Dim aristas As String() = Console.ReadLine().Split(" "c)

        For i As Integer = 0 To aristas.Length - 1 Step 2
            grafo.AgregarArista(aristas(i), aristas(i + 1))
        Next
    End Sub

    Private Shared Sub MostrarGrafo(ByVal grafo As Grafo)
        For Each vertice In grafo.ObtenerVertices()
            Console.Write($"{vertice}: ")

            For Each vecino In grafo.ObtenerVecinos(vertice)
                Console.Write($"{vecino} ")
            Next

            Console.WriteLine()
        Next
    End Sub

    Private Shared Sub OperacionesPila(ByVal pila As Stack(Of Integer), ByVal nombre As String)
        Dim continuar As Boolean = True

        While continuar
            Console.WriteLine($"\nOperaciones en la {nombre}:")
            Console.WriteLine("1. Agregar elemento")
            Console.WriteLine("2. Quitar elemento")
            Console.WriteLine("3. Mostrar contenido")
            Console.WriteLine("4. Salir")
            Console.Write("Seleccione una opción (1-4): ")
            Dim opcion As String = Console.ReadLine()

            Select Case opcion
                Case "1"
                    AgregarElemento(pila)
                Case "2"
                    QuitarElemento(pila)
                Case "3"
                    MostrarColeccion(pila)
                Case "4"
                    continuar = False
                Case Else
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.")
            End Select
        End While
    End Sub

    Private Shared Sub AgregarElemento(ByVal pila As Stack(Of Integer))
        Console.Write("Ingrese el elemento a agregar: ")
        Dim num As Integer = Nothing

        If Integer.TryParse(Console.ReadLine(), num) Then
            pila.Push(num)
            Console.WriteLine($"Elemento {num} agregado a la pila.")
        Else
            Console.WriteLine("Entrada no válida. Inténtelo de nuevo.")
        End If
    End Sub

    Private Shared Sub QuitarElemento(ByVal pila As Stack(Of Integer))
        If pila.Count > 0 Then
            Dim elementoQuitado As Integer = pila.Pop()
            Console.WriteLine($"Elemento {elementoQuitado} quitado de la pila.")
        Else
            Console.WriteLine("La pila está vacía.")
        End If
    End Sub

    Private Shared Sub OperacionesCola(ByVal cola As Queue(Of String), ByVal nombre As String)
        Dim continuar As Boolean = True

        While continuar
            Console.WriteLine($"\nOperaciones en la {nombre}:")
            Console.WriteLine("1. Agregar elemento")
            Console.WriteLine("2. Quitar elemento")
            Console.WriteLine("3. Mostrar contenido")
            Console.WriteLine("4. Salir")
            Console.Write("Seleccione una opción (1-4): ")
            Dim opcion As String = Console.ReadLine()

            Select Case opcion
                Case "1"
                    AgregarElemento(cola)
                Case "2"
                    QuitarElemento(cola)
                Case "3"
                    MostrarColeccion(cola)
                Case "4"
                    continuar = False
                Case Else
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.")
            End Select
        End While
    End Sub

    Private Shared Sub AgregarElemento(ByVal cola As Queue(Of String))
        Console.Write("Ingrese el elemento a agregar: ")
        Dim elemento As String = Console.ReadLine()
        cola.Enqueue(elemento)
        Console.WriteLine($"Elemento '{elemento}' agregado a la cola.")
    End Sub

    Private Shared Sub QuitarElemento(ByVal cola As Queue(Of String))
        If cola.Count > 0 Then
            Dim elementoQuitado As String = cola.Dequeue()
            Console.WriteLine($"Elemento '{elementoQuitado}' quitado de la cola.")
        Else
            Console.WriteLine("La cola está vacía.")
        End If
    End Sub

    Private Shared Sub OperacionesLista(ByVal lista As List(Of Double), ByVal nombre As String)
        Dim continuar As Boolean = True

        While continuar
            Console.WriteLine($"\nOperaciones en la {nombre}:")
            Console.WriteLine("1. Agregar elemento")
            Console.WriteLine("2. Quitar elemento")
            Console.WriteLine("3. Mostrar contenido")
            Console.WriteLine("4. Salir")
            Console.Write("Seleccione una opción (1-4): ")
            Dim opcion As String = Console.ReadLine()

            Select Case opcion
                Case "1"
                    AgregarElemento(lista)
                Case "2"
                    QuitarElemento(lista)
                Case "3"
                    MostrarColeccion(lista)
                Case "4"
                    continuar = False
                Case Else
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.")
            End Select
        End While
    End Sub

    Private Shared Sub AgregarElemento(ByVal lista As List(Of Double))
        Console.Write("Ingrese el elemento a agregar: ")
        Dim num As Double = Nothing

        If Double.TryParse(Console.ReadLine(), num) Then
            lista.Add(num)
            Console.WriteLine($"Elemento {num} agregado a la lista.")
        Else
            Console.WriteLine("Entrada no válida. Inténtelo de nuevo.")
        End If
    End Sub

    Private Shared Sub QuitarElemento(ByVal lista As List(Of Double))
        Dim posicion As Integer = Nothing

        If lista.Count > 0 Then
            Console.Write("Ingrese la posición del elemento a quitar: ")

            If Integer.TryParse(Console.ReadLine(), posicion) AndAlso posicion >= 0 AndAlso posicion < lista.Count Then
                Dim elementoQuitado As Double = lista(posicion)
                lista.RemoveAt(posicion)
                Console.WriteLine($"Elemento {elementoQuitado} quitado de la lista.")
            Else
                Console.WriteLine("Posición no válida. Inténtelo de nuevo.")
            End If
        Else
            Console.WriteLine("La lista está vacía.")
        End If
    End Sub
End Class

Class NodoArbol
    Public Valor As Integer
    Public Prioridad As String
    Public Izquierdo As NodoArbol
    Public Derecho As NodoArbol
End Class

Class Arbol
    Private raiz As NodoArbol

    Public Sub Insertar(ByVal valor As Integer, ByVal prioridad As String)
        raiz = InsertarRec(raiz, valor, prioridad)
    End Sub

    Private Function InsertarRec(ByVal nodo As NodoArbol, ByVal valor As Integer, ByVal prioridad As String) As NodoArbol
        If nodo Is Nothing Then
            nodo = New NodoArbol()
            nodo.Valor = valor
            nodo.Prioridad = prioridad
            nodo.Izquierdo = Nothing
        ElseIf valor < nodo.Valor Then
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor, prioridad)
        ElseIf valor > nodo.Valor Then
            nodo.Derecho = InsertarRec(nodo.Derecho, valor, prioridad)
        End If

        Return nodo
    End Function

    Public Sub RecorridoInorden()
        RecorridoInordenRec(raiz)
        Console.WriteLine()
    End Sub

    Private Sub RecorridoInordenRec(ByVal nodo As NodoArbol)
        If nodo IsNot Nothing Then
            RecorridoInordenRec(nodo.Izquierdo)
            Console.Write($"{nodo.Valor} ({nodo.Prioridad}) ")
            RecorridoInordenRec(nodo.Derecho)
        End If
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class

Class Grafo
    Private grafo As Dictionary(Of String, List(Of String))

    Public Sub New()
        grafo = New Dictionary(Of String, List(Of String))()
    End Sub

    Public Sub AgregarVertice(ByVal vertice As String)
        grafo.Add(vertice, New List(Of String)())
    End Sub

    Public Sub AgregarArista(ByVal origen As String, ByVal destino As String)
        grafo(origen).Add(destino)
        grafo(destino).Add(origen)
    End Sub

    Public Function ObtenerVertices() As List(Of String)
        Return New List(Of String)(grafo.Keys)
    End Function

    Public Function ObtenerVecinos(ByVal vertice As String) As List(Of String)
        Return grafo(vertice)
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
