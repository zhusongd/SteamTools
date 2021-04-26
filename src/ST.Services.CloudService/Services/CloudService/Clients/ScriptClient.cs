﻿using System.Application.Models;
using System.Application.Services.CloudService.Clients.Abstractions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace System.Application.Services.CloudService.Clients
{
	internal sealed class ScriptClient : ApiClient, IScriptClient
	{
		public ScriptClient(IApiConnection conn) : base(conn)
		{
		}
		public Task<IApiResponse<ScriptResponse>> Basics()
		{
			var url =
				$"api/script/basics";
			return conn.SendAsync<ScriptResponse>(
				isAnonymous: true,
				method: HttpMethod.Get,
				requestUri: url,
				cancellationToken: default,
				responseContentMaybeNull: true);
		}
		public Task<IApiResponse<PagedModel<ScriptDTO>>> ScriptTable(string? name = null, int pageIndex = 1, int pageSize = 15)
		{
			var url =
			$"api/script/table/{pageIndex}/{pageSize}/{name ?? string.Empty}";
			return conn.SendAsync<PagedModel<ScriptDTO>>(
				//isAnonymous: true,
				method: HttpMethod.Get,
				requestUri: url,
				cancellationToken: default,
				responseContentMaybeNull: true);
		}
		public Task<IApiResponse<IList<ScriptResponse>>> ScriptUpdateInfo(IEnumerable<Guid> ids) {
			var url =
				$"api/script/updates";
			return conn.SendAsync<IEnumerable<Guid>,IList <ScriptResponse>>(
				isAnonymous: true,
				method: HttpMethod.Post,
				request:ids,
				requestUri: url,
				cancellationToken: default);
		}
		
	}
}
