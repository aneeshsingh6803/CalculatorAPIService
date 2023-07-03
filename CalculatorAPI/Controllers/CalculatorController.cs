using CalculatorBase;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Addition")]
        public double GetAddition(double a, double b)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.Addition(a, b);
            return res;
        }

        [HttpGet("Subtraction")]
        public double GetSubtraction(double a, double b)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.Subtraction(a, b);
            return res;
        }

        [HttpGet("Multiplication")]
        public double GetMultiplication(double a, double b)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.Multiplication(a, b);
            return res;
        }
        [HttpGet("Division")]
        public double GetDivision(double a, double b)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.Divison(a, b);
            return res;
        }
        [HttpGet("Power")]
        public double GetPower(double a, double b)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.Power(a, b);
            return res;
        }
        [HttpGet("Square Root")]
        public double GetSquare_Root(double a)
        {
            BaseOperations BseOp = new BaseOperations();
            var res = BseOp.SquareRoot(a);
            return res;
        }
    }
}
