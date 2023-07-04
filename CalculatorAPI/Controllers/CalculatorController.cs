using CalculatorBase;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace CalculatorAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        /*
         TODO:
            Record in DB every request for Get Addition endpoint
            every request must have a requester  ID
            Example: 
                - Request is made
                - Operations is resolved
                - Open DB Connection
                - Perform insert statement
                 
         */
        SqlConnection con = new SqlConnection("server=SPX-WL-ANEESH\\SQLEXPRESS; database=aneeshdb;Integrated Security=true;");
       
        
        [HttpGet("All data")]
        public string  Get()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from [dbo].[OperationLogs]", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "No Data Found";
        }
       
        
        [HttpPost("Insert")]
        public string Post(int LogID, int RequestedUserId, string OperationType,decimal OperationInput1,decimal OperationInput2,decimal Operation_Result,DateTime Operations_DateTime)
        { 
            SqlCommand cmd = new SqlCommand("INSERT INTO OperationLogs(LogID,RequestedUserId,OperationType,OperationInput1,OperationInput2,Operation_Result,Operations_DateTime) VALUES ("+ LogID + ","+ RequestedUserId +",'"+ OperationType + "',"+ OperationInput1 + "," +OperationInput2+ ","+ Operation_Result +",'"+ Operations_DateTime+ "')",con);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Inserted Successfully";
            }
            else
            {
                return "No Data Inserted";
            }
        }
        [HttpGet("Fetch data By Id")]
        public string Get(int LogId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from [dbo].[OperationLogs] WHERE  LogId ="+LogId+"", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
                return "No Data Found";
        }

        [HttpPut("Put")]
        public string Put(int LogID, int RequestedUserId, string OperationType, decimal OperationInput1, decimal OperationInput2, decimal Operation_Result, DateTime Operations_DateTime)
        {
            SqlCommand cmd = new SqlCommand("UPDATE OperationLogs SET   RequestedUserId=" + RequestedUserId + ", OperationType='" + OperationType + "', OperationInput1=" + OperationInput1 + ", OperationInput2=" + OperationInput2 + ", Operation_Result=" + Operation_Result + ", Operations_DateTime='" + Operations_DateTime + "' WHERE LogId="+LogID+"", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Updated Successfully";
            }
            else
            {
                return "No Data Updated";
            }
        }

        [HttpDelete("Delete data By Id")]
        public string Delete(int LogId)
        {
            SqlCommand cnd = new SqlCommand("DELETE from [dbo].[OperationLogs] WHERE  LogId =" + LogId + "", con);
            con.Open();
            int i = cnd.ExecuteNonQuery();
            con.Close();
            if (i==1)
            {
                return "Record Deleted";
            }
            else
                return "No Data Found";
        }


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