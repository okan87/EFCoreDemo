# EFCoreDemo
Entity Framework(CRUD)
![efcorecrud](https://user-images.githubusercontent.com/103388852/226738276-aeefc120-38eb-4567-b390-790d9c45a67b.png)



program.cs:

var provider = builder.Services.BuildServiceProvider();

var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<EFCoreDemoContext>(item => item.UseSqlServer(configuration.GetConnectionString("EFCoreDemoConnection")));

appsettings.json:

"ConnectionStrings": {
    "EFCoreDemoConnection": "Server=(localDb)\\SQLEXPRESS;Database=EFCoreDemoDB;Trusted_Connection=True;Encrypt=False"
  },
