using System;
using System.Collections.Generic;

namespace ExceptionsHandlerService.Extensions
{
	public static class ExceptionExtensions
	{
		#region ARGUMENT_NULL_EXCEPTION
		
		public static ArgumentNullException ArgumentNullException()
		{
			return new ArgumentNullException(
				$"Argument is NULL!"); 
		}
		
		public static ArgumentNullException ArgumentNullException(Exception innerException)
		{
			return new ArgumentNullException(
				$"Argument is NULL!"
				, innerException); 
		}
		
		public static ArgumentNullException ArgumentNullException(string argumentName)
		{
			return new ArgumentNullException(
				$"Argument: {argumentName} is NULL!"); 
		}
		
		public static ArgumentNullException ArgumentNullException(string argumentName, Exception innerException)
		{
			return new ArgumentNullException(
				$"Argument: {argumentName} is NULL!"
				, innerException); 
		}
		
		#endregion
		
		#region ARGUMENT_OUT_OF_RANGE_EXCEPTION
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException()
		{
			return new ArgumentOutOfRangeException(
				$"Argument out of range!"); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			Exception innerException)
		{
			return new ArgumentOutOfRangeException( 
				$"Argument out of range!"
				, innerException); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName)
		{
			return new ArgumentOutOfRangeException(argumentName, 
				$"Argument: {argumentName} out of range!"); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, Exception innerException)
		{
			return new ArgumentOutOfRangeException(
				$"Argument: {argumentName} out of range!"
				, innerException); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value)
		{
			return new ArgumentOutOfRangeException(argumentName, value, 
				$"Argument: {argumentName} out of range! " +
				$"Actual value: {value}"); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value, Exception innerException)
		{
			return new ArgumentOutOfRangeException(
				$"Argument: {argumentName} out of range! " +
				$"Actual value: {value}"
				, innerException); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value, int count)
		{
			return new ArgumentOutOfRangeException(argumentName, value, 
				$"Argument: {argumentName} out of range {0}-{count}! " +
				$"Actual value: {value}"); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value, int count, Exception innerException)
		{
			return new ArgumentOutOfRangeException(
				$"Argument: {argumentName} out of range {0}-{count}! " +
				$"Actual value: {value}"
				, innerException); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value, int rangeMin, int rangeMax)
		{
			return new ArgumentOutOfRangeException(argumentName, value, 
				$"Argument: {argumentName} out of range {rangeMin}-{rangeMax}! " +
				$"Actual value: {value};"); 
		}
		
		public static ArgumentOutOfRangeException ArgumentOutOfRangeException(
			string argumentName, int value, int rangeMin, int rangeMax, Exception innerException)
		{
			return new ArgumentOutOfRangeException(
				$"Argument: {argumentName} out of range {rangeMin}-{rangeMax}! " +
				$"Actual value: {value};"
				, innerException); 
		}
		
		#endregion
		
		#region INDEX_OUT_OF_RANGE_EXCEPTION
		
		public static IndexOutOfRangeException IndexOutOfRangeException()
		{
			return new IndexOutOfRangeException( 
				$"Index out of range!"); 
		}
		
		public static IndexOutOfRangeException IndexOutOfRangeException(
			Exception innerException)
		{
			return new IndexOutOfRangeException( 
				$"Index out of range!"
				, innerException); 
		}
		
		public static IndexOutOfRangeException IndexOutOfRangeException(
			object actualValue)
		{
			return new IndexOutOfRangeException( 
				$"Index out of range! " +
				$"Actual value: {actualValue}"); 
		}
		
		public static IndexOutOfRangeException IndexOutOfRangeException(
			object actualValue, Exception innerException)
		{
			return new IndexOutOfRangeException( 
				$"Index out of range! " +
				$"Actual value: {actualValue}"
				, innerException); 
		}
		
		public static IndexOutOfRangeException IndexOutOfRangeException(
			object actualValue, int length)
		{
			return new IndexOutOfRangeException( 
				$"Index out of range! " +
				$"Actual value: {actualValue}\n" +
				$"Collection length: {length}"); 
		}
		
		public static IndexOutOfRangeException IndexOutOfRangeException(
			object actualValue, int length, Exception innerException)
		{
			return new IndexOutOfRangeException( 
				$"Index out of range! " +
				$"Actual value: {actualValue}\n" +
				$"Collection length: {length}"
				, innerException); 
		}

		#endregion
		
		#region KEY_NOT_FOUND_EXCEPTION
		
		public static KeyNotFoundException KeyNotFoundException()
		{
			return new KeyNotFoundException( 
				$"Key not found!"); 
		}
		
		public static KeyNotFoundException KeyNotFoundException(Exception innerException)
		{
			return new KeyNotFoundException( 
				$"Key not found!"
				, innerException); 
		}
		
		public static KeyNotFoundException KeyNotFoundException(
			object keyValue)
		{
			return new KeyNotFoundException( 
				$"Key not found! " +
				$"Key value: {keyValue}"); 
		}
		
		public static KeyNotFoundException KeyNotFoundException(
			object keyValue, Exception innerException)
		{
			return new KeyNotFoundException( 
				$"Key not found! " +
				$"Key value: {keyValue}"
				, innerException); 
		}
		
		#endregion
		
		#region NULL_REFERENCE 
					
		public static NullReferenceException NullReferenceException()
		{
			return new NullReferenceException( 
				$"Null reference!"); 
		}
		
		public static NullReferenceException NullReferenceException(
			Exception innerException)
		{
			return new NullReferenceException( 
				$"Null reference!"
				, innerException); 
		}
		
		public static NullReferenceException NullReferenceException(
			string variableName)
		{
			return new NullReferenceException( 
				$"Null reference! " + 
				$"Variable name: {variableName}"); 
		}
		
		public static NullReferenceException NullReferenceException(
			string variableName, Exception innerException)
		{
			return new NullReferenceException( 
				$"Null reference! " + 
				$"Variable name: {variableName}"
				, innerException); 
		}
		
		#endregion
	}
}