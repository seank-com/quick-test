// https://dotnetfiddle.net/
using System;
using System.Collections.Generic;

					
public class Program
{
	public static int[,] board = {
		{5, 3, 4, 6, 7, 8, 9, 0, 0},
		{6, 7, 2, 1, 9, 5, 3, 4, 8},
		{1, 9, 8, 3, 4, 2, 5, 6, 7},
		{8, 5, 9, 7, 6, 1, 4, 2, 3},
		{4, 2, 6, 8, 5, 3, 7, 9, 0},
		{7, 1, 3, 9, 2, 4, 8, 5, 6},
		{9, 6, 1, 5, 3, 7, 2, 8, 4},
		{2, 8, 7, 4, 1, 9, 6, 3, 5},
		{3, 4, 5, 2, 8, 6, 1, 7, 9}
	};
	
	public static void printBoard() 
	{
		Console.WriteLine($"{board[0,0]}{board[0,1]}{board[0,2]}|{board[0,3]}{board[0,4]}{board[0,5]}|{board[0,6]}{board[0,7]}{board[0,8]}");
		Console.WriteLine($"{board[1,0]}{board[1,1]}{board[1,2]}|{board[1,3]}{board[1,4]}{board[1,5]}|{board[1,6]}{board[1,7]}{board[1,8]}");
		Console.WriteLine($"{board[2,0]}{board[2,1]}{board[2,2]}|{board[2,3]}{board[2,4]}{board[2,5]}|{board[2,6]}{board[2,7]}{board[2,8]}");
		Console.WriteLine( "-----------");

		Console.WriteLine($"{board[3,0]}{board[3,1]}{board[3,2]}|{board[3,3]}{board[3,4]}{board[3,5]}|{board[3,6]}{board[3,7]}{board[3,8]}");
		Console.WriteLine($"{board[4,0]}{board[4,1]}{board[4,2]}|{board[4,3]}{board[4,4]}{board[4,5]}|{board[4,6]}{board[4,7]}{board[4,8]}");
		Console.WriteLine($"{board[5,0]}{board[5,1]}{board[5,2]}|{board[5,3]}{board[5,4]}{board[5,5]}|{board[5,6]}{board[5,7]}{board[5,8]}");
		Console.WriteLine( "-----------");

		Console.WriteLine($"{board[6,0]}{board[6,1]}{board[6,2]}|{board[6,3]}{board[6,4]}{board[6,5]}|{board[6,6]}{board[6,7]}{board[6,8]}");
		Console.WriteLine($"{board[7,0]}{board[7,1]}{board[7,2]}|{board[7,3]}{board[7,4]}{board[7,5]}|{board[7,6]}{board[7,7]}{board[7,8]}");
		Console.WriteLine($"{board[8,0]}{board[8,1]}{board[8,2]}|{board[8,3]}{board[8,4]}{board[8,5]}|{board[8,6]}{board[8,7]}{board[8,8]}");
	}
	
	public static List<int> getValidValues(int row, int col)
	{
		List<int> result = new List<int>();
		
		HashSet<int> seen = new HashSet<int>();
		
		int rowOffset = (row / 3) * 3;
		int colOffset = (col / 3) * 3;
		for (int i = 0; i < 3; i += 1)
		{
			for (int j = 0; j < 3; j += 1)
			{
				int k = (i*3)+j;
				int v = rowOffset + i;
				int w = colOffset + j;
				
				int val = board[row, k];
				if (k != col && val != 0) 
					seen.Add(val);

				val = board[k, col];
				if (k != row && val != 0) 
					seen.Add(val);

				val = board[v, w];
				if ((v != row || w != col) && val != 0) 
					seen.Add(val);
			}
		}
		
		for (int i = 1; i < 10; i += 1)
		{
			if (!seen.Contains(i))
				result.Add(i);
		}
		
		return result;
	}
	
	public static string validSolution()
	{
		int[] rows = { 0,0,0,0,0,0,0,0,0 };
		int[] cols = { 0,0,0,0,0,0,0,0,0 };
		int[] sqrs = { 0,0,0,0,0,0,0,0,0 };
		
		for (int i = 0; i < 9; i += 1)
		{
			for (int j = 0; j < 9; j += 1)
			{
				int val = board[i,j];
				if (val < 1 || val > 9)
					return $"Value at {i},{j} is out of range";
				
				rows[i] += val;
				cols[j] += val;
				sqrs[(3*(i/3))+(j/3)] += val;
			}
		}
					  
	    for (int t = 0; t < 9; t += 1)
		{
			if (rows[t] != 45)
				return $"Row {t} does not add to 45";
			if (cols[t] != 45)
				return $"Column {t} does not add to 45";
			if (sqrs[t] != 45)
				return $"Square {t} does not add to 45";
		}
					  
		return "Board is a valid solution";
	}
	
	public static void Main()
	{
		printBoard();
		var result = getValidValues(0,8);
		foreach(var v in result)
			Console.WriteLine(v);
//		Console.WriteLine(validSolution());
	}
}