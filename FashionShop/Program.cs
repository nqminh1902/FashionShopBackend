using FashionShopBL;
using FashionShopBL.BaseBL;
using FashionShopBL.CandidateBL;
using FashionShopBL.CandidateScheduleBL;
using FashionShopBL.CandidateScheduleDetailBL;
using FashionShopBL.EducationMajorBL;
using FashionShopBL.EliminateReasonBL;
using FashionShopBL.EmailBL;
using FashionShopBL.ExportBL;
using FashionShopBL.ImportBL;
using FashionShopBL.JobPositionBL;
using FashionShopBL.PermissionBL;
using FashionShopBL.RecruitmentBL;
using FashionShopBL.RecruitmentDetailBL;
using FashionShopBL.RecruitmentPeriodBL;
using FashionShopBL.RecruitmentRoundBL;
using FashionShopBL.Report;
using FashionShopBL.RoleBL;
using FashionShopBL.UniversityBL;
using FashionShopBL.UserBL;
using FashionShopBL.WorkLocationBL;
using FashionShopDL;
using FashionShopDL.BaseDL;
using FashionShopDL.CandidateDL;
using FashionShopDL.CandidateScheduleDetailDL;
using FashionShopDL.CandidateScheduleDL;
using FashionShopDL.EducationMajorDL;
using FashionShopDL.EliminateReasonDL;
using FashionShopDL.EmailDL;
using FashionShopDL.JobPositionDL;
using FashionShopDL.PermissionDL;
using FashionShopDL.RecruitmentBroadDL;
using FashionShopDL.RecruitmentDetailDL;
using FashionShopDL.RecruitmentDL;
using FashionShopDL.RecruitmentPeriodDL;
using FashionShopDL.RecruitmentRoundDL;
using FashionShopDL.ReportDL;
using FashionShopDL.RoleDL;
using FashionShopDL.UniversityDL;
using FashionShopDL.UserDL;
using FashionShopDL.WorkExperientDL;
using FashionShopDL.WorkLocationDL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped<IRecruitmentDL, RecruitmentDL>();
builder.Services.AddScoped<IRecruitmentBL, RecruitmentBL>();
builder.Services.AddScoped<IRecruitmentPeriodDL, RecruitmentPeriodDL>();
builder.Services.AddScoped<IRecruitmentPeriodBL, RecruitmentPeriodBL>();
builder.Services.AddScoped<IRecruitmentRoundBL, RecruitmentRoundBL>();
builder.Services.AddScoped<IRecruitmentRoundDL, RecruitmentRoundDL>();
builder.Services.AddScoped<ICandidateDL, CandidateDL>();
builder.Services.AddScoped<ICandidateBL, CandidateBL>();
builder.Services.AddScoped<IWorkExperientDL, WorkExperientDL>();
builder.Services.AddScoped<IRecruitmentDetailDL, RecruitmentDetailDL>();
builder.Services.AddScoped<IRecruitmentDetailBL, RecruitmentDetailBL>();
builder.Services.AddScoped<IRecruitmentBroadDL, RecruitmentBroadDL>();
builder.Services.AddScoped<ICandidateScheduleBL, CandidateScheduleBL>();
builder.Services.AddScoped<ICandidateScheduleDL, CandidateScheduleDL>();
builder.Services.AddScoped<ICandidateScheduleDetailDL, CandidateScheduleDetailDL>();
builder.Services.AddScoped<ICandidateScheduleDetailBL, CandidateScheduleDetailBL>();
builder.Services.AddScoped<IReportBL, ReportBL>();
builder.Services.AddScoped<IReportDL, ReportDL>();
builder.Services.AddScoped<IEmailBL, EmailBL>();
builder.Services.AddScoped<IEmailDL, EmailDL>();
builder.Services.AddScoped<IImportBL, ImportBL>();
builder.Services.AddScoped<IUniversityBL, UniversityBL>();
builder.Services.AddScoped<IUniversityDL, UniversityDL>();
builder.Services.AddScoped<IEducationMajorBL, EducationMajorBL>();
builder.Services.AddScoped<IEducationMajorDL, EducationMajorDL>();
builder.Services.AddScoped<IEliminateReasonBL, EliminateReasonBL>();
builder.Services.AddScoped<IEliminateReasonDL, EliminateReasonDL>();
builder.Services.AddScoped<IWorkLocationDL, WorkLocationDL>();
builder.Services.AddScoped<IWorkLocationBL, WorkLocationBL>();
builder.Services.AddScoped<IJobPositionBL, JobPositionBL>();
builder.Services.AddScoped<IJobPositionDL, JobPositionDL>();
builder.Services.AddScoped<IExportBL, ExportBL>();
builder.Services.AddScoped<IRoleDL, RoleDL>();
builder.Services.AddScoped<IRoleBL, RoleBL>();
builder.Services.AddScoped<IPermissionDL, PermissionDL>();
builder.Services.AddScoped<IPermissionBL, PermissionBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDL, UserDL>();


// Lấy dữ liệu từ connectionString từ file appsetting.Development.json
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("MySQL");

// Fix lỗi cors
builder.Services.AddCors();

// Chặn ErrorMessage mặc định của visualStudio
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
