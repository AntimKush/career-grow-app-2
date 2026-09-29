using Career_Growth_App_2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Career_Growth.DataAccess
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IConfiguration configuration;

        public RegistrationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Save_Registration(CandidateRegistration candidateRegistration)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = configuration.GetConnectionString("DefaultConnection");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "dbo.Save_Registration";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Name", candidateRegistration.Name);
            cmd.Parameters.AddWithValue("FatherName", candidateRegistration.FatherName);
            cmd.Parameters.AddWithValue("DOB", candidateRegistration.DOB);
            cmd.Parameters.AddWithValue("Gender_Id", candidateRegistration.Gender_Id);
            cmd.Parameters.AddWithValue("Category_Id", candidateRegistration.Category_Id);
            cmd.Parameters.AddWithValue("Mobile_No", candidateRegistration.Mobile_No);
            cmd.Parameters.AddWithValue("Email", candidateRegistration.Email);
            cmd.Parameters.AddWithValue("Correspondent_Address", candidateRegistration.Correspondent_Address);
            cmd.Parameters.AddWithValue("Permanent_Address", candidateRegistration.Permanent_Address);
            cmd.Parameters.AddWithValue("Added_By_IP", candidateRegistration.IP_Address);

            conn.Open();
            int count = cmd.ExecuteNonQuery();

            conn.Close();

            if (count > 0)
                return "SUCCESS:Candidate Details saved successfully !!!";
            else
                return "ERROR:data could not be saved. Please try again !!!";


        }
    }
}
