﻿using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Rundeck.Api.Test
{
	public class MetricsTests : TestBase
	{
		public MetricsTests(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public async void Metrics_GetAsync_Passes()
		{
			var metrics = await RundeckClient
				.Metrics
				.GetAsync()
				.ConfigureAwait(false);

			metrics.Should().NotBeNull();
			metrics.Links.Should().NotBeNull();
			metrics.Links.Metrics.Should().NotBeNull();
			metrics.Links.Ping.Should().NotBeNull();
			metrics.Links.Healthcheck.Should().NotBeNull();
			metrics.Links.Threads.Should().NotBeNull();
		}

		[Fact]
		public async void Metrics_GetMetricsAsync_Passes()
		{
			var metrics = await RundeckClient
				.Metrics
				.GetMetricsAsync()
				.ConfigureAwait(false);

			metrics.Should().NotBeNull();
			metrics.Histograms.Should().NotBeNull();
			metrics.Meters.Should().NotBeNull();
			metrics.Timers.Should().NotBeNull();
			metrics.Version.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public async void Metrics_GetHealthCheckAsync_Passes()
		{
			var metrics = await RundeckClient
				.Metrics
				.GetHealthCheckAsync()
				.ConfigureAwait(false);

			metrics.Should().NotBeNull();
			metrics.DataSourceConnectionTime.Should().NotBeNull();
			metrics.QuartzSchedulerThreadPool.Should().NotBeNull();
		}

		[Fact]
		public async void Metrics_Ping_Passes()
		{
			var ping = await RundeckClient
				.Metrics
				.PingAsync()
				.ConfigureAwait(false);

			ping.Trim().Should().Be("pong");
		}
	}
}
