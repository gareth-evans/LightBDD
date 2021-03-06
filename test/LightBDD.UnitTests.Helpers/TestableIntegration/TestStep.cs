using System;
using System.Reflection;
using System.Threading.Tasks;
using LightBDD.Core.Extensibility;

namespace LightBDD.UnitTests.Helpers.TestableIntegration
{
    public static class TestStep
    {
        public static StepDescriptor CreateAsync(Action step) => new StepDescriptor(step.GetMethodInfo().Name, async (ctx, args) => { await Task.Delay(10); step.Invoke(); });
        public static StepDescriptor CreateSync(Action step) => new StepDescriptor(step.GetMethodInfo().Name, (ctx, args) => { step.Invoke(); return Task.FromResult(0); });
        public static StepDescriptor Create(Func<Task> step) => new StepDescriptor(step.GetMethodInfo().Name, (ctx, args) => step.Invoke());

        public static StepDescriptor CreateAsync<TArg>(Action<TArg> step, Func<TArg> argEvaluator)
        {
            Func<object, object[], Task> stepInvocation = async (ctx, args) =>
            {
                await Task.Yield();
                step.Invoke((TArg)args[0]);
            };
            var parameter = ParameterDescriptor.FromInvocation(step.GetMethodInfo().GetParameters()[0], ctx => argEvaluator.Invoke());

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }

        public static StepDescriptor CreateWithTypeAsync(string stepType, Action step) => new StepDescriptor(stepType, step.GetMethodInfo().Name, async (ctx, args) => { await Task.Yield(); step.Invoke(); });

        public static StepDescriptor CreateSync<TArg>(Action<TArg> step, Func<TArg> argEvaluator)
        {
            Func<object, object[], Task> stepInvocation = (ctx, args) =>
            {
                step.Invoke((TArg)args[0]);
                return Task.FromResult(0);
            };
            var parameter = ParameterDescriptor.FromInvocation(step.GetMethodInfo().GetParameters()[0], ctx => argEvaluator.Invoke());

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }
        public static StepDescriptor Create<TArg>(Func<TArg, Task> step, Func<TArg> argEvaluator)
        {
            Func<object, object[], Task> stepInvocation = (ctx, args) => step.Invoke((TArg)args[0]);
            var parameter = ParameterDescriptor.FromInvocation(step.GetMethodInfo().GetParameters()[0], ctx => argEvaluator.Invoke());

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }

        public static StepDescriptor CreateAsync<TArg>(Action<TArg> step, TArg arg)
        {
            Func<object, object[], Task> stepInvocation = async (ctx, args) =>
            {
                await Task.Yield();
                step.Invoke((TArg)args[0]);
            };
            var parameter = ParameterDescriptor.FromConstant(step.GetMethodInfo().GetParameters()[0], arg);

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }
        public static StepDescriptor CreateSync<TArg>(Action<TArg> step, TArg arg)
        {
            Func<object, object[], Task> stepInvocation = (ctx, args) =>
            {
                step.Invoke((TArg)args[0]);
                return Task.FromResult(0);
            };
            var parameter = ParameterDescriptor.FromConstant(step.GetMethodInfo().GetParameters()[0], arg);

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }
        public static StepDescriptor Create<TArg>(Func<TArg, Task> step, TArg arg)
        {
            Func<object, object[], Task> stepInvocation = (ctx, args) => step.Invoke((TArg)args[0]);
            var parameter = ParameterDescriptor.FromConstant(step.GetMethodInfo().GetParameters()[0], arg);

            return new StepDescriptor(step.GetMethodInfo().Name, stepInvocation, parameter);
        }
    }
}