﻿using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkflowSteps;
using WorkflowSteps.Interface;

namespace QuartzWithCore.Tasks
{
    public class ReserveTicketsTask : IJob
    {
        private IStep[] _workflowSteps;
        public ReserveTicketsTask()
        {
            _workflowSteps = new IStep[3]
            {
                new GetPriceStep(),
                new ReserveTickets(),
                new PrintReceiptStep(),
            };
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                foreach (var step in _workflowSteps)
                {
                    step.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
    }
}
