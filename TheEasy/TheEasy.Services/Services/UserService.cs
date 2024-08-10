using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheEasy.Data.IRepositories;
using TheEasy.Domain.Entities;
using TheEasy.Services.DTOs.Users;
using TheEasy.Services.Exceptions;
using TheEasy.Services.Interfaces;

namespace TheEasy.Services.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    private readonly IMapper mapper;
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var model = await this.repository.SelectAll().
            FirstOrDefaultAsync(u => u.Email.ToLower() ==  dto.Email.ToLower());

        if(model is null)
        {
            throw new CustomException(409, "User is already exits");
        }

        var mappingUser = mapper.Map<User>(dto);

        var result = await this.repository.InsertAsync(mappingUser);

        return this.mapper.Map<UserForResultDto>(result);
            
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var model = await this.repository.SelectAll().
            ToListAsync();

        return this.mapper.Map<IEnumerable<UserForResultDto>>(model);
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var model = await this.repository.SelectAll().
            FirstOrDefaultAsync(u => u.Id == id);

        if(model is null)
        {
            throw new CustomException(404, "User is not found");
        }

        return this.mapper.Map<UserForResultDto>(model);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var model = await this.repository.SelectByIdAsync(id);

        if(model is null)
        {
            throw new CustomException(404, "User is not found");
        }

        return await this.repository.DeleteAsync(id);

    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var model = await this.repository.SelectByIdAsync(dto.Id);

        if(model is null)
        {
            throw new CustomException(404, "User is not found");
        }

        var mapper = this.mapper.Map<User>(dto);
        mapper.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mapper);

        return this.mapper.Map<UserForResultDto>(result);
    }
}
