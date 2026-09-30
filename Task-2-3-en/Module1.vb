Module Module1

    Sub Main()
		' Variable initialization
		Dim direction As Integer = 0 ' 0: direction unknown, 1: up, -1: down
		Dim changes As UInteger = 0 ' Counter for direction changes
		Dim new_direction As Integer = direction ' New direction
		Dim prev As UInteger = Nothing, current As UInteger = Nothing ' Floor number where the elevator stopped
		Dim b_done As Boolean = False ' Flag variable for loop exit condition
		Console.WriteLine("Enter the floor numbers where the elevator stopped.")
		Console.WriteLine("0 - End of data input")
		' Read the first floor
		UInteger.TryParse(Console.ReadLine(), prev)
		b_done = (prev = 0)
		' Loop for input and analysis
		' Data is entered until the number 0 is received
		Do While Not b_done
			UInteger.TryParse(Console.ReadLine(), current) ' Enter remaining floors
			b_done = (current = 0) ' Exit loop if 0 is entered
			' If floors are the same, direction doesn't change;
			' simply skip
			If Not b_done AndAlso current <> prev Then
				' Determine the new current direction
				' between prev and current
				new_direction = 1
				If current > prev Then
					new_direction = -1
				End If
			End If
			' If the direction was already known (not 0)
			' and it doesn't match the new direction, a change has occurred
			If Not b_done AndAlso direction <> 0 AndAlso new_direction <> direction Then
				changes += 1
			End If
			' Update history for the next step
			direction = new_direction
			prev = current
		Loop
		'--- Output information to the screen ----
		Console.WriteLine($"Number of elevator direction changes: {changes}")
		Console.Read() ' Pause output until "Enter" key is pressed
	End Sub

End Module
