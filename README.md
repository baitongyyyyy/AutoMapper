﻿# AutoMapper

//Config At Program.cs
var map = WebApplication.CreateBuilder(args);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<MappingProfile>();
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


//Map List
//address = _mapper.Map<List<MotorPostcode>, List<ResFilterAddress>>(motorList);


//FirstOrDefault
//var address = _mapper.Map<ResFilterAddress>(motorList);
