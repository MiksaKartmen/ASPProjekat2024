using ASPProjekat.Application;
using ASPProjekat.Application.Logging;
using ASPProjekat.Application.Mail;
using ASPProjekat.Application.UseCases.Commands;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Implementation;
using ASPProjekat.Implementation.Logging;
using ASPProjekat.Implementation.UseCases.Commands.EF;
using ASPProjekat.Implementation.UseCases.Queries.EF;
using ASPProjekat.Implementation.Validators;
using System.IdentityModel.Tokens.Jwt;

namespace ASPProjekat.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {

            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<ICreateMenuCategoryCommand, EfCreateMenuCategoryCommand>();
            services.AddTransient<IGetOneMenuCategoryQuery, EfGetOneMenuCategoryQuery>();
            services.AddTransient<IDeleteMenuCategoryCommand, EfDeleteMenuCategoryCommand>();
            services.AddTransient<IUpdateMenuCategoryCommand, EfUpdateMenuCategoryCommand>();
            services.AddTransient<CreateMenuCategoryDtoValidator>();
            services.AddTransient<DeleteMenuCategoryDtoValidator>();
            services.AddTransient<UpdateMenuCategoryDtoValidator>();

            services.AddTransient<IGetEmployeesQuery, EfGetEmployeesQuery>();
            services.AddTransient<ICreateEmployeeCommand, EfCreateEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, EfDeleteEmployeeCommand>();
            services.AddTransient<IUpdateEmployeeCommand, EfUpdateEmployeeCommand>();
            services.AddTransient<CreateEmployeeDtoValidator>();
            services.AddTransient<UpdateEmployeeDtoValidator>();
            services.AddTransient<DeleteEmployeeDtoValidator>();

            services.AddTransient<ICreateEmployeeRoleCommand, EfCreateEmployeeRoleCommand>();
            services.AddTransient<CreateEmployeeRoleDtoValidator>();

            services.AddTransient<ICreateMenuItemCommand, EfCreateMenuItemCommand>();
            services.AddTransient<IGetMenuItemsQuery, EfGetMenuItemsQuery>();
            services.AddTransient<IGetOneMenuItemQuery, EfGetOneMenuItemQuery>();
            services.AddTransient<IDeleteMenuItemCommand, EfDeleteMenuItemCommand>(); ;
            services.AddTransient<IUpdateMenuItemCommand, EfUpdateMenuItemCommand>(); ;
            services.AddTransient<CreateMenuItemDtoValidator>();
            services.AddTransient<DeleteMenuItemDtoValidator>();
            services.AddTransient<UpdateMenuItemDtoValidator>();

            services.AddTransient<ICreateMealTimeCommand, EfCreateMealTimeCommand>();
            services.AddTransient<IGetMealTimesQuery, EfGetMealTimesQuery>();
            services.AddTransient<IGetOneMealTimeQuery, EfGetOneMealTimeQuery>();
            services.AddTransient<IDeleteMealTimeCommand, EfDeleteMealTimeCommand>();
            services.AddTransient<IUpdateMealTimeCommand, EfUpdateMealTimeCommand>();
            services.AddTransient<CreateMealTimeDtoValidator>();
            services.AddTransient<UpdateMealTimeDtoValidator>();
            services.AddTransient<DeleteMealTimeDtoValidator>();

            services.AddTransient<IGetAuditLogsQuery, EfGetAuditLogsQuery>();

            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<CreateRoleDtoValidator>();
            services.AddTransient<UpdateRoleDtoValidator>();
            services.AddTransient<DeleteRoleDtoValidator>();

            services.AddTransient<IGetPriceQuery, EfGetPriceQuery>();
            services.AddTransient<ICreatePriceCommand, EfCreatePriceCommand>();
            services.AddTransient<IDeletePriceCommand, EfDeletePriceCommand>();
            services.AddTransient<CreatePriceDtoValidator>();
            services.AddTransient<DeletePriceDtoValidator>();

            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<DeleteUserDtoValidator>();
            services.AddTransient<CreateUserDtoValidator>();
            services.AddTransient<UpdateUserDtoValidator>();

            services.AddTransient<ICreateGalleryCommand, EfCreateGalleryCommand>();
            services.AddTransient<IUpdateGalleryCommand, EfUpdateGalleryCommand>();
            services.AddTransient<IDeleteGalleryCommand, EfDeleteGalleryCommand>();
            services.AddTransient<CreateGalleryDtoValidator>();
            services.AddTransient<UpdateGalleryDtoValidator>();
            services.AddTransient<DeleteGalleryDtoValidator>();

            services.AddTransient<ICreateGalleryImageCommand, EfCreateGalleryImageCommand>();
            services.AddTransient<IGetGalleryImagesQuery, EfGetGalleryImagesQuery>();
            services.AddTransient<IDeleteGalleryImageCommand, EfDeleteGalleryImageCommand>();
            services.AddTransient<IUpdateGalleryImageCommand, EfUpdateGalleryImageCommand>();
            services.AddTransient<CreateGalleryImageDtoValidator>();
            services.AddTransient<DeleteGalleryImageDtoValidator>();
            services.AddTransient<UpdateGalleryImageDtoValidator>();

            services.AddTransient<ICreateTableCommand, EfCreateTableCommand>();
            services.AddTransient<IGetTablesQuery, EfGetTablesQuery>();
            services.AddTransient<IUpdateTableCommand, EfUpdateTableCommand>();
            services.AddTransient<IDeleteTableCommand, EfDeleteTableCommand>();
            services.AddTransient<CreateTableDtoValidator>();
            services.AddTransient<UpdateTableDtoValidator>();
            services.AddTransient<DeleteTableDtoValidator>();

            services.AddTransient<ICreateUserImageCommand, EfCreateUserImageCommand>();
            services.AddTransient<IGetUserImagesQuery, EfGetUserImagesQuery>();
            services.AddTransient<IUpdateUserImageCommand, EfUpdateUserImageCommand>();
            services.AddTransient<IDeleteUserImageCommand, EfDeleteUserImageCommand>();
            services.AddTransient<CreateUserImageDtoValidator>();
            services.AddTransient<UpdateUserImageDtoValidator>();
            services.AddTransient<DeleteUserImageDtoValidator>();

            services.AddTransient<ICreateMenuItemMealTimeCommand, EfCreateMenuItemMealTimeCommand>();
            services.AddTransient<IDeleteMenuItemMealTimeCommand, EfDeleteMenuItemMealTimeCommand>();
            services.AddTransient<CreateMenuItemMealTimeDtoValidator>();
            services.AddTransient<DeleteMenuItemMealTimeDtoValidator>();

            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();

            services.AddTransient<ILogger, DbExceptionLogger>();
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<IEmailService>(provider =>
                new EmailService("smtp.gmail.com", 587, "mihajlo.jovanovic.52.21@ict.edu.rs", "fmhjphukwclcgeab"));
        }
        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
