using System.Data.SqlClient;
using VKProject.Models;

namespace VKProject.Utils;

public static class DataBaseReader
{
    private const string ConnectionString =
        "Data Source=wsb-003-73;Initial Catalog=VK_Database;Integrated Security=True;";
    private const string Request = "Select * from users where id=@Fid";

    public static User GetUser(int userId)
    {
        var user = new User();
        using var myConnection = new SqlConnection(ConnectionString);
        var oCmd = new SqlCommand(Request, myConnection);
        oCmd.Parameters.AddWithValue("@Fid", userId);
        myConnection.Open();
        using var oReader = oCmd.ExecuteReader();
        while (oReader.Read())
        {
            user.Login = oReader["login"].ToString();
            user.Password = oReader["password"].ToString();
            user.Token = oReader["token"].ToString();
            user.UserId = oReader["user_id"].ToString();
            user.UserName = oReader["name"].ToString();
        }

        // using (var oReader = oCmd.ExecuteReader())
        // {
        //     user.Login = oReader["login"].ToString();
        //     user.Password = oReader["password"].ToString();
        //     user.Token = oReader["token"].ToString();
        //     user.UserId = oReader["user_id"].ToString();
        //     user.UserName = oReader["name"].ToString();
        // }

        myConnection.Close();

        return user;
    }
}
