using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using demo.Models;
using System.Diagnostics;
using demo.Common;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly string ConnectionString;

        public UserController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            ConnectionString = configuration.GetConnectionString("AppDbContext");
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<UserItem>>> PostLogin([FromForm] RequestLogin requestLogin)
        {
            Response<UserItem> response = new Response<UserItem>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "PCD_USER_LOGIN"
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@in_prc_gbn", SqlDbType.Int)).Value = requestLogin.type;
                        cmd.Parameters.Add(new SqlParameter("@in_user_id", SqlDbType.NVarChar)).Value = requestLogin.id;
                        cmd.Parameters.Add(new SqlParameter("@in_user_pass", SqlDbType.NVarChar)).Value = requestLogin.pw;
                        cmd.Parameters.Add(new SqlParameter("@in_user_token", SqlDbType.NVarChar)).Value = requestLogin.token;
                        cmd.Parameters.Add(new SqlParameter("@out_result_code", SqlDbType.Char, 2)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@out_result_msg", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;

                        DataTable dt = new DataTable();
                        using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        adapter.Dispose();

                        response.code = cmd.Parameters[Constants.PARAMS_OUTPUT_CODE].Value.ToString();
                        response.message = cmd.Parameters[Constants.PARAMS_OUTPUT_MSSAGE].Value.ToString();
                        Debug.WriteLine($"@out_result_code : {response.code}, @out_result_msg : {response.message}");

                        if (response.code is null) return response;
                        if (!response.code.Equals(Constants.RESPONSE_SUCCESE)) return response;

                        var list = new List<UserItem>();
                        foreach (DataRow row in dt.Rows)
                        {
                            var item = new UserItem()
                            {
                                user_idx = row[nameof(UserItem.user_idx)].ToUInt16(),
                                permit_type = row[nameof(UserItem.permit_type)].ToString(),
                                user_nm = row[nameof(UserItem.user_nm)].ToString(),
                                user_id = row[nameof(UserItem.user_id)].ToString(),
                                user_hp = row[nameof(UserItem.user_hp)].ToString(),
                                user_email = row[nameof(UserItem.user_email)].ToString(),
                                app_os = row[nameof(UserItem.app_os)].ToString(),
                                user_token = row[nameof(UserItem.user_token)].ToString(),
                                department = row[nameof(UserItem.department)].ToString(),
                                position = row[nameof(UserItem.position)].ToString(),
                                direct_tel = row[nameof(UserItem.direct_tel)].ToString(),
                                support_center = row[nameof(UserItem.support_center)].ToString(),
                                comm_agent_idx = row[nameof(UserItem.comm_agent_idx)].ToUInt16(),
                                agent_nm = row[nameof(UserItem.agent_nm)].ToString(),
                                agent_manager_nm = row[nameof(UserItem.agent_manager_nm)].ToString(),
                                main_tel = row[nameof(UserItem.main_tel)].ToString(),
                                agent_type = row[nameof(UserItem.agent_type)].ToString(),
                                another_data = ""
                            };
                            list.Add(item);
                        }
                        response.data = list;
                    }
                }
            }
            catch (Exception e)
            {
                response.code = Constants.RESPONSE_FAIL;
                response.message = e.Message;
            }

            return response;
        }

        //     [HttpGet("login")]
        //     public async Task<ActionResult<List<UserItem>>> GetLogin()
        //     {
        //         SqlParameter[] parameters =
        //         {
        //             new SqlParameter("@in_prc_gbn", 1),
        //             new SqlParameter("@in_user_id", "home1"),
        //             new SqlParameter("@in_user_pass", "a123456"),
        //             new SqlParameter("@in_user_token", "gegvdgrehreh"),
        //             new SqlParameter
        //             {
        //                 ParameterName = "@out_result_code",
        //                 Direction = ParameterDirection.Output,
        //                 Size = 2
        //             },
        //             new SqlParameter
        //             {
        //                 ParameterName = "@out_result_msg",
        //                 Direction = ParameterDirection.Output,
        //                 Size = 100
        //             }
        //         };

        //         string sql = "EXECUTE dbo.PCD_USER_LOGIN {0}, {1}, {2}, {3}, {4} OUTPUT, {5} OUTPUT";
        //         var response = await _context.UserItems.FromSqlRaw(sql, parameters).ToListAsync<UserItem>();
        //         return response;
        //     }
    }
}
