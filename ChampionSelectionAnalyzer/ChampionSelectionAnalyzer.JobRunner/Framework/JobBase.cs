﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace ChampionSelectionAnalyzer.JobRunner.Framework
{
    internal abstract class JobBase<TResult> : IJob
    {
        private readonly Action<TResult> _resultAction;

        protected JobBase(Action<TResult> resultAction = null)
        {
            _resultAction = resultAction;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            OnStarted();

            cancellationToken.Register(OnCancelled);

            var result = await DoWorkAsync(cancellationToken);

            _resultAction?.Invoke(result);
        }

        protected abstract Task<TResult> DoWorkAsync(CancellationToken cancellationToken);

        protected virtual void OnStarted()
        {
            LogManager.GetLogger(GetType().Name).Info($"{this} started.");
        }

        protected virtual void OnCancelled()
        {
            LogManager.GetLogger(GetType().Name).Info($"{this} cancelled.");
        }
    }
}
