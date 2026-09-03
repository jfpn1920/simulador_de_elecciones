Imports System
Module simulador_de_elecciones
    Sub Main(args As String())
        Dim ids(19) As Integer
        Dim nombres(19) As String
        Dim partidos(19) As String
        Dim propuestas(19) As String
        Dim votos(19) As Integer
        Dim estados(19) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        '--------------------------------------------'
        '--|menu_principal_simulador_de_elecciones|--'
        '--------------------------------------------'
        Do
            Console.WriteLine("menu principal simulador de elecciones")
            Console.WriteLine("1) Registrar candidato")
            Console.WriteLine("2) Editar candidato")
            Console.WriteLine("3) Listar candidatos")
            Console.WriteLine("4) Buscar candidato")
            Console.WriteLine("5) Eliminar candidato")
            Console.WriteLine("6) Simular votacion")
            Console.WriteLine("7) Mostrar resultados")
            Console.WriteLine("8) Mostrar resumen")
            Console.WriteLine("9) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-------------------------'
                '--|registrar_candidato|--'
                '-------------------------'
                Case 1
                    If cantidad >= 20 Then
                        Console.WriteLine("No se pueden registrar mas candidatos.")
                    Else
                        Console.Write("Ingrese el nombre del candidato: ")
                        Dim nuevoNombre As String = Console.ReadLine()
                        If nuevoNombre = "" Then
                            Console.WriteLine("El nombre no puede estar vacio.")
                        Else
                            Dim nombreExiste As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower() = nuevoNombre.ToLower() Then
                                    nombreExiste = True
                                End If
                            Next
                            If nombreExiste Then
                                Console.WriteLine("El candidato ya se encuentra registrado.")
                            Else
                                Console.Write("Ingrese el partido o movimiento: ")
                                Dim nuevoPartido As String = Console.ReadLine()
                                If nuevoPartido = "" Then
                                    Console.WriteLine("El partido no puede estar vacio.")
                                Else
                                    Console.Write("Ingrese la propuesta principal: ")
                                    Dim nuevaPropuesta As String = Console.ReadLine()
                                    If nuevaPropuesta = "" Then
                                        Console.WriteLine("La propuesta no puede estar vacia.")
                                    Else
                                        ids(cantidad) = cantidad + 1
                                        nombres(cantidad) = nuevoNombre
                                        partidos(cantidad) = nuevoPartido
                                        propuestas(cantidad) = nuevaPropuesta
                                        votos(cantidad) = 0
                                        estados(cantidad) = "Activo"
                                        cantidad += 1
                                        Console.WriteLine("Candidato registrado correctamente.")
                                    End If
                                End If
                            End If
                        End If
                    End If
                '----------------------'
                '--|editar_candidato|--'
                '----------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Console.Write("Ingrese el ID del candidato: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        Dim encontrado As Boolean = False
                        For i As Integer = 0 To cantidad - 1
                            If ids(i) = idEditar Then
                                encontrado = True
                                Console.Write("Ingrese el nuevo nombre: ")
                                Dim nuevoNombre As String = Console.ReadLine()
                                If nuevoNombre <> "" Then
                                    nombres(i) = nuevoNombre
                                End If
                                Console.Write("Ingrese el nuevo partido o movimiento: ")
                                Dim nuevoPartido As String = Console.ReadLine()
                                If nuevoPartido <> "" Then
                                    partidos(i) = nuevoPartido
                                End If
                                Console.Write("Ingrese la nueva propuesta: ")
                                Dim nuevaPropuesta As String = Console.ReadLine()
                                If nuevaPropuesta <> "" Then
                                    propuestas(i) = nuevaPropuesta
                                End If
                                Console.WriteLine("Seleccione el nuevo estado:")
                                Console.WriteLine("1) Activo")
                                Console.WriteLine("2) Inactivo")
                                Console.Write("Seleccione una opcion: ")
                                Dim opcionEstado As Integer = Convert.ToInt32(Console.ReadLine())
                                If opcionEstado = 1 Then
                                    estados(i) = "Activo"
                                ElseIf opcionEstado = 2 Then
                                    estados(i) = "Inactivo"
                                Else
                                    Console.WriteLine("Opcion de estado no valida.")
                                End If
                                Console.WriteLine("Candidato actualizado correctamente.")
                            End If
                        Next
                        If encontrado = False Then
                            Console.WriteLine("No se encontro un candidato con ese ID.")
                        End If
                    End If
                '-----------------------'
                '--|listar_candidatos|--'
                '-----------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                        Next
                    End If
                '----------------------'
                '--|buscar_candidato|--'
                '----------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por nombre")
                        Console.WriteLine("3) Buscar por partido")
                        Console.WriteLine("4) Buscar por estado")
                        Console.WriteLine("5) Buscar todos")
                        Console.Write("Seleccione una opcion: ")
                        Dim opcionBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                        If opcionBuscar = 1 Then
                            Console.Write("Ingrese el ID: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If ids(i) = idBuscar Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If encontrado = False Then
                                Console.WriteLine("No se encontro el candidato.")
                            End If
                        ElseIf opcionBuscar = 2 Then
                            Console.Write("Ingrese el nombre: ")
                            Dim nombreBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower().Contains(nombreBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If encontrado = False Then
                                Console.WriteLine("No se encontraron candidatos.")
                            End If
                        ElseIf opcionBuscar = 3 Then
                            Console.Write("Ingrese el partido: ")
                            Dim partidoBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If partidos(i).ToLower().Contains(partidoBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If encontrado = False Then
                                Console.WriteLine("No se encontraron candidatos.")
                            End If
                        ElseIf opcionBuscar = 4 Then
                            Console.Write("Ingrese el estado: ")
                            Dim estadoBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If estados(i).ToLower() = estadoBuscar.ToLower() Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If encontrado = False Then
                                Console.WriteLine("No se encontraron candidatos.")
                            End If
                        ElseIf opcionBuscar = 5 Then
                            For i As Integer = 0 To cantidad - 1
                                Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Partido: " & partidos(i) & " | Propuesta: " & propuestas(i) & " | Votos: " & votos(i) & " | Estado: " & estados(i))
                            Next
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '------------------------'
                '--|eliminar_candidato|--'
                '------------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Console.Write("Ingrese el ID del candidato: ")
                        Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                        Dim encontrado As Boolean = False
                        For i As Integer = 0 To cantidad - 1
                            If ids(i) = idEliminar Then
                                encontrado = True
                                For j As Integer = i To cantidad - 2
                                    ids(j) = ids(j + 1)
                                    nombres(j) = nombres(j + 1)
                                    partidos(j) = partidos(j + 1)
                                    propuestas(j) = propuestas(j + 1)
                                    votos(j) = votos(j + 1)
                                    estados(j) = estados(j + 1)
                                Next
                                cantidad -= 1
                                ids(cantidad) = 0
                                nombres(cantidad) = ""
                                partidos(cantidad) = ""
                                propuestas(cantidad) = ""
                                votos(cantidad) = 0
                                estados(cantidad) = ""
                                For j As Integer = 0 To cantidad - 1
                                    ids(j) = j + 1
                                Next
                                Console.WriteLine("Candidato eliminado correctamente.")
                                Exit For
                            End If
                        Next
                        If encontrado = False Then
                            Console.WriteLine("No se encontro un candidato con ese ID.")
                        End If
                    End If
                '----------------------'
                '--|simular_votacion|--'
                '----------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Console.WriteLine("CANDIDATOS ACTIVOS")
                        Dim activos As Integer = 0
                        For i As Integer = 0 To cantidad - 1
                            If estados(i) = "Activo" Then
                                Console.WriteLine(ids(i) & ") " & nombres(i) & " - " & partidos(i))
                                activos += 1
                            End If
                        Next
                        If activos = 0 Then
                            Console.WriteLine("No hay candidatos activos.")
                        Else
                            Console.Write("Ingrese el ID del candidato: ")
                            Dim idVoto As Integer = Convert.ToInt32(Console.ReadLine())
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If ids(i) = idVoto And estados(i) = "Activo" Then
                                    votos(i) += 1
                                    encontrado = True
                                    Console.WriteLine("Voto registrado correctamente para " & nombres(i) & ".")
                                End If
                            Next
                            If encontrado = False Then
                                Console.WriteLine("El candidato no existe o se encuentra inactivo.")
                            End If
                        End If
                    End If
                '------------------------'
                '--|mostrar_resultados|--'
                '------------------------'
                Case 7
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Dim totalVotos As Integer = 0
                        Dim mayorVotos As Integer = -1
                        Dim ganador As String = ""
                        For i As Integer = 0 To cantidad - 1
                            totalVotos += votos(i)
                            If votos(i) > mayorVotos Then
                                mayorVotos = votos(i)
                                ganador = nombres(i)
                            End If
                        Next
                        Console.WriteLine("RESULTADOS DE LA ELECCION")
                        For i As Integer = 0 To cantidad - 1
                            Dim porcentaje As Double = 0
                            If totalVotos > 0 Then
                                porcentaje = (votos(i) / totalVotos) * 100
                            End If
                            Console.WriteLine("ID: " & ids(i) & " | Candidato: " & nombres(i) & " | Partido: " & partidos(i) & " | Votos: " & votos(i) & " | Porcentaje: " & porcentaje.ToString("F2") & "%")
                        Next
                        Console.WriteLine("Total de votos: " & totalVotos)
                        If totalVotos > 0 Then
                            Console.WriteLine("Ganador: " & ganador)
                            Console.WriteLine("Mayor cantidad de votos: " & mayorVotos)
                        Else
                            Console.WriteLine("Todavia no se han registrado votos.")
                        End If
                    End If
                '---------------------'
                '--|mostrar_resumen|--'
                '---------------------'
                Case 8
                    If cantidad = 0 Then
                        Console.WriteLine("No hay candidatos registrados.")
                    Else
                        Dim totalVotos As Integer = 0
                        Dim activos As Integer = 0
                        Dim inactivos As Integer = 0
                        Dim mayorVotos As Integer = -1
                        Dim menorVotos As Integer = Integer.MaxValue
                        Dim ganador As String = ""
                        Dim candidatoMenor As String = ""
                        For i As Integer = 0 To cantidad - 1
                            totalVotos += votos(i)
                            If estados(i) = "Activo" Then
                                activos += 1
                            ElseIf estados(i) = "Inactivo" Then
                                inactivos += 1
                            End If
                            If votos(i) > mayorVotos Then
                                mayorVotos = votos(i)
                                ganador = nombres(i)
                            End If
                            If votos(i) < menorVotos Then
                                menorVotos = votos(i)
                                candidatoMenor = nombres(i)
                            End If
                        Next
                        Dim promedioVotos As Double = totalVotos / cantidad
                        Console.WriteLine("RESUMEN DE LA ELECCION")
                        Console.WriteLine("Total de candidatos: " & cantidad)
                        Console.WriteLine("Candidatos activos: " & activos)
                        Console.WriteLine("Candidatos inactivos: " & inactivos)
                        Console.WriteLine("Total de votos: " & totalVotos)
                        Console.WriteLine("Promedio de votos por candidato: " & promedioVotos.ToString("F2"))
                        Console.WriteLine("Candidato con mayor cantidad de votos: " & ganador)
                        Console.WriteLine("Mayor cantidad de votos: " & mayorVotos)
                        Console.WriteLine("Candidato con menor cantidad de votos: " & candidatoMenor)
                        Console.WriteLine("Menor cantidad de votos: " & menorVotos)
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 9
                    Console.WriteLine("Saliendo del simulador de elecciones...")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 9
    End Sub
End Module