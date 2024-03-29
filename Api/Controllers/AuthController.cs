﻿using Api.Entities;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private IUserService _userService;

		public AuthController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]User userParam)
		{
			var user = _userService.Authenticate(userParam.Username, userParam.Password);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			return Ok(user);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();
			return Ok(users);
		}
	}
}
