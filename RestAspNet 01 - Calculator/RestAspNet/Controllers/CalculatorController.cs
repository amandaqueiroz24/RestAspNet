using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAspNet.Controllers
{
	[Route("api/[controller]")]
	public class CalculatorController : Controller
	{

		// GET api/values/5
		[HttpGet("{firstNumber}/{secondNumber}")]
		public IActionResult Sum(String firstNumber, String secondNumber)
		{
			if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
			{
				var sum = Convert.ToInt32(firstNumber) + Convert.ToInt32(secondNumber);
				return Ok(sum.ToString());
			}
			return BadRequest("Invalid Input");
		}

		private bool IsNumeric(string strNumber)
		{
			double number;

			bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
			return isNumber;
		}
	}
}
