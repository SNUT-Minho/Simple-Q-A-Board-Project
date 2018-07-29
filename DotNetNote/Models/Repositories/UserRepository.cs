using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using Dapper;

namespace DotNetNote.Models.ViewModels
{
    public class UserRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public UserViewModel AddUser(UserViewModel user)
        {
          
            // TransScationScope 쓰려면 참조에 추가시켜야됨 / 기본 추가 클래스가 아님
            using (var txScope = new TransactionScope())
            {  // 매개변수 준비
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DomainID", user.DomainID);
                parameters.Add("@Name", user.Name);
                parameters.Add("@Description", user.Description);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Blocked", user.Blocked);
                parameters.Add("@GroupUID", 3);   // 회원가입시 무조건 Users 권한 부여(3)

                //parameters.Add("@UID", value: user.UID, dbType: DbType.Int32, direction: ParameterDirection.InputOutput); // 반환형 매개 변수
                parameters.Add("@UID", dbType: DbType.Int32, direction: ParameterDirection.Output); // 아웃풋 매개변수만 사용할때

                parameters.Add("@PhoneNumber", user.PhoneNumber);
                parameters.Add("@Address", user.Address);
                parameters.Add("@Gender", user.Gender);
                parameters.Add("@BirthDate", user.BirthDate);
                parameters.Add("@Country", user.Country);

                // 저장: 저장 프로시저 실행
                this.db.Execute("AddUser", null , commandType: CommandType.StoredProcedure);

                // 반환형 매개변수 값 받기
                user.UID = parameters.Get<int>("@UID");

                txScope.Complete();

                return user;
            }
        }

        //public UserViewModel ReadUser(UserViewModel userViewModel) { }

       // public UserViewModel UpdateUser(UserViewModel userViewModel) { }

       // public UserViewModel DeleteUser(UserViewModel userViewModel) { }
    }
}