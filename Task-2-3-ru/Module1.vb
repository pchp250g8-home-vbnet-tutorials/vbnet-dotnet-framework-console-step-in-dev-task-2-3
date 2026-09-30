Module Module1

    Sub Main()
		' Инициализация переменных
		Dim direction As Integer = 0 ' 0: направление неизвестно, 1: вверх, -1: вниз
		Dim changes As UInteger = 0 ' Счетчик смен направления
		Dim new_direction As Integer = direction ' Новое направление
		Dim prev As UInteger = Nothing, current As UInteger = Nothing ' Номер этажа, на котором остановился лифт
		Dim b_done As Boolean = False ' Флаговая переменная условие выхода из цикла
		Console.WriteLine("Введите номера этажей, где останавливался лифт.")
		Console.WriteLine("0 - Конец ввода данных")
		' Считываем первый этаж
		UInteger.TryParse(Console.ReadLine(), prev)
		b_done = (prev = 0)
		' Цикл ввода и анализа входных данных
		' Данные вводятся до тех пор пока не будет получено число 0
		Do While Not b_done
			UInteger.TryParse(Console.ReadLine(), current) ' Вводим остальные этажи
			b_done = (current = 0) ' Выходим из цикла, если введен 0
			' Если этажи совпадают, направление не меняется,
			' просто пропускаем
			If Not b_done AndAlso current <> prev Then
				' Определяем новое текущее направление
				' между prev и current
				new_direction = 1
				If current > prev Then
					new_direction = -1
				End If
			End If
			' Если до этого направление уже было известно (не 0)
			' и оно не совпадает с новым направлением, значит произошла смена
			If Not b_done AndAlso direction <> 0 AndAlso new_direction <> direction Then
				changes += 1
			End If
			' Обновляем историю для следующего шага
			direction = new_direction
			prev = current
		Loop
		'--- Вывод информации на экран ----
		Console.WriteLine($"Количество смен направления лифтом: {changes}")
		Console.Read() ' Задержка вывода до нажатия клавиши "Ввод"
	End Sub

End Module
