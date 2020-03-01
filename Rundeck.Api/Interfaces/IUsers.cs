﻿using Refit;
using Rundeck.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rundeck.Api.Interfaces
{
	public interface IUsers
	{
		/// <summary>
		/// Gets a list of users
		/// </summary>
		/// <param name="cancellationToken"></param>
		[Get("/api/27/user/list/")]
		Task<List<User>> GetAllAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Hey, get me!
		/// </summary>
		/// <param name="cancellationToken"></param>
		[Get("/api/27/user/info/")]
		Task<User> GetMeAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get a specific user
		/// </summary>
		/// <param name="cancellationToken"></param>
		[Get("/api/27/user/info/{login}")]
		Task<User> GetAsync(
			string login,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Update a specific user
		/// </summary>
		/// <param name="login">The user login</param>
		/// <param name="user">The user object</param>
		/// <param name="cancellationToken"></param>
		[Post("/api/27/user/info/{login}")]
		Task<User> UpdateAsync(
			string login,
			[Body] User user,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Gets the current user's roles
		/// </summary>
		/// <param name="cancellationToken"></param>
		[Post("/api/30/user/roles")]
		Task<RoleSet> GetMyRoleSetAsync(
			CancellationToken cancellationToken = default);
	}
}
