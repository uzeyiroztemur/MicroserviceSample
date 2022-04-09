using Grpc.Core;
using UserPortalService.gRPCServer;

namespace UserPortalService.RestApi.Services
{
    public class UserService : UserGRPC.UserGRPCBase
    {
        public override Task<UsersModel> UserList(UserRequestModel request, ServerCallContext context)
        {

            var response = new UsersModel();

            List<UserModel> userList = new List<UserModel>() {
                    new UserModel() { Id=1,Name="david",LastName="totti"},
                    new UserModel() { Id=2,Name="lebron",LastName="maldini"} };

            response.Users.AddRange(userList);

            return Task.FromResult(response);
        }

        //public override async Task UserList(UserRequestModel request, IServerStreamWriter<UserListResponseModel> responseStream, ServerCallContext context)
        //{



        //    foreach (var item in userList)
        //    {
        //        await responseStream.WriteAsync(item);

        //    }



        //    //return base.UserList(request, responseStream, context);
        //}

        //public override Task<UserResponseModel> UserList(UserRequestModel request, ServerCallContext context)
        //{
        //    UserResponseModel responseModel = new UserResponseModel();
        //    responseModel.



        //    return base.UserList(request, context);
        //}
    }
}
