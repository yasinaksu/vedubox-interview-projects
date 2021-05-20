using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.WebAPI.Business.Abstract;
using StudentManagementSystem.WebAPI.Entities;
using StudentManagementSystem.WebAPI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var loginResult = await _authService.LoginAsync(userForLoginDto);
            if (loginResult.Success == false)
            {
                return BadRequest(loginResult.Message);
            }

            var tokenCreateResult = await _authService.CreateAccessTokenAsync(loginResult.Data);

            if (tokenCreateResult.Success == false)
            {
                return BadRequest(tokenCreateResult.Message);
            }

            return Ok(tokenCreateResult.Data);
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAsAdmin(UserForRegisterDto userForRegisterDto)
        {
            var userExists = await _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var admin = new Admin
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName
            };
            var registerResult = await _authService.RegisterAsync(admin,userForRegisterDto.Password);
            var result = await _authService.CreateAccessTokenAsync(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterAsStudent(StudentForRegisterDto studentForRegisterDto)
        {
            var userExists = await _authService.UserExists(studentForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var student = new Student
            {
                Email = studentForRegisterDto.Email,
                FirstName = studentForRegisterDto.FirstName,
                LastName = studentForRegisterDto.LastName,
                Education = studentForRegisterDto.Education
            };
            var registerResult = await _authService.RegisterAsync(student, studentForRegisterDto.Password);
            var result = await _authService.CreateAccessTokenAsync(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register-teacher")]
        public async Task<IActionResult> RegisterAsTeacher(TeacherForRegisterDto teacherForRegisterDto)
        {
            var userExists = await _authService.UserExists(teacherForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var teacher = new Teacher
            {
                Email = teacherForRegisterDto.Email,
                FirstName = teacherForRegisterDto.FirstName,
                LastName = teacherForRegisterDto.LastName,
                Branch = teacherForRegisterDto.Branch
            };
            var registerResult = await _authService.RegisterAsync(teacher, teacherForRegisterDto.Password);
            var result = await _authService.CreateAccessTokenAsync(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
